--100 National Tourist Sites of Bulgaria

--Section 1. DDL (30 pts)
create database NationalTouristSitesOfBulgaria

create table Categories
(
[Id] int primary key identity,
[Name] varchar(50) not null
)

create table Locations
(
[Id] int primary key identity,
[Name] varchar(50) not null,
[Municipality] varchar(50),
[Province] varchar(50)
)

create table Sites
(
[Id] int primary key identity,
[Name] varchar(100) not null,
[LocationId] int foreign key references Locations([Id]) not null,
[CategoryId] int foreign key references Categories([Id]) not null,
[Establishment] varchar(15)
)

create table Tourists
(
[Id] int primary key identity,
[Name] varchar(50) not null,
[Age] int not null,
CONSTRAINT CHK_Tourists CHECK (Age>=0 AND Age<=120),
[PhoneNumber] varchar(20) not null,
[Nationality] varchar(30) not null,
[Reward] varchar(20),
)

create table SitesTourists
(
[TouristId] int foreign key references Tourists([Id]) not null,
[SiteId] int foreign key references Sites([Id]) not null,
CONSTRAINT PK_SitesTourists PRIMARY KEY (TouristId, SiteId)
)

create table BonusPrizes
(
[Id] int primary key identity,
[Name] varchar(50) not null,
)

create table TouristsBonusPrizes
(
[TouristId] int foreign key references Tourists([Id]) not null,
[BonusPrizeId] int foreign key references BonusPrizes([Id]) not null,
CONSTRAINT PK_TouristsBonusPrizes PRIMARY KEY (TouristId, BonusPrizeId)
)

--Section 2. DML (10 pts)
--Tourists
insert into Tourists (Name, Age, PhoneNumber, Nationality, Reward)
values
('Borislava Kazakova', 52, '+359896354244', 'Bulgaria', NULL),
('Peter Bosh', 48, '+447911844141', 'UK', NULL),
('Martin Smith', 29, '+353863818592', 'Ireland', 'Bronze badge'),
('Svilen Dobrev', 49, '+359986584786', 'Bulgaria', 'Silver badge'),
('Kremena Popova', 38, '+359893298604', 'Bulgaria', NULL)

insert into Sites (Name, LocationId, CategoryId, Establishment)
values
('Ustra fortress', 90, 7, 'X'),
('Karlanovo Pyramids', 65, 7, NULL),
('The Tomb of Tsar Sevt', 63, 8, 'V BC'),
('Sinite Kamani Natural Park', 17, 1, NULL),
('St. Petka of Bulgaria – Rupite', 92, 6, '1994')

--03. Update
--For some of the tourist sites there are no clear records when they were established, so you need to update the column 'Establishment' for those records by putting the text '(not defined)'.

--select * from Sites where Establishment is NULL --26rows

update Sites
set Establishment = '(not defined)'
where Establishment is NULL

--04. Delete
--For this year's raffle it was decided to remove the Sleeping bag from the bonus prizes.

delete 
from [TouristsBonusPrizes]
where BonusPrizeId = (select Id from BonusPrizes where Name = 'Sleeping bag')

delete from BonusPrizes where Name = 'Sleeping bag'

-- drop database NationalTouristSitesOfBulgaria

--05. Tourists
/*Extract information about all the Tourists – name, age, phone number and nationality. 
Order the result by nationality (ascending), then by age (descending), and then by tourist name (ascending).*/
--Name	Age	PhoneNumber	Nationality

select Name, Age, PhoneNumber, Nationality from Tourists
order by Nationality, Age desc, Name asc

--6. Sites with Their Location and Category
/*Select all sites and find their location and category. 
Select the name of the tourist site, name of the location,  establishment year/ century and name of the category. 
Order the result by name of the category (descending), then by name of the location (ascending) and then by name of the site itself (ascending).*/
--Site	Location	Establishment	Category

select s.Name, l.Name, s.Establishment, c.Name from Sites s
join Locations l on l.Id = s.LocationId
join Categories c on c.Id = s.CategoryId
order by c.Name desc, l.Name asc, s.Name

--07. Count of Sites in Sofia Province
/*Extract all locations which are in Sofia province. Find the count of sites in every location. 
Select the name of the province, name of the municipality, name of the location and count of the tourist sites in it.
Order the result by count of tourist sites (descending) and then by name of the location (ascending).*/
--Province	Municipality	Location	CountOfSites

