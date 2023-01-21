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

--11. Min Average Salary
--Create a query that returns the value of the lowest average salary of all departments.

SELECT min(à.AverageSalary) AS [MinAverageSalary]
FROM (
       SELECT avg(Salary) AS AverageSalary
       FROM Employees
       GROUP BY DepartmentID
     ) AS à

--12. Highest Peaks in Bulgaria
/*Create a query that selects:
•	CountryCode
•	MountainRange
•	PeakName
•	Elevation
Filter all the peaks in Bulgaria, which have elevation over 2835. Return all the rows, sorted by elevation in descending order.
*/

select mc.CountryCode, m.MountainRange, p.PeakName, p.Elevation from Peaks p
join Mountains m on p.MountainId = m.Id
join MountainsCountries mc on mc.MountainId = m.Id
where mc.CountryCode = 'BG'
and p.Elevation > 2835
order by Elevation desc


--13. Count Mountain Ranges
/*
Create a query that selects:
•	CountryCode
•	MountainRanges
Filter the count of the mountain ranges in the United States, Russia and Bulgaria.
*/
select 
mc.CountryCode, Count(mc.CountryCode) as MountainRanges
from Mountains m 
join MountainsCountries mc on mc.MountainId = m.Id
where mc.CountryCode in('BG', 'US', 'RU')
group by mc.CountryCode

--14. Countries With or Without Rivers
/*Create a query that selects:
•	CountryName
•	RiverName
Find the first 5 countries with or without rivers in Africa. Sort them by CountryName in ascending order.
*/
select top 5 c.CountryName, r.RiverName from Countries c
left join CountriesRivers cr on cr.CountryCode = c.CountryCode
left join Rivers r on r.Id = cr.RiverId
where c.ContinentCode = 'AF'
order by CountryName

--15. Continents and Currencies***
/*Create a query that selects:
•	ContinentCode
•	CurrencyCode
•	CurrencyUsage
Find all continents and their most used currency. 
Filter any currency, which is used in only one country. 
Sort your results by ContinentCode.
*/

SELECT OrderedCurrencies.ContinentCode,
	   OrderedCurrencies.CurrencyCode,
	   OrderedCurrencies.CurrencyUsage
  FROM Continents AS c
  JOIN (
	   SELECT ContinentCode AS [ContinentCode],
	   COUNT(CurrencyCode) AS [CurrencyUsage],
	   CurrencyCode as [CurrencyCode],
	   DENSE_RANK() OVER (PARTITION BY ContinentCode
	                      ORDER BY COUNT(CurrencyCode) DESC
						  ) AS [Rank]
	   FROM Countries
	   GROUP BY ContinentCode, CurrencyCode
	   HAVING COUNT(CurrencyCode) > 1
	   )
	   AS OrderedCurrencies
    ON c.ContinentCode = OrderedCurrencies.ContinentCode
 WHERE OrderedCurrencies.Rank = 1

 --16. Countries Without any Mountains
-- Create a query that returns the count of all countries, which don’t have a mountain.
select * from Countries
select * from [dbo].[MountainsCountries]

select count(*) as 'Count' from Countries c
full outer join MountainsCountries mc on c.CountryCode = mc.CountryCode
where MountainId is null

--17. Highest Peak and Longest River by Country
/*For each country, find the elevation of the highest peak and the length of the longest river, 
sorted by the highest peak elevation (from highest to lowest), 
then by the longest river length (from longest to smallest), 
then by country name (alphabetically). 
Display NULL when no data is available in some of the columns. Limit only the first 5 rows.*/


select top 5 c.CountryName, 
max(p.Elevation) as HighestPeakElevation, 
max(r.[Length]) as LongestRiverLength
from Countries c
left join CountriesRivers cr on cr.CountryCode = c.CountryCode
left join Rivers r on r.Id = cr.RiverId
left join MountainsCountries mc on mc.CountryCode = c.CountryCode
left join Mountains cm on cm.Id = mc.MountainId
left join Peaks p on p.MountainId = cm.Id
group by c.CountryName
order by HighestPeakElevation desc, LongestRiverLength desc, c.CountryName

--18. Highest Peak Name and Elevation by Country
/*For each country, find the name and elevation of the highest peak, 
along with its mountain. 
When no peaks are available in some countries, 
display elevation 0, "(no highest peak)" as peak name and "(no mountain)" 
as a mountain name. When multiple peaks in some countries have the same elevation, 
display all of them. Sort the results by country name alphabetically, 
then by highest peak name alphabetically.
Limit only the first 5 rows.*/
select top 5 Country,
	case 
		when PeakName IS NULL THEN '(no highest peak)'
		else PeakName
	end as [Highest Peak Name],
	case 
		when Elevation IS NULL THEN '0'
		else Elevation
	end as [Highest Peak Elevation],
	case 
		when MountainRange IS NULL THEN '(no mountain)'
		else MountainRange
	end as Mountain
from(
select c.CountryName as Country, p.PeakName, 
p.Elevation,  m.MountainRange,
DENSE_RANK() OVER (PARTITION BY c.CountryName order by p.Elevation desc) as PeakRank
from Countries c
left join MountainsCountries mc on mc.CountryCode = c.CountryCode
left join Mountains m on m.Id = mc.MountainId
left join Peaks p on p.MountainId = m.Id
) as a
where a.PeakRank = 1
order by Country, [Highest Peak Name]