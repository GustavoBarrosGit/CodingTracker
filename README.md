## Overview

The **Coding Tracker** is a simple console application that allows users to log and track their daily coding time. The application uses **SQLite** as its database and interacts with it using **Dapper**.

## Features

- **Log** daily coding sessions with specific start and end times.
- **View** all recorded coding sessions for a selected day.
- **Insert** new coding sessions into the database.
- **Delete** or **update** existing coding session records.
- Automatically **create** the database and **seed data** upon first run of the application.
- Enforces specific input formats for date and time logging.
- Uses **Spectre.Console** for enhanced output formatting and user input handling.
- Implements a separate configuration file for database paths and connection strings.
- Includes a `CodingSession` class to encapsulate properties: Id, StartTime, EndTime, Duration.
- Calculates the duration of coding sessions automatically, based on the start and end times.