select Province,	Municipality,	l.Name as Location, count(s.LocationId) as CountOfSites 
from Locations l 
join Sites s on l.Id = s.LocationId
group by Province,	Municipality,	l.Name
having l.Province = 'Sofia'
order by count(s.LocationId) desc, l.Name asc

--08. Tourist Sites established BC
/*Extract information about the tourist sites, which have a location name that does NOT start with the letters 'B', 'M' or 'D' and which are established Before Christ (BC).
Select the site name, location name, municipality, province and establishment. 
Order the result by name of the site (ascending).
NOTE: If the establishment century is Before Christ (BC), it will always be in the following format: 'RomanNumeral BC'.
*/

select s.Name as Site, l.Name as	Location, l.Municipality, l.Province, Establishment from Sites s
join Locations l on l.Id = s.LocationId
where Establishment like '%BC'
and s.Name not like 'M%'
and s.Name not like'D%'
and s.Name not like 'B%'
order by 1

--9. Tourists with their Bonus Prizes
/*Extract information about the tourists, along with their bonus prizes. 
If there is no data for the bonus prize put '(no bonus prize)'. 
Select tourist's name, age, phone number, nationality and bonus prize. 
Order the result by the name of the tourist (ascending).
NOTE: There will never be a tourist with more than one prize.*/
--Name	Age	PhoneNumber	Nationality	Reward

select t.Name, t.Age, t.PhoneNumber, t.Nationality, 
case
	when bp.Name is NULL then '(no bonus prize)'
	else bp.Name
end
as Reward 
from Tourists t
left join TouristsBonusPrizes tbp on t.Id = tbp.TouristId
left join BonusPrizes bp on bp.Id = tbp.BonusPrizeId
order by t.Name

--10. Tourists visiting History and Archaeology sites
/*Extract all tourists, who have visited sites from category 'History and archaeology'. 
Select their last name, nationality, age and phone number. 
Order the result by their last name (ascending).
NOTE: The name of the tourists will always be in the following format: 'FirstName LastName'.*/
--LastName	Nationality	Age	PhoneNumber

select distinct SUBSTRING(t.Name, CHARINDEX(' ', t.Name)+1, len(t.Name)) as LastName, Nationality , Age, PhoneNumber from Tourists t
join SitesTourists st on t.Id = st.TouristId
join Sites s on st.SiteId = s.Id
join Categories c on c.Id = s.CategoryId
where c.Name = 'History and archaeology'
order by LastName

--11. Tourists Count on a Tourist Site
/*Create a user-defined function named udf_GetTouristsCountOnATouristSite (@Site) which receives a tourist site and returns the count of tourists, who have visited it.*/


create function udf_GetTouristsCountOnATouristSite (@Site varchar(100))
returns int
as begin
	declare @TouristsCount int = (
select count(s.Name) from Tourists t
join SitesTourists st on t.Id = st.TouristId
join Sites s on st.SiteId = s.Id
group by s.Name 
having s.Name = @Site )
return @TouristsCount
end

SELECT dbo.udf_GetTouristsCountOnATouristSite ('Regional History Museum – Vratsa')
SELECT dbo.udf_GetTouristsCountOnATouristSite ('Samuil’s Fortress')
SELECT dbo.udf_GetTouristsCountOnATouristSite ('Gorge of Erma River')


--12.	Annual Reward Lottery
/*A reward scheme has been developed to encourage collection of as many stamps as possible. 
Depending on the number of stamps collected, participants may receive bronze, silver or gold badges. 
Create a stored procedure, named usp_AnnualRewardLottery(@TouristName). 
Update the reward of the given tourist according to the count of the sites he have visited:
>= 100 receives 'Gold badge'
>= 50 receives 'Silver badge'
>= 25 receives 'Bronze badge'
Extract the name of the tourist and the reward he has.*/
go 

create proc usp_AnnualRewardLottery @TouristName varchar(50)
as
begin 
select t.Name, 
case 
when count(*) >= 100 then 'Gold badge'
when count(*) >= 50 then 'Silver badge'
when count(*) >= 25 then 'Bronze badge'
else Reward
end as Reward
from Tourists t
join SitesTourists st on t.Id = st.TouristId
group by t.Name, t.Reward
having t.Name = @TouristName
end

go


EXEC usp_AnnualRewardLottery 'Gerhild Lutgard'
EXEC usp_AnnualRewardLottery 'Teodor Petrov'
EXEC usp_AnnualRewardLottery 'Zac Walsh'
EXEC usp_AnnualRewardLottery 'Brus Brown'