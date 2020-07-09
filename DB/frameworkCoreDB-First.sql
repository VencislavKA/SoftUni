create database Hospital
use Hospital
create table Patient
(
PatientId int primary key identity,
FirstName nvarchar(50),
LastName nvarchar(50),
[Address] nvarchar(250),
Email varchar(80),
HasInsurence bit
)
create table Visitation
(
VisitationId int primary key identity,
[Date] datetime2,
Comments nvarchar(250),
Patient int foreign key references Patient(PatientId)
)
create table Diagnose
(
DiagnoseId int primary key identity,
[Name] nvarchar(50),
Comments nvarchar(250),
Patient int foreign key references Patient(PatientId)
)
create table Medicament
(
MedicamentId int primary key identity,
[Name] nvarchar(50)
)
