USE [master]
GO




USE [master]
GO

/****** Object:  Database [Test]    Script Date: 01/04/2010 10:10:29 ******/
IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'Test')
ALTER DATABASE [Test] SET SINGLE_USER WITH ROLLBACK IMMEDIATE
IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'Test')
ALTER DATABASE [Test] SET SINGLE_USER
IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'Test')
DROP DATABASE [Test]
GO


 
