USE [master]
GO
IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'xstoredb')
DROP DATABASE [xstoredb]
GO
USE [master]
GO
CREATE DATABASE [xstoredb];
GO
USE [xstoredb]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Products]') AND type in (N'U'))
DROP TABLE [dbo].[Products]
GO
CREATE TABLE [dbo].[Products](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ModelNumber] NVARCHAR(50) NOT NULL,
	[UnitCost] [money] NULL
);
INSERT INTO [dbo].[Products] VALUES ('A', 1)
INSERT INTO [dbo].[Products] VALUES ('B', 2)
INSERT INTO [dbo].[Products] VALUES ('C', 3)