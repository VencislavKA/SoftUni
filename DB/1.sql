	select [Name] from Towns 
	order by [Name] ASC
	select [Name] from Departments
	order by [Name] ASC
	select FirstName, LastName, JobTitle, Salary from Employees
	order by [Salary] DESC

		update Employees 
		set Salary += Salary * 0.1

		select Salary from Employees 