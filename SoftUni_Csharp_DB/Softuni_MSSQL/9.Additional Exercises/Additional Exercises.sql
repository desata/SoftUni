--1. Number of Users for Email Provider
--Find number of users for email provider from the largest to smallest, then by Email Provider in ascending order. 

select * from Users
select * from [dbo].[UsersGames]

select * from (
select 
SUBSTRING(Email, CHARINDEX('@', EMAIL)+1, LEN(Email)) as [Email Provider],
count(*) as [Number Of Users]
from Users
group by SUBSTRING(Email, CHARINDEX('@', EMAIL)+1, LEN(Email))
) a 
order by [Number Of Users] desc, [Email Provider] asc

--2. All User in Games
--Find all user in games with information about them. 
--Display the game name, game type, username, level, cash and character name. 
--Sort the result by level in descending order, then by username and game in alphabetical order. 
--Submit your query statement as Prepare DB & run queries in Judge.

select
g.Name as Game, gt.Name as 'Game Type', u.Username, ug.Level, ug.Cash, c.Name
from games g
join GameTypes gt on g.GameTypeId = gt.Id
join UsersGames ug on ug.GameId = g.Id
join Users u on ug.UserId = u.Id
join Characters c on c.Id = ug.CharacterId
order by ug.Level desc, u.Username asc, g.Name asc

--3.	Users in Games with Their Items
/*Find all users in games with their items count and items price. 
Display the username, game name, items count and items price. 
Display only user in games with items count more or equal to 10. 
Sort the results by items count in descending order, then by price in descending order, and by username in ascending order. 
Submit your query statement as Prepare DB & run queries in Judge.*/

select
u.Username, g.Name as Game, count(i.Id) as 'Items Count', sum(i.Price) as 'Items Price'
from games g
join UsersGames ug on ug.GameId = g.Id
join Users u on ug.UserId = u.Id
join GameTypes gt on g.GameTypeId = gt.Id
join UserGameItems ugi on ugi.UserGameId = gt.Id
join Items i on i.Id = ugi.ItemId
group by u.Username, g.Name
having count(i.Id) >=10
order by count(i.Id) desc, sum(i.Price) desc, u.Username asc


select u.Username, g.Name as 'Game'
, i.Name, i.Price 
from Users u
join UsersGames ug on ug.UserId = u.Id
join Games g on g.Id = ug.GameId
join UserGameItems gi on ug.Id = gi.UserGameId
join items i on gi.ItemId = i.Id
order by u.Username, g.Name

select u.Username, g.Name as 'Game', count(i.Name) as 'Items Count', sum(i.Price) as 'Items Price'
from Users u
join UsersGames ug on ug.UserId = u.Id
join Games g on g.Id = ug.GameId
join UserGameItems gi on ug.Id = gi.UserGameId
join items i on gi.ItemId = i.Id
group by u.Username, g.Name
having count(i.Name) >= 10
order by count(i.Name) desc, sum(i.Price) desc, u.Username asc

--04. *User in Games with Their Statistics

--TODO

--05. All Items with Greater than Average Statistics
select i.Name,	Price,	MinLevel,	Strength,	Defence,	Speed,	Luck,	Mind from [Items] i
join [Statistics] s on s.Id = i.StatisticId
where (Mind > 9 and Luck > 9 and Speed > 9)

--06. Display All Items about Forbidden Game Type
select i.Name as Item, Price, MinLevel, g.Name as [Forbidden Game Type] from Items i
left outer join GameTypeForbiddenItems gt on i.Id = gt.ItemId
left outer join GameTypes g on g.Id = gt.GameTypeId
order by g.Name desc, i.Name

--7. Buy Items for User in Game
/*
User Alex is in the shop of the game "Edinburgh" and she wants to buy some items. 
She likes Blackguard, Bottomless Potion of Amplification, Eye of Etlich (Diablo III), Gem of Efficacious Toxin, Golden Gorget of Leoric and Hellfire Amulet.
Buy the items. 
You should add the data in the right tables. 
Get the money for the items from the user in column Cash.
Select all users in the current game with their items. 
Display username, game name, cash and item name. 
Sort the result by item name.
Submit your query statements as Prepare DB & run queries in Judge.
*/

DECLARE @USERID INT= (SELECT Id
                      FROM Users
                      WHERE Username = 'Alex');

DECLARE @GAMEID INT= (SELECT Id
                      FROM Games
                      WHERE Name = 'Edinburgh');

DECLARE @UGID INT= (SELECT Id
                    FROM UsersGames
                    WHERE UserId = @USERID
                      AND GameId = @GAMEID);

UPDATE UsersGames
SET Cash-=(SELECT SUM(I.Price)
FROM Items AS I
WHERE I.Name IN ('Blackguard', 'Bottomless Potion of Amplification',
                 'Eye of Etlich (Diablo III)', 'Gem of Efficacious Toxin',
                 'Golden Gorget of Leoric', 'Hellfire Amulet'))
WHERE Id = @UGID;

INSERT INTO UserGameItems(ItemId, UserGameId)
VALUES
((SELECT Id FROM Items WHERE Name = 'Blackguard'), @UGID),
((SELECT Id FROM Items WHERE Name='Bottomless Potion of Amplification'),@UGID ),
((SELECT Id FROM Items WHERE Name='Eye of Etlich (Diablo III)'),@UGID ),
((SELECT Id FROM Items WHERE Name='Gem of Efficacious Toxin'),@UGID ),
((SELECT Id FROM Items WHERE Name='Golden Gorget of Leoric'),@UGID ),
((SELECT Id FROM Items WHERE Name='Hellfire Amulet'),@UGID )

SELECT U.Username, G.Name, UG.Cash, I.Name
FROM Users AS U
JOIN UsersGames UG on U.Id = UG.UserId
JOIN Games G on G.Id = UG.GameId
JOIN UserGameItems UGI on UG.Id = UGI.UserGameId
JOIN Items I on I.Id = UGI.ItemId
WHERE G.Name = 'Edinburgh'
ORDER BY I.Name
