# Bangazon Customer Service

## Dependencies

To ensure that the  Bangazon Workforce Management App works as intended make sure that you have the following dependencies and technologies on your local machine

- dotnet 

If you need to download dotnet onto your local machine, visit [Microsoft's Documentation](https://www.microsoft.com/en-us/download/details.aspx?id=30653)

- DB Browser for Sqlite

If you need to download DB Browser onto your local machine, visit http://sqlitebrowser.org/

## Installation OSX/UNIX

Clone or fork the project. Navigate to where the project is saved on your machine. For all of the following commands enter them into your bash terminal to ensure that the application is installed correctly


This command sets the environment for your local copy of the application to development mode.
```Bash
export ASPNETCORE_ENVIRONMENT="Development"
```

On initial installation of the Banagazon web application you must set an environment variable to your local database. (You will create this database with the file name bangazon.db in the next step.)
```Bash
export BangazonWeb_Db_Path="/path/to/bangazon.db"
```

Now you will create the database file and use SQL commands to create tables and populate those tables with data.
```Bash
touch /path/to/bangazon.db
```

Open the database file you created in `DB Browser for Sqlite`. Navigate to the `Edit Pragmas` tab, check the `Foreign Keys` checkbox and click the `Save` button at the bottom of the screen. Keep the database open.

Open the `tables.sql` file located in `src/customer-service/Data` of the project directory. Copy that entire file onto your clipboard, open `DB Browser for Sqlite` and navigate to the `Execute SQL` tab, paste the sql commands you copied into the code window and click the play button (or `shift + enter`.)
Open the `populate.sql` file located in `src/customer-service/Data` of the project directory. Copy that entire file onto your clipboard, open `DB Browser for Sqlite` and navigate to the `Execute SQL` tab, paste the sql commands you copied into the code window and click the play button (or `shift + enter`.)
In `DB Browser for Sqlite`, click the `Write Changes` button to commit your changes to the database.

Navigate into the `src/workforce-management` folder.

```Bash
cd src/workforce-management
```

Once your local variables have been set run the following commands to start.
```Bash
dotnet restore
dotnet run
```

## Installation Windows

Clone or fork the project. Navigate to where the project is saved on your machine. For all of the following commands enter them into your bash terminal to ensure that the application is installed correctly


This command sets the environment for your local copy of the application to development mode.
```Bash
$env:ASPNETCORE_ENVIRONMENT="Development"
```

On initial installation of the Banagazon web application you must set an environment variable to your local database. (You will create this database with the file name bangazon.db in the next step.)
```Bash
$env:BangazonWeb_Db_Path="/path/to/bangazon.db"
```

Now you will create the database file and use SQL commands to create tables and populate those tables with data.
```Bash
touch /path/to/bangazon.db
```

Open the database file you created in `DB Browser for Sqlite`. Navigate to the `Edit Pragmas` tab, check the `Foreign Keys` checkbox and click the `Save` button at the bottom of the screen. Keep the database open.

Open the `tables.sql` file located in `src/customer-service/Data` of the project directory. Copy that entire file onto your clipboard, open `DB Browser for Sqlite` and navigate to the `Execute SQL` tab, paste the sql commands you copied into the code window and click the play button (or `shift + enter`.)
Open the `populate.sql` file located in `src/customer-service/Data` of the project directory. Copy that entire file onto your clipboard, open `DB Browser for Sqlite` and navigate to the `Execute SQL` tab, paste the sql commands you copied into the code window and click the play button (or `shift + enter`.)
In `DB Browser for Sqlite`, click the `Write Changes` button to commit your changes to the database.

Navigate into the `src/workforce-management` folder.

```Bash
cd src/workforce-management
```

Once your local variables have been set run the following commands to start.
```Bash
dotnet restore
dotnet run
```