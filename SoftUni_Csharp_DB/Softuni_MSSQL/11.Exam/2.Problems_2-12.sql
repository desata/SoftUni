--2.	Insert

insert into Boardgames (Name, YearPublished, Rating, CategoryId, PublisherId, PlayersRangeId)
values
('Deep Blue', 2019, 5.67, 1, 15, 7),
('Paris', 2016, 9.78, 7, 1, 5),
('Catan: Starfarers', 2021, 9.87, 7, 13, 6),
('Bleeding Kansas', 2020, 3.25, 3, 7, 4),
('One Small Step', 2019, 5.75, 5, 9,  2)

insert into Publishers (Name, AddressId, Website, Phone)
values
('Agman Games', 5, 'www.agmangames.com', '+16546135542'),
('Amethyst Games', 7,'www.amethystgames.com', '+15558889992'),
('BattleBooks', 13, 'www.battlebooks.com', '+12345678907')



-- 03 
/*We've decided to increase the maximum count of players for the boardgames with 1. 
Update the table PlayersRanges and increase the maximum players of the boardgames, which have a range of players [2,2].
Also, you have to change the name of the boardgames that were issued after 2020 inclusive. 
You have to add "V2" to the end of their names.*/

select * from PlayersRanges pr
join Boardgames b on pr.Id = b.PlayersRangeId

update PlayersRanges
set PlayersMax = PlayersMax+1
where PlayersMax = 2 and PlayersMin = 2

update Boardgames
set Name = Name+'V2'
where YearPublished >= 2020

--4.	Delete
/*In table Addresses, delete every country, which has a Town, starting with the letter 'L'. 
Keep in mind that there could be foreign key constraint conflicts. */

delete CreatorsBoardgames where BoardgameId in (1, 16, 31) or CreatorId in (1, 2, 3, 4, 5)
delete Boardgames where PublisherId = 1
delete Publishers where AddressId = 5
delete Addresses where Town like ('L_%')

--05.	Boardgames by Year of Publication
/*Select all boardgames, ordered by year of publication (ascending), then by name (descending). 
Required columns:
•	Name
•	Rating */

select Name, Rating from Boardgames 
order by YearPublished asc, [Name] desc


--6.	Boardgames by Category
/*Select all boardgames with "Strategy Games" or "Wargames" categories. Order results by YearPublished (descending).
Required columns:
•	Id
•	Name
•	YearPublished
•	CategoryName*/

select b.Id, b.Name, b.YearPublished, c.Name from Boardgames b
join Categories c on c.Id = b.CategoryId
where c.Name in ('Strategy Games', 'Wargames')
order by YearPublished desc


----7.	Creators without Boardgames
/*Select all creators without boardgames. Order them by name (ascending).
Required columns:
•	Id
•	CreatorName (creators's first and last name, concatenated with space)
•	Email*/

select id, CONCAT(FirstName, + ' ', + LastName) as CreatorName, Email  from Creators c
left join CreatorsBoardgames b on c.Id = b.CreatorId
where b.CreatorId is NULL


--8.	First 5 Boardgames
/*
Select the first 5 boardgames that have rating, bigger than 7.00 
and containing the letter 'a' in the boardgame name 
or the rating of a boardgame is bigger than 7.50 and the range of the min and max count of players is [2;5].
Order the result by boardgames name (ascending), then by rating (descending).
Required columns:
•	Name
•	Rating
•	CategoryName*/

select top 5 b.Name, Rating, c.Name from Boardgames b
join PlayersRanges p on b.PlayersRangeId = p.Id
join Categories c on c.Id = b.CategoryId
where (b.rating > 7.0 and b.Name like '%a%') or (b.rating > 7.5 and (p.PlayersMin = 2 and p.PlayersMax = 5))
order by b.Name, Rating desc

--9.	Creators with Emails
/*Select all of the creators that have emails, ending in ".com", and display their most highly rated boardgame.
Order by creator full name (ascending).
Required columns:
•	FullName
•	Email
•	Rating*/

use Boardgames

select FullName, email, Rating from (
select CONCAT(FirstName, + ' ', + LastName) as FullName, email, Rating, RANK() OVER(PARTITION BY FirstName ORDER BY rating DESC) ranking from creators c
join CreatorsBoardgames cb on cb.creatorId = c.Id
join Boardgames b on b.Id = cb.BoardgameId
where right(c.Email, 4) = '.com'
) as a
where a.ranking = 1
order by FullName

--10.	Creators by Rating
/*Select all creators, who have created a boardgame. 
Select their last name, average rating (rounded up to the next biggest integer) and publisher's name. 
Show only the results for creators, whose games are published by "Stonemaier Games". 
Order the results by average rating (descending).*/

select c.LastName,
ceiling(avg(Rating)) as AverageRating,
p.Name as PublisherName 
from creators c
join CreatorsBoardgames cb on cb.CreatorId = c.Id
join Boardgames b on b.Id = cb.BoardgameId
join Publishers p on p.Id = b.PublisherId
group by c.LastName, p.Name
having p.name = 'Stonemaier Games'
order by avg(Rating) desc

/**11.	Creator with Boardgames
Create a user-defined function, named udf_CreatorWithBoardgames(@name) that receives a creator's first name.
The function should return the total number of boardgames that the creator has created.
*/

create or alter function udf_CreatorWithBoardgames (@name varchar(30))
returns int
as begin 
		declare @boardgamesCount int =
		(select count(*) from creators c
join creatorsBoardgames cb on c.Id = cb.creatorId
join Boardgames b on cb.boardgameId = b.Id
where c.FirstName = @name )
		return @boardgamesCount
end

select dbo.udf_CreatorWithBoardgames('Bruno')

select count(*) from creators c
join creatorsBoardgames cb on c.Id = cb.creatorId
join Boardgames b on cb.boardgameId = b.Id
where c.FirstName = 'Bruno'

go

/*12. Search for Boardgame with Specific Category
Create a stored procedure, named usp_SearchByCategory(@category) that receives category. 
The procedure must print full information about all boardgames with the given category: 
Name, YearPublished, Rating, CategoryName, PublisherName, MinPlayers and MaxPlayers. 
Add " people" at the end of the min and max count of people. 
Order them by PublisherName (ascending) and YearPublished (descending).
*/

create proc usp_SearchByCategory @category varchar(50)
as
begin 
	select 
b.Name, b.YearPublished, b.Rating, c.Name as CategoryName, p.Name as PublisherName, concat(pr.PlayersMin, ' ', 'people') as MinPlayers, concat(pr.PlayersMax, ' ', 'people') as MaxPlayers
from Boardgames b
join Categories c on c.Id = b.CategoryId
join Publishers p on p.Id = b.PublisherId
join PlayersRanges pr on pr.Id = b.PlayersRangeId
where c.Name = @category
order by PublisherName, YearPublished desc
end

select 
b.Name, b.YearPublished, b.Rating, c.Name as CategoryName, p.Name as PublisherName, concat(pr.PlayersMin, ' ', 'people') as MinPlayers, concat(pr.PlayersMax, ' ', 'people') as MaxPlayers
from Boardgames b
join Categories c on c.Id = b.CategoryId
join Publishers p on p.Id = b.PublisherId
join PlayersRanges pr on pr.Id = b.PlayersRangeId
where c.Name = @category
order by PublisherName, YearPublished desc

EXEC usp_SearchByCategory 'Wargames'