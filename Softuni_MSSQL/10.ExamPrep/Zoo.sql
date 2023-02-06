create database Zoo
use Zoo

--create tables

create table Owners
(
[Id] int primary key identity not null,
[Name] varchar(50) not null,
[PhoneNumber] varchar(15) not null,
[Address] varchar(50)
)

create table AnimalTypes
(
[Id] int primary key identity not null,
[AnimalType] varchar(30) not null,
)

create table Cages
(
[Id] int primary key identity not null,
[AnimalTypeId] int foreign key references AnimalTypes(Id) not null
)

create table Animals
(
[Id] int primary key identity not null,
[Name] varchar(30) not null,
[BirthDate] date not null,
[OwnerId] int foreign key references Owners(Id),
[AnimalTypeId] int foreign key references AnimalTypes(Id) not null
)

create table AnimalsCages
(
[CageId] int foreign key references Cages(Id) not null,
[AnimalId] int foreign key references Animals(Id) not null,
primary key ([CageId], [AnimalId])
)

create table VolunteersDepartments
(
[Id] int primary key identity not null,
[DepartmentName] varchar(30) not null,
)

create table Volunteers
(
[Id] int primary key identity not null,
[Name] varchar(50) not null,
[PhoneNumber] varchar(15) not null,
[Address] varchar(50),
[AnimalId] int foreign key references Animals(Id),
[DepartmentId] int foreign key references VolunteersDepartments(Id) not null
)

--2. Insert no
--Let's insert some sample data into the database.
--Write a query to add the following records into the corresponding tables. 
--All Ids should be auto-generated.

insert into Volunteers (Name, PhoneNumber, Address, AnimalId, DepartmentId)
values
('Anita Kostova', '0896365412','Sofia, 5 Rosa str.', 15, 1),
('Dimitur Stoev', '0877564223', null, 42, 4),
('Kalina Evtimova', '0896321112', 'Silistra, 21 Breza str.', 9,	7),
('Stoyan Tomov', '0898564100', 'Montana, 1 Bor str.', 18, 8),
('Boryana Mileva', '0888112233', null, 31, 5)

insert into Animals (Name, BirthDate, OwnerId, AnimalTypeId)
values
('Giraffe', 2018-09-21, 21, 1),
('Harpy Eagle', 2015-04-17, 15, 3),
('Hamadryas Baboon', 2017-11-02, null, 1),
('Tuatara', 2021-06-30, 2, 4)


--3. Update
--Kaloqn Stoqnov (a current owner, present in the database) came to the zoo to adopt all the animals, 
--who don't have an owner. 
--Update the records by putting to those animals the correct OwnerId.
update Animals
set OwnerId = 4
where OwnerId is null

update Animals
set OwnerId = (select Id from Owners where Name = 'Kaloqn Stoqnov')
where OwnerId is null


--4.	Delete
--The Zoo decided to close one of the Volunteers Departments - Education program assistant. 
--Your job is to delete this department from the database. 
--NOTE: Keep in mind that there could be foreign key constraint conflicts!

select * from VolunteersDepartments
select * from Volunteers where DepartmentId = 2

update Volunteers
set DepartmentId = null
where DepartmentId = 2

delete VolunteersDepartments
where Id = 2
and DepartmentName = 'Education program assistant'


/*5.	Volunteers
Extract information about all the Volunteers – name, phone number, address, id of the animal, they are responsible to and id of the department they are involved into.
Order the result by name of the volunteer (ascending), then by the id of the animal (ascending) and then by the id of the department (ascending).
*/

select Name,	PhoneNumber,	Address,	AnimalId,	DepartmentId from Volunteers
order by Name, AnimalId, DepartmentId

/*6.	Animals data
Select all animals and their type. 
Extract name, animal type and birth date (in format 'dd.MM.yyyy'). 
Order the result by animal's name (ascending).
*/

select a.Name, at.AnimalType, format(BirthDate, 'dd.MM.yyyy') as BirthDate from Animals a
join AnimalTypes at on at.Id = a.AnimalTypeId
order by a.Name


/*7. Owners and Their Animals
Extract the animals for each owner. 
Find the top 5 owners, who have the biggest count of animals. 
Select the owner's name and the count of the animals he owns. 
Order the result by the count of animals owned (descending) and then by the owner's name.
*/

select top 5 o.Name as Owner, count(a.Id) as CountOfAnimals from Owners o
join Animals a on a.OwnerId = o.Id
group by o.Name
order by CountOfAnimals desc, o.Name


/*8. Owners, Animals and Cages
Extract information about the owners of mammals, the name of their animal and in which cage these animals are. 
Select owner's name and animal's name (in format 'owner-animal'), owner's phone number and the id of the cage.
Order the result by the name of the owner (ascending) and then by the name of the animal (descending).*/

select concat(o.Name, '-', a.Name) as OwnersAnimals, PhoneNumber, ac.CageId
from Owners o
join Animals a on a.OwnerId = o.Id
join AnimalsCages ac on ac.AnimalId = a.Id
--join Cages c on c.Id = ac.CageId
where a.AnimalTypeId = 1
order by o.Name, a.Name desc

/*9. Volunteers in Sofia
Extract information about the volunteers, involved in 'Education program assistant' department, who live in Sofia. 
Select their name, phone number and their address in Sofia (skip city's name).
Order the result by the name of the volunteers (ascending).
*/

select v.Name, v.PhoneNumber, SUBSTRING(v.Address, CHARINDEX(',', v.Address)+2, len(v.Address)) as Address
from Volunteers v
where DepartmentId = 2
and Address like '%Sofia%'
order by v.Name

/*10. Animals for Adoption
Extract all animals, who does not have an owner and are younger than 5 years (5 years from '01/01/2022'), except for the Birds. 
Select their name, year of birth and animal type.
Order the result by animal's name.
*/

select a.Name, year(BirthDate) as BirthYear, at.AnimalType from Animals a
join AnimalTypes at on at.Id = a.AnimalTypeId
where OwnerId is NULL
and AnimalTypeId <> 3
and 2022 - year(BirthDate) < 5
order by a.Name

/*11. All Volunteers in a Department
Create a user-defined function named udf_GetVolunteersCountFromADepartment (@VolunteersDepartment) that receives a department 
and returns the count of volunteers, 
who are involved in this department.
*/

Create function udf_GetVolunteersCountFromADepartment (@VolunteersDepartment varchar(30))
returns int
as
begin
	return (select count(*) from Volunteers v
	join VolunteersDepartments vd on v.DepartmentId = vd.Id
	where DepartmentName = @VolunteersDepartment)
end


/*12. Animals with Owner or Not
Create a stored procedure, named usp_AnimalsWithOwnersOrNot(@AnimalName). 
Extract the name of the owner of the given animal. If there is no owner, put 'For adoption'.
*/

Create procedure usp_AnimalsWithOwnersOrNot @AnimalName varchar(30)
as
begin
	select a.Name,
case
 when o.Name is Null then 'For adoption'
 else o.Name
end as OwnersName
from Animals a
left join Owners o on o.Id = a.OwnerId
where a.Name = @AnimalName
end
