CREATE DATABASE MyDatabase ON PRIMARY (NAME = MyDatabase_Data, FILENAME = '~\\App_Data\\MyDatabaseData.mdf', 
	SIZE = 2MB, MAXSIZE = 10MB, FILEGROWTH = 10%)
	LOG ON (NAME = MyDatabase_Log,
        FILENAME = '~\\App_Data\\MyDatabaseLog.ldf',
        SIZE = 1MB,
        MAXSIZE = 5MB,
        FILEGROWTH = 10%)