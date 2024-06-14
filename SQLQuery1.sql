
  Create Database Colleage
  Create table Country(cid int primary key not null identity(1,1), countryName varchar(100));
  INSERT INTO Country(countryName) values ('Newzeland') 


CREATE TABLE person(Id int not null identity(1,1),
name varchar(100),
Address varchar(100),
phonenumber varchar(100),
email varchar(100),
image varchar(100),
country varchar(100),
Hobby varchar(100),
Gender varchar(100)
)

select * from person;


CREATE PROCEDURE AddStudent
    @name VARCHAR(100),
    @Address VARCHAR(100),
    @phonenumber VARCHAR(100),
    @email VARCHAR(100),
    @image VARCHAR(100),
    @country INT,
    @Hobby VARCHAR(200),
    @Gender VARCHAR(100)
AS
BEGIN
    INSERT INTO person(name,Address,phonenumber,email,image,country,Hobby,Gender)
    VALUES (@name, @Address, @phonenumber, @email, @image, @country, @Hobby, @Gender)
END



CREATE PROC ViewStudent
AS
BEGIN
  SELECT * FROM person
END

CREATE PROC ModifyStudent
(
@name1 VARCHAR(100), 
@Address1 varchar(100), 
@phonenumber1 varchar(100), 
@email1 varchar(100), 
@image1 varchar(100), 
@Idd int,
@country1 int, 
@Hobby1 varchar(200), 
@Gender1 varchar(100)
)
AS
BEGIN
update person set name = @name1, Address = @Address1, phonenumber = @phonenumber1, email = @email1, image = @image1,
country=@country1,Hobby=@Hobby1,Gender=@Gender1 where Id = @Idd
END


====###### State Table Code ####===========
  
USE [Colleage]
GO

/****** Object:  Table [dbo].[statetbl]    Script Date: 04-06-2024 07:59:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[statetbl1](
	[stateid] [int] IDENTITY(1,1) NOT NULL,
	[statename] [varchar](100) NULL,
	[cid] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[stateid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO





