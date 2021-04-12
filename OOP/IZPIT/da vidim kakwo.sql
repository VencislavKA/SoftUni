
use master
alter database Bakery set single_user with rollback immediate
drop database Bakery
create database Bakery
use Bakery


create table Countries
(
	Id int primary key identity,
	[Name] nvarchar(50) unique
)
create table Customers
(
	Id int primary key identity,
	FirstName nvarchar(25),
	LastName nvarchar(25),
	Gender char(1) check(Gender in ('M','F')),
	Age int,
	PhoneNumber char(10),
	CountryId int references Countries(Id)
)
create table Products(
	Id int primary key identity,
	[Name] nvarchar(25) unique,
	Description nvarchar(250), -- can be tinyint--
	Recipe nvarchar(max),
	Price decimal(2) check(Price >= 0) -- can be without 0--
)
create table Feedbacks(
	Id int primary key identity,
	[Description] nvarchar(255), -- can be tinyint--
	Rate decimal(4,2) check(Rate >= 0 and Rate <= 10),
	ProductId int references Products(Id),
	CustomerId int references Customers(Id)
)
create table Distributors
(
	Id int primary key identity,
	[Name] nvarchar(25) unique,
	AddressText nvarchar(30),
	Summary nvarchar(200),
	CountryId int references Countries(Id)
)
create table Ingredients(
	Id int primary key identity,
	[Name] nvarchar(30),
	[Description] nvarchar(200),
	OriginCountryId int references Countries(Id),
	DistributorId int references Distributors(Id)
)
create table ProductsIngredients
(
	ProductId int references Products(Id) not null,
	IngredientId int references Ingredients(Id) not null,
	Primary key ( ProductId, IngredientId )
)


INSERT Distributors (Name,CountryId,AddressText,Summary) 
values
('Deloitte & Touche',2,'6 Arch St #9757','Customizable neutral traveling'),
('Congress Title',13,'58 Hancock St','Customer loyalty'),
('Kitchen People',1,'3 E 31st St #77','Triple-buffered stable delivery'),
('General Color Co Inc',21,'6185 Bohn St #72','Focus group'),
('Beck Corporation',23,'21 E 64th Ave','Quality-focused 4th generation hardware')

Insert Customers(FirstName,LastName,Age,Gender,PhoneNumber,CountryId)
values
('Francoise','Rautenstrauch',15,'M','0195698399',5),
('Kendra','Loud',22,'F','0063631526',11),
('Lourdes','Bauswell',50,'M','0139037043',8),
('Hannah','Edmison',18,'F','0043343686',1),
('Tom','Loeza',31,'M','0144876096',23),
('Queenie','Kramarczyk',30,'F','0064215793',29),
('Hiu','Portaro',25,'M','0068277755',16),
('Josefa','Opitz',43,'F','0197887645',17)



Update Ingredients set DistributorId = 35 where Name in ('Bay Leaf', 'Paprika' , 'Poppy' )
Update Ingredients set OriginCountryId = 14 where OriginCountryId = 8





delete from Feedbacks where CustomerId = 14 or ProductId = 5


select Name,Price,Description from Products as p order by p.Price DESC , p.Name ASC


select f.ProductId,f.Rate,f.Description,f.CustomerId,c.Age,c.Gender from Feedbacks as f join Customers as c on f.CustomerId = c.Id where f.Rate < 5.0 order by ProductId DESC, Rate where f.Rate < 5.0 order by ProductId DESC, Rate


select Concat(c.FirstName,' ',c.LastName) as CustomerName,c.PhoneNumber,c.Gender from Customers as c left join Feedbacks as f on f.CustomerId = c.Id where f.Id is null order by c.Id asc
 



select * from Countries where Name = 'Greece'

select c.FirstName,c.Age,c.PhoneNumber from Customers as c where c.Age >= 21 and c.FirstName like '%an%' or PhoneNumber like '%38' and c.CountryId != 31 order by c.FirstName ASC, Age DESC




select RTRIM (LTRIM (LEFT (d.Name,CHARINDEX(' ' , d.Name))))from Ingredients as i join Distributors as d on i.DistributorId = d.Id




select avgrate from (select AVG(Rate)as avgRate from Ingredients as i join Distributors as d on i.DistributorId=d.Id join ProductsIngredients as PI on PI.IngredientId = i.Id join Products as p on p.Id = PI.ProductId join Feedbacks as f on f.ProductId = p.Id group by Rate
) as avgrate
where avgrate between 5 and 8


select * from ProductsIngredients as pi join Ingredients as i on i.Id = pi.IngredientId join Distributors as d on d.Id = i.DistributorId join Countries as c on c.Id= d.CountryId


SELECT D.Name AS [DistributorName],I.Name AS [IngredientName], P.Name AS [ProductName], AVG(F.Rate) AS AverageRate FROM Ingredients AS i
JOIN ProductsIngredients AS [PI] ON i.Id = [PI].IngredientId
JOIN Products AS p ON [PI].ProductId = p.Id
JOIN Feedbacks AS f ON p.Id = f.ProductId
JOIN Distributors AS d ON I.DistributorId = d.Id
GROUP BY d.Name, i.Name,p.Name
HAVING AVG(F.Rate) BETWEEN 5 AND 8
ORDER BY d.Name ASC,i.Name ASC,p.Name ASC



SELECT D.Name AS [DistributorName],I.Name AS [IngredientName], P.Name AS [ProductName], AVG(F.Rate) AS AverageRate FROM Ingredients AS i
JOIN ProductsIngredients AS [PI] ON i.Id = [PI].IngredientId
JOIN Products AS p ON [PI].ProductId = p.Id
JOIN Feedbacks AS f ON p.Id = f.ProductId
JOIN Distributors AS d ON I.DistributorId = d.Id
GROUP BY d.Name, i.Name,p.Name
HAVING AVG(F.Rate) BETWEEN 5 AND 8
ORDER BY d.Name ASC,i.Name ASC,p.Name ASC


SELECT * FROM Distributors AS d
join Countries as c on d.CountryId = c.Id

GROUP BY d.Name, i.Name,p.Name
HAVING AVG(F.Rate) BETWEEN 5 AND 8
ORDER BY d.Name ASC,i.Name ASC,p.Name ASC


CREATE VIEW v_UserWithCountries AS
SELECT c.FirstName + ' '+ c.LastName AS [CustomersName], c.Age as [Age], c.Gender AS [Gender],co.Name AS [CountryName] FROM Customers AS c
JOIN Countries AS co ON c.CountryId = co.Id

create trigger trigger_name
BEFORE DELETE
ON Products
AS
begin
	ALTER TABLE Feedbacks   
	DROP CONSTRAINT FK_Feedbacks_Products;
	ALTER TABLE ProductIngradients  
	DROP CONSTRAINT FK_ProductIngradients_Products;
end


CREATE TRIGGER orders_before_delete
BEFORE DELETE
   ON orders
   FOR EACH ROW

DECLARE ID int =;

BEGIN
	delete from Feedbacks where ProductId = ID;
	delete from ProductsIngredients where ProductId = ID;
	delete from Products where Id = ID;
END;



BEGIN
   ALTER TABLE Feedbacks   
	DROP CONSTRAINT FK_Feedbacks_Products;
	ALTER TABLE ProductIngradients  
	DROP CONSTRAINT FK_ProductIngradients_Products;
END;