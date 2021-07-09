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
CREATE TABLE dbo.[User](
	Id int IDENTITY(1,1) NOT NULL CONSTRAINT PK_User PRIMARY KEY,
	Name nvarchar(45) NOT NULL UNIQUE,
	Password nvarchar(45) NOT NULL,
	Email nvarchar(45) NOT NULL UNIQUE,
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
GO
INSERT INTO Library.dbo.[User]
(Name, Password, Email) VALUES 
( N'Admin', N'Password', N'Admin@gmail.com'),
( N'User', N'Password', N'User@gmail.com');
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
		b.Id,b.Name, a.Name AS Author, b.YearOfPublication
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
----------------------
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE dbo.Book_Remove
	@id int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT TOP 1
		b.Id,b.Name, a.Name AS Author, b.YearOfPublication
	FROM Book b, Author a
	WHERE b.Id = @id AND b.Author_id = a.Id

	DELETE 
	FROM Book
	WHERE Id = @id

END
GO
------------------
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE dbo.Book_Edit
	@id int,
	@Name nvarchar(45),
	@YearOfPublication nvarchar(45)
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE Book 
	SET Name=@Name, YearOfPublication = @YearOfPublication
	WHERE Id=@id 

	--UPDATE Book
	--SET Name=@Name, YearOfPublication = @YearOfPublication
	--FROM Author a
	--WHERE Book.Id=@id AND a.Name LIKE '%@Author_name%'

	SELECT TOP 1
		b.Id, b.Name, a.Name AS Author, b.YearOfPublication
	FROM Book b, Author a
	WHERE b.Id = @id AND b.Author_id = a.Id

END
GO
---------------------------
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE dbo.AllBooksByAuthor
	@Author nvarchar(45)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT b.Id, b.Name, a.Name AS Author, b.YearOfPublication
	FROM Author a
	LEFT JOIN Book b ON b.Author_id = a.Id
	WHERE a.Name IN (@Author)

END
GO
---------------
--User PROCEDURE
---------------
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE dbo.User_Authentication
	@Name nvarchar(45),
	@Password nvarchar(45)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT CASE 
	WHEN EXISTS(SELECT *
				FROM dbo.[User] u
				WHERE u.Name = @Name AND u.Password = @Password)
			THEN CAST(1 AS bit)
			ELSE CAST(0 AS bit)
			End
END
-------------
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE dbo.User_GetByName
	@Name nvarchar(45)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT u.Id, u.Name, u.Email
	FROM dbo.[User] u
	WHERE Name = @Name
END
--------------
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE dbo.User_Edit
	@Id int,
	@NewName nvarchar(45),
	@NewPassword nvarchar(45),
	@NewEmail nvarchar(45)
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE dbo.[User] 
	SET Name = @NewName, Password = @NewPassword, Email = @NewEmail
	WHERE Id = @Id

	SELECT TOP 1
		Id, Name, Password, Email
	FROM dbo.[User] 
	WHERE Id = @Id

END
GO