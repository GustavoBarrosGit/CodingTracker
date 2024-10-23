﻿using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTracker;

internal class DataAccess 
{
    IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

    private string ConnectionString;

    public DataAccess()
    {
        ConnectionString = configuration.GetSection("ConnectionStrings")["DefaultConnection"];
    }
    
    internal void CreateDatabase()
    {
        using (var connection = new SqliteConnection(ConnectionString)) 
        {
            connection.Open();

            string createTableQuery = @"
            CREATE TABLE IF NOT EXISTS records (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                DateStart TEXT NOT NULL,
                DateEnd TEXT NOT NULL
            )";

            connection.Execute(createTableQuery);
        }
    }

    internal void InsertRecord(CodingRecord record)
    {
        using (var connection = new SqliteConnection(ConnectionString))
        {
            connection.Open();

            string insertQuery = @"
                INSERT INTO records (DateStart, DateEnd)
                VALUES (@DateStart, @DateEnd)";

            connection.Execute(insertQuery, new {record.DateStart, record.DateEnd});
        }
    }

    internal void UpdateRecord(CodingRecord updatedRecord)
    {
        using (var connection = new SqliteConnection(ConnectionString))
        {
            connection.Open();

            string updateQuery = @"
                UPDATE records
                SET DateStart = @DateStart, DateEnd = @DateEnd
                WHERE Id = @Id";

            connection.Execute(updateQuery, new {updatedRecord.DateStart, updatedRecord.DateEnd, updatedRecord.Id});

        }
    }

    internal int DeleteRecord(int recordId)
    {
        using (var connection = new SqliteConnection(ConnectionString))
        {
            connection.Open();

            string deleteQuery = @"DELETE FROM records WHERE Id = @Id";

            int rowsAffected = connection.Execute(deleteQuery, new { Id = recordId });

            return rowsAffected;
        }
    }

    internal IEnumerable<CodingRecord> GetAllRecords()
    {
        using (var connection = new SqliteConnection(ConnectionString))
        {
            connection.Open();

            string selectQuery = "SELECT * FROM records";

            var records = connection.Query<CodingRecord>(selectQuery);

            foreach (var record in records)
            {
                record.Duration = record.DateEnd - record.DateStart;
            }
            return records;
        }
    }

    internal void BulkInsertRecords(List<CodingRecord> records)
    {
        using (var connection = new SqliteConnection(ConnectionString))
        {
            connection.Open();

            string insertQuery = @"
                INSERT INTO records (DateStart, DateEnd)
                VALUES (@DateStart, @DateEnd)";

            connection.Execute(insertQuery, records.Select(record => new{
                record.DateStart,
                record.DateEnd
            }));
        }
    }
}

