/*10.	Creators by Rating
Select all creators, who have created a boardgame. 
Select their last name, average rating (rounded up to the next biggest integer) and publisher's name. 
Show only the results for creators, whose games are published by "Stonemaier Games". 
Order the results by average rating (descending).
*/
 go

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



select * from [dbo].[Publishers]



go

-------------
/*4.	Delete
In table Addresses, delete every country, which has a Town, starting with the letter 'L'. 
Keep in mind that there could be foreign key constraint conflicts.*/

select * from Addresses where Town like ('L_%')
select * from Publishers where AddressId = 5
select * from Boardgames where PublisherId = 1
select * from CreatorsBoardgames where BoardgameId in (1, 16, 31) or CreatorId in (1, 2, 3, 4, 5)

delete CreatorsBoardgames where BoardgameId in (1, 16, 31) or CreatorId in (1, 2, 3, 4, 5)
delete Boardgames where PublisherId = 1
delete Publishers where AddressId = 5
delete Addresses where Town like ('L_%')