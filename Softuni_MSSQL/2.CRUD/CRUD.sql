/******CRUD******/

--02. Find All Information About Departments
select * from Departments;

--03. Find all Department Names
SELECT [Name] FROM Departments

--04. Find Salary of Each Employee
SELECT [FirstName]
      ,[LastName]      
      ,[Salary]
  FROM Employees

--05. Find Full Name of Each Employee
SELECT [FirstName]
      ,[MiddleName]
      ,[LastName]
  FROM Employees

--06. Find Email Address of Each Employee
  SELECT FirstName+'.'+LastName+'@softuni.bg' as [Full Email Address]
FROM Employees

--07. Find All Different Employee’s Salaries
select distinct Salary from Employees

--08. Find all Information About Employees
select * from Employees
where JobTitle = 'Sales Representative'

--09. Find Names of All Employees by Salary in Range
  select [FirstName]
      ,[LastName]
      ,[JobTitle]  from Employees
where salary between 20000 and 30000

--10. Find Names of All Employees
SELECT FirstName+' '+MiddleName+' '+LastName as [Full Name] from Employees
where salary in (25000, 14000, 12500, 23600)

--11. Find All Employees Without Manager
select [FirstName]
      ,[LastName]
      --,[JobTitle]  
from Employees
where ManagerID is NULL

--12. Find All Employees with Salary More Than
select FirstName, LastName, Salary 
from Employees
where salary > 50000
order by salary desc

--13. Find 5 Best Paid Employees
select top 5 FirstName, LastName
from Employees
order by salary desc

--14. Find All Employees Except Marketing
select [FirstName]
      ,[LastName] 
from Employees
where [DepartmentID] != 4

--15. Sort Employees Table
select * from Employees
order by salary desc, FirstName, LastName desc, MiddleName

--16. Create View Employees with Salaries
  CREATE VIEW V_EmployeesSalaries AS
 select FirstName, LastName, Salary
 from Employees

 --17. Create View Employees with Job Titles
  CREATE VIEW V_EmployeeNameJobTitle AS
 select CONCAT(FirstName, ' ', MiddleName, ' ', LastName) AS 'Full Name',
 JobTitle as 'Job Title'
 from Employees

 --18. Distinct Job Titles
 select distinct JobTitle from Employees

 --19. Find First 10 Started Projects
  select top 10 * from Projects
 order by StartDate, [Name]

 --20. Last 7 Hired Employees
  select top 7 FirstName, LastName, HireDate from Employees
 order by HireDate desc

 --21. Increase Salaries
 update employees
set Salary = (Salary*1.12)
where DepartmentID in (1, 2, 4, 11)
select Salary from Employees

--22. All Mountain Peaks
select peakName from Peaks order by PeakName

--23. Biggest Countries by Population
select top 30 CountryName, [Population] from Countries 
where ContinentCode = 'EU'
order by [Population] desc, CountryName asc

--24. Countries and Currency (Euro / Not Euro)
select CountryName, CountryCode,-- CurrencyCode,
CASE
	WHEN CurrencyCode = 'EUR' THEN 'Euro'
	ELSE 'Not Euro' 
END AS Currency
from Countries 
order by CountryName

--25. All Diablo Characters
SELECT [Name]
 from Characters
 order by [Name]

