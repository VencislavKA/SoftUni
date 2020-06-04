
create table Passports
(
PassportID int primary key identity(101,1),
PassportNumber text
)

create table Persons
(
PersonID int primary key identity,
FirstName text not null,
Salary float(2) ,
PassportID int not null  foreign key references Passports(PassportID) unique
)

insert into Passports(PassportNumber)
values
('N34FG21B'),
('K65LO4R7'),
('ZE657QP2')


insert into Persons(FirstName,Salary,PassportID)values('Roberto', 43300.00,102),('Tom',56100.00,103),('Yana',60200.00,101)





create table Manufacturers
(
ManufacturerID int primary key identity,
[Name] nvarchar(50) not null,
EstablishedOn DATE not null
)
create table Models
(
ModelID int primary key identity(101,1),
[Name] nvarchar(50) not null,
ManufacturerID int foreign key references Manufacturers(ManufacturerID)
)

insert into Manufacturers([Name],EstablishedOn)values('BMW','03/07/1916'),('Tesla','01/01/2003'),('Lada','05/01/1966')

insert into Models([Name],ManufacturerID)values('X1','1'),('i6','1'),('Model S','2'),('Model X','2'),('Model 3','2'),('Nova','3')





create table Students(StudentID int primary key identity,[Name] nvarchar(50))

create table Exams(ExamID int primary key identity(101,1),[Name] nvarchar(50))

create table StudentsExams(
StudentID int not null foreign key references Students(StudentID),
ExamID int not null foreign key references Exams(ExamID),
primary key(StudentID,ExamID)
)

insert into Students([Name])values('Mila'),('Toni'),('Ron')

insert into Exams([Name])values('SpringMVC'),('Neo4j'),('Oracle 11g')

insert into StudentsExams(StudentID,ExamID)values(1,101),(1,102),(2,101),(3,103),(2,102),(2,103)












create table Teachers
(
TeacherID int primary key identity(101,1),
[Name] nvarchar(50),
ManagerID int foreign key references Teachers(TeacherID)
)


insert into Teachers([Name],ManagerID)values
('John',NULL),
('Maya',106),
('Silvia',106),
('Ted',105),
('Mark',101),
('Greta',101)







drop table Students



create table Majors(MajorID int primary key identity,[Name] nvarchar(50))

create table Students(StudentID int primary key identity,StudentNumber int,StudentName nvarchar(50),MajorID int foreign key references Majors(MajorID))

create table Payments(PaymentID int primary key identity,PaymentDate date,PaymentAmount decimal(15,2),StudentID int foreign key references Students(StudentID))

create table Subjects(SubjectID int primary key identity, [SubjectName] nvarchar(50) not null,)

create table Agenda(StudentID int foreign key references Students(StudentID),SubjectID int not null foreign key references Subjects(SubjectID),Primary key (StudentID,SubjectID))

