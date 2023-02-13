--Airport

--create database Airport

use Airport

create table Passengers
(
[Id] int primary key identity not null,
[FullName] varchar(100) unique not null,
[Email] varchar(50) unique not null
)

create table Pilots
(
[Id] int primary key identity not null,
[FirstName] varchar(30) unique not null,
[LastName] varchar(30) unique not null,
[Age] tinyint not null CHECK(Age >= 21 and Age <=62),
[Rating] float  CHECK(Rating >= 0.0 and Rating <=10.0)
)


create table AircraftTypes
(
[Id] int primary key identity not null,
[TypeName] varchar(30) unique not null
)


create table Aircraft
(
[Id] int primary key identity not null,
[Manufacturer] varchar(25) not null,
[Model] varchar(30) not null,
[Year] int not null,
[FlightHours] int,
[Condition] char not null,
[TypeId] int foreign key references AircraftTypes(Id) not null
)

create table PilotsAircraft
(
[AircraftId] int foreign key references Aircraft(Id) not null,
[PilotId] int foreign key references Pilots(Id) not null
primary key ([AircraftId], [PilotId])
)

create table Airports
(
[Id] int primary key identity not null,
[AirportName] varchar(70) unique not null,
[Country] varchar(100) unique not null
)

create table FlightDestinations
(
[Id] int primary key identity not null,
[AirportId] int foreign key references Airports(Id) not null,
[Start] DateTime not null,
[AircraftId] int foreign key references Aircraft(Id) not null,
[PassengerId] int foreign key references Passengers(Id) not null,
[TicketPrice] decimal(18,2) not null default 15
)


SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_CATALOG = DB_NAME()

--02. Insert
/*Write a query to insert data into the Passengers table, based on the Pilots table. 
For all Pilots with an id between 5 and 15 (both inclusive), insert data in the Passengers table with the following values:
FullName  –  get the first and last name of the pilot separated by a single space
Example – 'Lois Leidle'
Email – set it to start with full name with no space and add '@gmail.com' - 'FullName@gmail.com'
Example – 'LoisLeidle@gmail.com'*/

insert into Passengers (FullName, Email)
select concat(FirstName, ' ', LastName), concat(FirstName,LastName,'@gmail.com') from Pilots p 
where p.id>=5 and p.id<=15


--03. Update
/*Update all Aircraft, which:
•	Have a condition of 'C' or 'B' 
•	Have FlightHours Null or up to 100 (inclusive)
•	Have Year after 2013 (inclusive)
 By setting their condition to 'A'.
*/

--select * from Aircraft
--where Condition in ('B', 'C')
--and (FlightHours is null or FlightHours <=100)
--and year >= 2013

update Aircraft
set Condition = 'A'
where Condition in ('B', 'C')
and (FlightHours is null or FlightHours <=100)
and year >= 2013


--04. Delete
/*Delete every passenger whose FullName is up to 10 characters (inclusive) long.*/

delete from Passengers
where len(FullName) <=10


--delete database Airport

--5.	Aircraft
/*Extract information about all the Aircraft. Order the results by aircraft's FlightHours descending.
Required columns:
•	Manufacturer
•	Model
•	FlightHours
•	Condition */

--Manufacturer, Model, FlightHours, Condition

select Manufacturer, Model, FlightHours, Condition from Aircraft
order by FlightHours desc

--06. Pilots and Aircraft
/*Select pilots and aircraft that they operate. 
Extract the pilot's First, Last names, aircraft's Manufacturer, Model, and FlightHours. 
Skip all plains with NULLs and up to 304 FlightHours. 
Order the result by the FlightHours in descending order, then by the pilot's FirstName alphabetically. 
Required columns:
FirstName, LastName, Manufacturer, Model, FlightHours
*/

select p.FirstName, p.LastName, a.Manufacturer, a.Model, a.FlightHours from Pilots p
join PilotsAircraft pa on pa.PilotId = p.Id
join Aircraft a on a.Id = pa.AircraftId
where FlightHours <> null or FlightHours < 304
order by FlightHours desc, FirstName asc

--07. Top 20 Flight Destinations
/*Select top 20  flight destinations, where Start day is an even number. Extract DestinationId, Start date, passenger's FullName, AirportName, and TicketPrice. 
Order the result by TicketPrice descending, then by AirportName ascending.
Required columns:
DestinationId, Start, FullName (passenger), AirportName, TicketPrice
*/

select top 20 f.Id as DestinationId, f.Start, p.FullName, a.AirportName, f.TicketPrice from FlightDestinations f
join Airports a on a.Id = f.AirportId
join Passengers p on p.Id = f.PassengerId
where day(f.Start) % 2 = 0
order by TicketPrice desc, AirportName asc


