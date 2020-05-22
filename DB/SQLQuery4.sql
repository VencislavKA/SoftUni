CREATE TABLE People
(
  Id        INT IDENTITY,
  [Name]      NVARCHAR(200) NOT NULL,
  Picture   VARBINARY(2000),
  Height    FLOAT(2),
  [Weight]    FLOAT(2),
  Gender    CHAR NOT NULL CHECK (Gender = 'm' OR Gender = 'f'),
  Birthdate DATETIME2 NOT NULL,
  Biography NVARCHAR(MAX),
)

INSERT People 
([Name],Picture,Height,[Weight],Gender,Birthdate,Biography)VALUES 
('Gosho', NULL,NULL,NULL,'f','05.19.2020',NULL),
('Gosho', NULL,NULL,NULL,'f','05.19.2020',NULL),
('Gosho', NULL,NULL,NULL,'f','05.19.2020',NULL),
('Gosho', NULL,NULL,NULL,'f','05.19.2020',NULL),
('Gosho', NULL,NULL,NULL,'f','05.19.2020',NULL)

SELECT * FROM People

DROP TABLE People

drop table Users

CREATE TABLE Users
(
Id BIGINT PRIMARY KEY IDENTITY,
Username varchar(30) not null,
[Password] varchar(26) not null,
ProfilePicture VARBINARY(MAX) CHECK (DATALENGTH(ProfilePicture) <= 900 * 1024),
LastLoginTime DATETIME2 NOT NULL,
IsDelited BIT NOT NULL
)
INSERT INTO Users(Username,[Password],LastLoginTime,IsDelited)VALUES('Pesho0','123456','05.19.2020',0),
('Pesho1','123456','05.19.2020',1),
('Pesho2','123456','05.19.2020',0),
('Pesho3','123456','05.19.2020',0),
('Pesho4','123456','05.19.2020',1)

select * FROM Users


create database Movies
