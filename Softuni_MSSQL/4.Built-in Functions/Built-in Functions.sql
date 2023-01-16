/*****Built-in Functions*****/

--01. Find Names of All Employees by First Name
SELECT [FirstName] ,[LastName]      
  FROM Employees
  where [FirstName] like 'Sa%'

--02. Find Names of All Employees by Last Name
SELECT [FirstName] ,[LastName]      
  FROM Employees
  where [LastName] like '%ei%'

--03. Find First Names of All Employees
    SELECT [FirstName] from Employees
  where DepartmentID in (3, 10)
  and Year(HireDate) between '1995' and '2005'

--04. Find All Employees Except Engineers
SELECT [FirstName] ,[LastName]   from Employees
where JobTitle not like '%Engineer%'

--05. Find Towns with Name Length
--Create a SQL query that finds all town names, which are 5 or 6 symbols long. Order the result alphabetically by town name.  
SELECT [Name] from Towns
where LEN([Name]) in (5,6)
order by [Name]

--06. Find Towns Starting With
--Create a SQL query that finds all towns with names starting with 'M', 'K', 'B' or 'E'. Order the result alphabetically by town name. 
SELECT * FROM Towns
where [Name] like 'M%' or [Name] like 'K%' or [Name] like 'B%' or [Name] like 'E%'
order by [Name]


--07. Find Towns Not Starting With
--Create a SQL query that finds all towns, which do not start with 'R', 'B' or 'D'. Order the result alphabetically by name. 
SELECT * FROM Towns
where [Name] not like 'R%' and [Name] not like 'B%' and [Name] not like 'D%'
order by [Name]


--08. Create View Employees Hired After 2000 Year
CREATE VIEW V_EmployeesHiredAfter2000
as
SELECT  [FirstName] ,[LastName] from Employees
where Year(HireDate) > '2000'

--09. Length of Last Name
--Create a SQL query that finds all employees, whose last name is exactly 5 characters long.
SELECT  [FirstName] ,[LastName] from Employees
where LEN([LastName]) = 5

--10. Rank Employees by Salary
SELECT EmployeeID,	FirstName,	LastName,	Salary,	DENSE_RANK() OVER (PARTITION BY Salary order by EmployeeID) AS 'Rank' 
from Employees
where Salary between 10000 and 50000
order by Salary desc

--11. Find All Employees with Rank 2 
SELECT * FROM (SELECT EmployeeID,	FirstName, LastName, Salary, DENSE_RANK() OVER (PARTITION BY Salary order by EmployeeID) AS Rank
from Employees
where Salary between 10000 and 50000) as t1
where t1.Rank = 2
order by Salary desc

--12. Countries Holding 'A' 3 or More Times
--Find all countries which hold the letter 'A' at least 3 times in their name (case-insensitively). Sort the result by ISO code and display the "Country Name" and "ISO Code". 
SELECT [CountryName] as [Country Name], [ISOCode] as [ISO Code]
from Countries
where [CountryName] LIKE '%a%a%a%'
order by [ISO Code]

--13. Mix of Peak and River Names
--Combine all peak names with all river names, so that the last letter of each peak name is the same as the first letter of its corresponding river name. 
--Display the peak names, river names and the obtained mix (mix should be in lowercase). Sort the results by the obtained mix.

SELECT p.PeakName, r.RiverName, 
LOWER(CONCAT(Left(p.PeakName, len(p.PeakName) - 1), r.RiverName)) as MIX
from peaks p, rivers r
where Right(p.PeakName, 1) = Left(r.RiverName, 1)
order by Mix

--14. Games From 2011 and 2012 Year
--Find and display the top 50 games which start date is from 2011 and 2012 year. 
--Order them by start date, then by name of the game. 
--The start date should be in the following format: "yyyy-MM-dd".

select top 50 [Name], format([Start], 'yyyy-MM-dd') as [Start] from Games
where YEAR([Start]) between 2011 and 2012
order by [Start], [Name]


--15. User Email Providers
--Find all users with information about their email providers. 
--Display the username and email provider. 
--Sort the results by email provider alphabetically, then by username. 

select Username, SUBSTRING(Email, CHARINDEX('@', EMAIL)+1, LEN(Email)) as [Email Provider] 
from Users
order by [Email Provider], Username


--16. Get Users with IP Address Like Pattern

select Username, 
IPAddress as [IP Address]
from Users
where IPAddress like ('___.1%.%.___') 
Order By Username

--17. Show All Games with Duration & Part of the Day
/*
Find all games with part of the day and duration. 
Sort them by game name alphabetically, then by duration (alphabetically, not by the timespan) and part of the day (all ascending). 
Part of the Day should be Morning (time is >= 0 and < 12), Afternoon (time is >= 12 and < 18), Evening (time is >= 18 and < 24). 
Duration should be Extra Short (smaller or equal to 3), Short (between 4 and 6 including), Long (greater than 6) and Extra Long (without duration). 
*/
select [Name],
CASE
	WHEN datepart(hh, Start) between 18 and 24 THEN 'Evening'
	WHEN datepart(hh, Start) between 12 and 17 THEN 'Afternoon'
	WHEN datepart(hh, Start) between 0 and 11 THEN 'Morning'
END as [Part of the Day],
CASE
	WHEN Duration <=3 THEN 'Extra Short'
	WHEN Duration between 4 and 6 THEN 'Short'
	WHEN Duration >6 THEN 'Long'
	ELSE 'Extra Long'
END as Duration
 
from Games
order by [Name], Duration,[Part of the Day]

--18. Orders Table
/*
You are given a table Orders(Id, ProductName, OrderDate) filled with data. 
Consider that the payment for that order must be accomplished within 3 days after the order date. 
Also the delivery date is up to 1 month. 
Write a query to show each product's name, order date, pay and deliver due dates. 
*/
--[ProductName] [OrderDate]	[Pay Due]	[Deliver Due]
select
[ProductName]
,[OrderDate] as [OrderDate]
,DATEADD(day, 3, [OrderDate]) as [Pay Due]
--или ,[OrderDate]+3 as [Pay Due]
,DATEADD(month, 1, [OrderDate]) as [Deliver Due]
from Orders


--19. People Table
/*
Create a table People(Id, Name, Birthdate). 
Write a query to find age in years, months, days and minutes for each person for the current time of executing the query.
*/

--CREATE TABLE PEOPLE
--(
--[ID] int primary key IDENTITY(1,1) not null,
--[Name] [varchar](50) NOT NULL,
--[Birthdate] [datetime] NOT NULL
--)

--insert into PEOPLE ([Name], [Birthdate])
--VALUES
--('Victor', '2000-12-07 00:00:00.000') ,
--('Steven', '1992-09-10 00:00:00.000') ,
--('Stephen', '1910-09-19 00:00:00.000') ,
--('John', '2010-01-06 00:00:00.000')


select [Name],
year(GETDATE()) - year(Birthdate) as [Age in Years],
--Age in Years	Age in Months	Age in Days	Age in Minutes
from people


select datediff(yy,Dateofbirthcol,current_date()) As Age