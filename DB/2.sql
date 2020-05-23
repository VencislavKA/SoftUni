

select FirstName+'.'+LastName+'@softuni.bg' as 'Full Email Address' from Employees

select * from Employees

select * from Employees where JobTitle='Sales Representative'

select FirstName+' '+ MiddleName+' '+LastName+' ' as 'Full Name' from Employees where Salary in (25000, 14000, 12500 , 23600)

select FirstName,LastName from Employees where ManagerID IS NULL

select FirstName,LastName,Salary from Employees where Salary > 50000 order by Salary DESC

SELECT top 5 FirstName,LastName FROM Employees ORDER BY Salary DESC

SELECT FirstName,LastName FROM Employees where DepartmentID != 4

SELECT * from Employees order by Salary DESC, FirstName ASC,LastName DESC,MiddleName ASC

go

create view [V_EmployeesSalaries] 
AS 
select Firstname, Lastname, Salary 
from Employees

go

create view V_EmployeeNameJobTitle 
as 
(select CONCAT(FirstName,' ',MiddleName,' ',LastName) AS [Full Name], JobTitle from Employees)

go 

select distinct JobTitle from Employees

select top 10 * from Projects order by StartDate, [Name]

select top 7 FirstName,LastName,HireDate from Employees order by HireDate DESC

select Salary from Departments where JobTitle LIKE '% Engineering' OR JobTitle LIKE '% Tool Designer' OR  JobTitle like 'Marketing %' 

update Employees set Salary += Salary * 0.12 where DepartmentID IN (1,2,4,11)

select Salary from Employees

use Geography
Select [CountryName], [CountryCode],
case when [CurrencyCode] = 'EUR' 
then 'EUR'
else 'Not Euro'
end as [Currency]
from [Countries] order by [CountryName] ASC