--8. Number of Flights for Each Aircraft
/*Extract information about all the Aircraft and the count of their FlightDestinations. 
Display average ticket price (AvgPrice) of each flight destination by the Aircraft, rounded to the second digit. 
Take only the aircraft with at least 2  FlightDestinations. 
Order the results by count of flight destinations descending, then by the aircraft's id ascending. 
Required columns:
AircraftId, Manufacturer, FlightHours, FlightDestinationsCount, AvgPrice
*/

select f.AircraftId, Manufacturer, FlightHours, count(airportId) as FlightDestinationsCount, round(avg(TicketPrice), 2) as AvgPrice
from Aircraft a
join FlightDestinations f on f.AircraftId = a.Id
group by f.AircraftId, Manufacturer, FlightHours
having count(airportId) >= 2
order by FlightDestinationsCount desc, f.AircraftId


--9. Regular Passengers
/*Extract all passengers, who have flown in more than one aircraft and have an 'a' as the second letter of their full name. 
Select the full name, the count of aircraft that he/she traveled, and the total sum which was paid.
Order the result by passenger's FullName.
Required columns:
FullName, CountOfAircraft, TotalPayed */

select FullName, count(f.AircraftId) as CountOfAircraft, sum(f.TicketPrice) as TotalPayed
from Passengers p
join FlightDestinations f on p.Id = f.PassengerId
where  FullName like('_a%')
group by FullName
having count(f.AircraftId) > 1
order by FullName

/*10. Full Info for Flight Destinations
Extract information about all flight destinations which Start between hours: 6:00 and 20:00 (both inclusive) and have ticket prices higher than 2500.
Select the airport's name, time of the day,  price of the ticket, passenger's full name, aircraft manufacturer, and aircraft model. Order the result by aircraft model ascending.
Required columns:
AirportName, DayTime, TicketPrice, FullName (passenger), Manufacturer, Model
*/

select ap.AirportName, f.Start as DayTime, f.TicketPrice, p.FullName, a.Manufacturer, Model from Airports ap
join FlightDestinations f on f.AirportId = ap.Id
join Passengers p on p.Id = f.PassengerId
join Aircraft a on a.Id = f.AircraftId 
where TicketPrice > 2500
and DATEPART(HOUR, f.Start) >= 6
and DATEPART(HOUR, f.Start) <= 20
order by Model

--11.	Find all Destinations by Email Address
/*Create a user-defined function named udf_FlightDestinationsByEmail(@email)
that receives a passenger's email address and returns the number of flight destinations that the passenger has in the database.*/

create function udf_FlightDestinationsByEmail (@email varchar(50))
returns int
as
begin
	
	return (select count(AirportId) as 'Output' from Passengers p
	left join FlightDestinations f on f.PassengerId = p.Id
	where email = @email
	group by Email)
end

select dbo.udf_FlightDestinationsByEmail ('Montacute@gmail.com')

--12.	Full Info for Airports
/*Create a stored procedure, named usp_SearchByAirportName, which accepts the following parameters airportName(with max length 70)
Extract information about the airport locations with the given airport name. 
The needed data is the name of the airport, full name of the passenger, level of the ticket price 
(depends on flight destination's ticket price:
'Low'– lower than 400 (inclusive), 
'Medium' – between 401 and 1500 (inclusive), and 
'High' – more than 1501), 
manufacturer and condition of the aircraft, and the name of the aircraft type.
Order the result by Manufacturer, then by passenger's full name.
Required columns:
AirportName, FullName (passenger), LevelOfTickerPrice, Manifacturer, Condition, TypeName (aircraft type)
*/

create procedure usp_SearchByAirportName @airportName varchar(70)
as
begin
select AirportName, FullName,
case
when ticketPrice <= 400 then 'Low'
when ticketPrice <= 1500 then 'Medium'
when ticketPrice > 1500 then 'High'
end as LevelOfTickerPrice,
Manufacturer, Condition, TypeName
from Airports ap
join FlightDestinations f on f.AirportId = ap.Id
join Passengers p on f.PassengerId = p.Id
join Aircraft a on a.Id = f.AircraftId
join AircraftTypes att on a.TypeId = att.Id 
where AirportName = @airportName
order by Manufacturer, FullName
end

exec usp_SearchByAirportName 'Sir Seretse Khama International Airport'

--select AirportName, FullName,
--case
--when ticketPrice <= 400 then 'Low'
--when ticketPrice <= 1500 then 'Medium'
--when ticketPrice > 1500 then 'High'
--end as LevelOfTickerPrice,
--Manufacturer, Condition, TypeName
--from Airports ap
--join FlightDestinations f on f.AirportId = ap.Id
--join Passengers p on f.PassengerId = p.Id
--join Aircraft a on a.Id = f.AircraftId
--join AircraftTypes att on a.TypeId = att.Id 
--where AirportName = ''
