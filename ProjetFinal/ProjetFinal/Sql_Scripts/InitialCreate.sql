-- Script DDL!

IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'DevLibraryDB')
BEGIN
    CREATE DATABASE DevLibraryDB;
END;
GO

USE DevLibraryDB;
GO