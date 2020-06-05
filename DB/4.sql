--select top(50) FirstName,LastName,t.Name as Town,a.AddressText from Employees as e join Addresses as a on e.AddressID = a.AddressID join Towns as t on a.TownID=t.TownID order by FirstName ASC,LastName



--select top(3) e.EmployeeID,e.FirstName from Employees as e 
--left outer join EmployeesProjects as ep
--on e.EmployeeID = ep.EmployeeID
--where ep.EmployeeID is null 
--order by ep.EmployeeID ASC


--select top(5) e.EmployeeID,e.FirstName,p.Name as PrejectName from Employees as e join EmployeesProjects as ep on e.EmployeeID = ep.EmployeeID join Projects as p  on ep.ProjectID = p.ProjectID where p.StartDate > '08.13.2002' and p.EndDate is null
--order by e.EmployeeID ASC



--select e.EmployeeID,e.FirstName,
--case 
	--when datepart(year,p.StartDate) >= 2005 then null
	--else p.[Name]
--end as [ProjectName] 
--from Employees as e join EmployeesProjects as ep on e.EmployeeID= ep.EmployeeID join Projects as p on ep.ProjectID = p.ProjectID where e.EmployeeID = 24



--select e.EmployeeID,e.FirstName,e.LastName,d.[Name] as DepartmentName from Employees as e join Departments as d on e.DepartmentID = d.DepartmentID 
-- d.[Name] = 'Sales'
--order by e.EmployeeID ASC 


--select top(5) e.EmployeeID,e.FirstName,e.Salary,d.[Name] as DepartmentName from Employees as e join Departments as d on e.DepartmentID = d.DepartmentID 
--where e.Salary > 15000
--order by d.DepartmentID


select top(50) e1.EmployeeID,
CONCAT(e1.FirstName,' ',e1.LastName) as [EmployeeName],
CONCAT(e2.FirstName,' ',e2.LastName) as [ManagerName],
d.[Name] as DepartmentName
from Employees as e1 
left join Employees as e2 
on e1.ManagerID = e2.EmployeeID 
join Departments as d 
on e1.DepartmentID = d.DepartmentID
order by e1.EmployeeID


select min([Average Salary]) as [MinAverageSalary] from 
(
select DepartmentID, AVG(Salary) as [Average Salary]
from Employees
group by DepartmentID
)as [AverageSalaryQuery]
