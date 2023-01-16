--01. Employee Address
/*
Create a query that selects:
EmployeeId
JobTitle
AddressId
AddressText
Return the first 5 rows sorted by AddressId in ascending order.
*/

select top 5
e.EmployeeId,
e. JobTitle,
a.AddressId,
a.AddressText
from [Employees] e
join [Addresses] a on a.AddressID = e.AddressID
order by e.AddressID

--02. Addresses with Towns
/*
Write a query that selects:
•	FirstName
•	LastName
•	Town
•	AddressText
Sort them by FirstName in ascending order, then by LastName. Select the first 50 employees.
*/
select top 50
e.FirstName,
e.LastName,
t.[Name],
a.AddressText
from [Employees] e
join [Addresses] a on a.AddressID = e.AddressID
join [Towns] t on t.TownID = a.TownID
order by FirstName, LastName

--03. Sales Employees
/*Create a query that selects:
•	EmployeeID
•	FirstName
•	LastName
•	DepartmentName
Sort them by EmployeeID in ascending order. Select only employees from the "Sales" department.
*/
select
e.EmployeeId,
e.FirstName,
e.LastName,
d.Name
from [Employees] e
join [Departments] d on e.[DepartmentID] = d.DepartmentID
where d.DepartmentID = 3
order by EmployeeId

--04. Employee Departments
/*Create a query that selects:
•	EmployeeID
•	FirstName 
•	Salary
•	DepartmentName
Filter only employees with a salary higher than 15000. Return the first 5 rows, sorted by DepartmentID in ascending order.
*/
select top 5
e.EmployeeId,
e.FirstName,
e.Salary,
d.Name
from [Employees] e
join [Departments] d on e.[DepartmentID] = d.DepartmentID
where e.Salary > 15000
order by e.DepartmentID

--05. Employees Without Projects
/*Create a query that selects:
EmployeeID
FirstName
Filter only employees without a project. Return the first 3 rows, sorted by EmployeeID in ascending order.
*/
select top 3 
e.EmployeeID, e.FirstName from Employees e
full join EmployeesProjects ep on ep.EmployeeID = e.EmployeeID 
where ep.ProjectID is NULL
order by e.EmployeeID

--06. Employees Hired After
/*Create a query that selects:
FirstName
LastName
HireDate
DeptName
Filter only employees hired after 1.1.1999 and are from either "Sales" or "Finance" department. Sort them by HireDate (ascending).
*/
select 
e.FirstName,
e.LastName,
e.HireDate,
d.Name as DeptName
from Employees e
join Departments d on e.DepartmentID = d.DepartmentID
where e.DepartmentID in (3, 10) 
and HireDate > Convert(datetime, '1.1.1999' )
order by HireDate 

--07. Employees With Project
/*Create a query that selects:
•	EmployeeID
•	FirstName
•	ProjectName
Filter only employees with a project which has started after 13.08.2002 and it is still ongoing (no end date). 
Return the first 5 rows sorted by EmployeeID in ascending order.
*/
select top 5 
e.EmployeeID, e.FirstName, p.Name from Employees e
join EmployeesProjects ep on ep.EmployeeID = e.EmployeeID 
join Projects p on ep.ProjectID = p.ProjectID
where p.EndDate is NULL
and p.StartDate > Convert(smalldatetime, '13.08.2002', 104) 
order by e.EmployeeID

--08. Employee 24
/*Create a query that selects:
•	EmployeeID
•	FirstName
•	ProjectName
Filter all the projects of employee with Id 24. 
If the project has started during or after 2005 the returned value should be NULL
*/
select --top 5 
e.EmployeeID, e.FirstName, 
case
when p.StartDate > Convert(smalldatetime, '1.1.2005', 104) then NULL
else [Name]
END as ProjectName
from Employees e
join EmployeesProjects ep on ep.EmployeeID = e.EmployeeID 
join Projects p on ep.ProjectID = p.ProjectID
where e.EmployeeID = 24

--09. Employee Manager
/*Create a query that selects:
•	EmployeeID
•	FirstName
•	ManagerID
•	ManagerName
Filter all employees with a manager who has ID equals to 3 or 7. 
Return all the rows, sorted by EmployeeID in ascending order.
*/
select e.EmployeeID, e.FirstName, e.ManagerID, ee.FirstName as [ManagerName] from Employees e
join Employees ee on e.ManagerID = ee.EmployeeID
where e.ManagerID in (3, 7)
order by e.EmployeeID

--10. Employees Summary
/*Create a query that selects:
•	EmployeeID
•	EmployeeName
•	ManagerName
•	DepartmentName
Show the first 50 employees with their managers and the departments they are in (show the departments of the employees).
Order them by EmployeeID.
*/
select  top 50 
e.EmployeeID, 
CONCAT(e.FirstName, ' ', e.LastName) as EmployeeName, 
CONCAT(ee.FirstName, ' ', ee.LastName) as [ManagerName], 
d.Name as DepartmentName from Employees e
join Employees ee on e.ManagerID = ee.EmployeeID
join Departments d on e.DepartmentID = d.DepartmentID
order by e.EmployeeID