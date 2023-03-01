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