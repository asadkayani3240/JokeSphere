-- Create database if it doesn't exist
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'JokeSphereDb')
  CREATE DATABASE [JokeSphereDb];
GO

USE [JokeSphereDb];
GO

-- Create the Jokes table
IF NOT EXISTS (SELECT * FROM sys.objects
               WHERE object_id = OBJECT_ID(N'[dbo].[Jokes]')
                 AND type in (N'U'))
BEGIN
  CREATE TABLE [dbo].[Jokes] (
    [Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Setup] NVARCHAR(500) NOT NULL,
    [Punchline] NVARCHAR(500) NOT NULL
  );
END
GO