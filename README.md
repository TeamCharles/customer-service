# Bangazon Customer Service

## Dependencies

To ensure that the  Bangazon Customer Service App works as intended make sure that you have the following dependencies and technologies on your local machine

- dotnet 

If you need to download dotnet onto your local machine, visit [Microsoft's Documentation](https://www.microsoft.com/en-us/download/details.aspx?id=30653)

- DB Browser for SQLite

If you need to download DB Browser onto your local machine, visit [DB Browser's Documentation](http://sqlitebrowser.org/)

## Installation OSX/UNIX

Clone or fork the project. Navigate to where the project is saved on your machine. For all of the following commands enter them into your bash terminal to ensure that the application is installed correctly


This command sets the environment for your local copy of the application to development mode.
```Bash
export ASPNETCORE_ENVIRONMENT="Development"
```

Determine which directory you would like to store your database file and create a blank file with the following commands.
```Bash
touch "/path/to/bangazonIncident.db"
```

On initial installation of the Banagazon CLI application you must set an environment variable to your local database.
```Bash
export BangazonWeb_Db_Path="/path/to/bangazonIncident.db"
```

Open your `bangazonIncident.db` file in DB Browser, select the `Edit Pragmas` tab and make sure that the `Foreign Keys` checkbox is unchecked. Open `Data/tables.sql` from the `Execute SQL` tab of DB Browser and execute the statement. Do the same action with `Data/populate.sql`. In DB Browser, click `Write Changes` to commit your changes to the database.

Navigate into the `src/customer-service` folder.

```Bash
cd src/customer-service
```

Once your local variables have been set run the following commands to start.
```Bash
dotnet restore
dotnet run
```

## Installation Windows

Clone or fork the project. Navigate to where the project is saved on your machine. For all of the following commands enter them into your bash terminal to ensure that the application is installed correctly


Determine which directory you would like to store your database file and create a blank file with the following commands.
```Bash
touch "/path/to/bangazonIncident.db"
```

This command sets the environment for your local copy of the application to development mode.
```Bash
$env:ASPNETCORE_ENVIRONMENT="Development"
```

On initial installation of the Banagazon CLI application you must set an environment variable to your local database.
```Bash
$env:BangazonWeb_Db_Path="/path/to/bangazonIncident.db"
```

Open your `bangazonIncident.db` file in DB Browser, select the `Edit Pragmas` tab and make sure that the `Foreign Keys` checkbox is checked. Open `Data/tables.sql` from the `Execute SQL` tab of DB Browser and execute the statement. Do the same action with `Data/populate.sql`. In DB Browser, click `Write Changes` to commit your changes to the database.

Navigate into the `src/customer-service` folder.

```Bash
cd src/customer-service
```

Once your local variables have been set run the following commands to start.
```Bash
dotnet restore
dotnet run
```
