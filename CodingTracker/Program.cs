using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;

namespace CodingTracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dataAccess = new DataAccess();

            dataAccess.CreateDatabase();
            
            //SeedData.SeedRecords(20); //Comentar quando nao quisermos dar seed de mais records

            UserInterface.MainMenu();
        }
    }
}
