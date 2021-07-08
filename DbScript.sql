USE master;
GO
CREATE DATABASE Library
GO
USE Library
GO
CREATE TABLE dbo.Author(
    Id int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Authors PRIMARY KEY,
    Name nvarchar(45) NOT NULL UNIQUE,
)
GO
CREATE TABLE dbo.Book(
	Id int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Book PRIMARY KEY,
	Author_id int NOT NULL,
	Name nvarchar(45) NOT NULL,
	YearOfPublication int NOT NULL,
)
GO
INSERT INTO Library.dbo.Author
(Name) VALUES 
( N'Джон Стейнбек'),
( N'Эрих Мария Ремарк');
GO
INSERT INTO Library.dbo.Book
(Author_id, Name, YearOfPublication) VALUES 
( 1, N'О мышах и людях', 1937),
( 2, N'Черный обелиск', 1956);
------------------
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE dbo.Book_GetById
	@id int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT TOP 1
		b.Id,b.Name, a.Name, b.YearOfPublication
	FROM Book b, Author a
	WHERE b.Id = @id AND b.Author_id = a.Id
END
GO
--------------
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE dbo.Book_Add
	@Name nvarchar(45),
	@Author_name nvarchar(45), 
	@YearOfPublication nvarchar(45)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO Library.dbo.Author
	SELECT @Author_name
	FROM Author
	WHERE NOT EXISTS(SELECT 1
					FROM Author a
					WHERE a.Name = @Author_name)
	
	
	DECLARE @id_a INT;
	SET @id_a =  (SELECT  Id
		FROM Author a
		WHERE @Author_name = a.Name)

	IF (@@IDENTITY IS NULL)
		BEGIN 
			INSERT INTO Library.dbo.Book
			(Author_id, Name, YearOfPublication) VALUES 
			( @id_a, @Name, @YearOfPublication);

			SELECT CAST(scope_identity() AS INT) AS NewID
		END
	ELSE
		BEGIN
			SELECT CAST(scope_identity() AS INT) AS NewID

			INSERT INTO Library.dbo.Book
			(Author_id, Name, YearOfPublication) VALUES 
			( @@IDENTITY,@Name, @YearOfPublication);
		END
END
GO