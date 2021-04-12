--select 
--.CountryCode,
--m.MountainRange,
--p.PeakName,
--p.Elevation
--from Countries as c 
--join MountainsCountries as mc
--on c.CountryCode = mc.CountryCode
--join Mountains as m
--on mc.MountainId = m.Id
--join Peaks as p 
--on p.MountainId= m.Id
--where c.CountryCode = 'BG' and p.Elevation >= 2835
--order by p.Elevation DESC



select CountryCode, COUNT(MountainId) as [MountainRanges] from MountainsCountries
where CountryCode in ('US','RU','BG')
group by CountryCode

use SoftUni


--select e.FirstName,e.LastName,e.HireDate,d.[Name] as DeptName from  Employees as e 
--join Departments as d on e.DepartmentID=d.DepartmentID
-- e.HireDate > '1.1.1999' and d.[Name] in ('Sales','Finance')
-- by e.HireDate


--select e.EmployeeID,m.ID as [ManagerID],m.[Name]  as ManagerName from Employees as e 
--join Manager as m on e.EmployeeID=m.ID
--where m.ID in (3,7)
--order by EmployeeID ASC


--use Geography


