create table ItemTypes
(
ItemTypeID int primary key identity,
[Name] varchar(50)
)
create table Items
(
ItemID int primary key identity,
[Name] varchar(50),
ItemTypeID int foreign key references ItemTypes(ItemTypeID)
)
create table Cities
(
CityID int primary key identity,
[Name] varchar(50)
)
create table Customers
(
CustomerID int primary key identity,
[Name] varchar(50),
Birthday date,
CityID int foreign key references Cities(CityID)
)
create table Orders
(
OrderID int primary key identity,
CustomerID int foreign key references Customers(CustomerID)
)
create table OrderItems
(
OrderID int foreign key references Orders(OrderID),
ItemID int  foreign key references Items(ItemID)
primary key(OrderID,ItemID)
)