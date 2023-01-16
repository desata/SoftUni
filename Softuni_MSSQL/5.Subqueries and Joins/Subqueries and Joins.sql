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
