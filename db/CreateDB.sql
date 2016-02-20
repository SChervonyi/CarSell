USE [master]
GO

--exec sp_who2
--kill 52

IF EXISTS (SELECT name FROM master.dbo.sysdatabases where name = N'CarSell') 
BEGIN
	DROP DATABASE [CarSell]
END
GO

/****** Object:  Database [CarSell]    Script Date: 17.02.2016 11:08:35 ******/
CREATE DATABASE [CarSell] 
GO
ALTER DATABASE CarSell MODIFY FILE 
( NAME = N'CarSell' , SIZE = 3048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
GO
ALTER DATABASE CarSell MODIFY FILE 
( NAME = N'CarSell_log' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO