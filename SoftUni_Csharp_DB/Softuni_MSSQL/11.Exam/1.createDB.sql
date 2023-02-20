create database Boardgames

go

use Boardgames 

go

create table Categories
(
[Id] int Identity primary key not null,
[Name] varchar(50) not null
)

create table Addresses
(
[Id] int Identity primary key not null,
[StreetName] varchar(100) not null,
[StreetNumber] int not null,
[Town] varchar(30) not null,
[Country] varchar(50) not null,
[ZIP] int not null
)

create table Publishers
(
[Id] int Identity primary key not null,
[Name] varchar(30) not null,
[AddressId] int references Addresses([Id]) not null,
[Website] nvarchar(40),
[Phone] nvarchar(20)
)

create table PlayersRanges
(
[Id] int Identity primary key not null,
[PlayersMin] int not null,
[PlayersMax] int not null
)

create table Boardgames
(
[Id] int Identity primary key not null,
[Name] varchar(30) not null,
[YearPublished] int not null,
[Rating] decimal(18,2) not null,
[CategoryId] int references Categories([Id]) not null,
[PublisherId] int references Publishers([Id]) not null,
[PlayersRangeId] int references PlayersRanges([Id]) not null
)

create table Creators
(
[Id] int Identity primary key not null,
[FirstName] varchar(30) not null,
[LastName] varchar(30) not null,
[Email] varchar(30) not null,
)

create table CreatorsBoardgames
(
[CreatorId] int references Creators([Id]) not null,
[BoardgameId] int references Boardgames([Id]) not null,
primary key ([CreatorId], [BoardgameId])
)