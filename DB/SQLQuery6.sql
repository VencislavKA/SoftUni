create table Directors
(
Id int primary key identity,
DirectorName text,
Notes text,
)

insert into Directors(DirectorName,Notes) values ('go6o','jkhdgsafj'),('go6o','jkhdgsafj'),('go6o','jkhdgsafj'),('go6o','jkhdgsafj'),('go6o','jkhdgsafj')

create table Genres
(
Id int primary key identity,
GenreName text,
Notes text,
)

insert into Genres(GenreName,Notes) values ('go6o','jkhdgsafj'),('go6o','jkhdgsafj'),('go6o','jkhdgsafj'),('go6o','jkhdgsafj'),('go6o','jkhdgsafj')

create table Categories
(
Id int primary key identity,
CategoryName text,
Notes text,
)

insert into Categories(CategoryName,Notes) values ('go6o','jkhdgsafj'),('go6o','jkhdgsafj'),('go6o','jkhdgsafj'),('go6o','jkhdgsafj'),('go6o','jkhdgsafj')

create table Movies(
Id int primary key identity,
Title text,
DirectorId int foreign key references Directors(Id),
CopyrightYear datetime2,
[Length] int,
GenreId int foreign key references Genres(Id),
CategoryId int foreign key references Categories(Id),
Ration int,
Notes text,
)

insert into Movies(Title,DirectorId,CopyrightYear,[Length],GenreId,CategoryId,Ration,Notes)values
('gos',1,'05.15.2020',30,1,1,1,'saukdifhk'),
('gos',1,'05.15.2020',30,1,1,1,'saukdifhk'),
('gos',1,'05.15.2020',30,1,1,1,'saukdifhk'),
('gos',1,'05.15.2020',30,1,1,1,'saukdifhk'),
('gos',1,'05.15.2020',30,1,1,1,'saukdifhk')
drop table Movies
drop table Categories





create table Categories(
Id int primary key identity,
CategoryName text,
DailyRate int,
WeeklyRate int,
MonthlyRate int,
WeekendRate int
)

insert into Categories(CategoryName,DailyRate,WeekendRate,MonthlyRate,WeeklyRate)values 
('jkhdsafg',1,1,1,1),
('jkhdsafg',1,1,1,1),
('jkhdsafg',1,1,1,1)

create table Cars(
Id int primary key identity,
PlateNumber int,
Manufacturer text,
Model text,
CarYear int,
CategoryId int foreign key references Categories(Id),
Doors int ,
Picture VARBINARY(MAX),
Condition text,
Available bit,
)

insert into Cars (PlateNumber,Manufacturer,Model,CarYear,CategoryId,Doors,Condition,Available)values
(1,'djlkhsfg','kjdsfgh',1,1,1,'sjkhdalfg',0),
(1,'djlkhsfg','kjdsfgh',1,1,1,'sjkhdalfg',0),
(1,'djlkhsfg','kjdsfgh',1,1,1,'sjkhdalfg',0)

create table Employees(Id int primary key identity, FirstName text, LastName text, Title text, Notes text)

insert into Employees (FirstName,LastName,Title,Notes)values('kjhdgsa','afkhdsjlg','kajshdfgf','ajkhdsgf'),('kjhdgsa','afkhdsjlg','kajshdfgf','ajkhdsgf'),('kjhdgsa','afkhdsjlg','kajshdfgf','ajkhdsgf')

create table Customers (Id int primary key identity, DriverLicenceNumber int, FullName text, [Address] text, City text, ZIPCode int, Notes text)

insert into Customers (DriverLicenceNumber) values (1),(1),(1)

create table RentalOrders (Id int primary key identity, EmployeeId int foreign key references Employees(Id), CustomerId int foreign key references Customers(Id),
CarId int foreign key references Cars(Id), TankLevel int, KilometrageStart int, KilometrageEnd int,  TotalKilometrage int , StartDate datetime2, EndDate datetime2, TotalDays int, RateApplied int, TaxRate int,
OrderStatus bit, Notes text)

insert into RentalOrders(EmployeeId,CustomerId,CarId)values(1,1,1),(1,1,1),(1,1,1)

drop table Employees
drop table RentalOrders
drop table Customers

create table Employees (Id int primary key identity, FirstName text, LastName text, Title text, Notes text)

insert into Employees (FirstName)values('asdsjkjdg'),('asdsjkjdg'),('asdsjkjdg')

create table Customers (AccountNumber int, FirstName text, LastName text, PhoneNumber int, EmergencyName text, EmergencyNumber int, Notes text)

insert into Customers (AccountNumber)values(1),(1),(1)

create table RoomStatus (Id int primary key identity,RoomStatus text, Notes text)

insert into RoomStatus (RoomStatus)values('ajskhdgf'),('ajskhdgf'),('ajskhdgf')

create table RoomTypes (Id int primary key identity,RoomType text, Notes text)

insert into RoomTypes (RoomType)values('dgjhfg'),('dgjhfg'),('dgjhfg')

create table BedTypes (Id int primary key identity,BedType text, Notes text)

insert into BedTypes (BedType)values('sjkhdg'),('sjkhdg'),('sjkhdg')

create table Rooms (Id int primary key identity,RoomNumber int, RoomType int foreign key references RoomTypes(Id), BedType  int foreign key references BedTypes(Id), Rate int, RoomStatus bit, Notes text)

insert into Rooms (RoomNumber)values(1),(1),(1)

create table Payments (Id int primary key identity, EmployeeId int foreign key references Employees(Id), PaymentDate datetime2, AccountNumber int, FirstDateOccupied datetime2,
LastDateOccupied datetime2, TotalDays int, AmountCharged int, TaxRate int, TaxAmount int , PaymentTotal int, Notes text)

insert into Payments(EmployeeId,TaxAmount)values(1,100),(1,100),(1,100)

create table Occupancies (Id int primary key identity, EmployeeId int foreign key references Employees(Id), DateOccupied datetime2, AccountNumber int, RoomNumber int foreign key references Rooms(Id), RateApplied int, PhoneCharge int, Notes text)


insert into Occupancies(EmployeeId,RoomNumber)values(1,1),(1,1),(1,1)



update Payments
		set TaxRate -= TaxRate * 0.03

		select TaxRate from Payments


		delete from Occupancies
		select * from Occupancies
