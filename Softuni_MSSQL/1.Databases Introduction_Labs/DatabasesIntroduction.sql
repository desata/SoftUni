/******Databases Introduction******/

--04. Insert Records in Both Tables
INSERT INTO [Towns]([Id], [Name])
  VALUES
  (1, 'Sofia'),
  (2, 'Plovdiv'),
  (3, 'Varna')

INSERT INTO [Minions]([Id], [Name], [Age], [TownId])
  VALUES
  (1, 'Kevin', 22, 1),
  (2, 'Bob', 15, 3),
  (3, 'Steward', NULL, 2)


--07. Create Table People
CREATE TABLE [People]
(
[Id] INT PRIMARY KEY IDENTITY NOT NULL,
[Name] nvarchar(200) NOT NULL,
[Picture] VARBINARY(MAX),
CHECK (DATALENGTH([Picture]) <= 2000000),
[Height] DECIMAL(3,2),
[Weight] DECIMAL(5,2),
[Gender] char(1) NOT NULL,
CHECK ([Gender] = 'm' OR [Gender] = 'f'),
[Birthdate] DATE NOT NULL,
[Biography] nvarchar(MAX)
)

INSERT INTO [People] ([Name],[Height],[Weight],[Gender],[Birthdate])
VALUES
('Alek', 1.87, 90, 'm', '01.01.2000'),
('Marti', 1.67, 70, 'm', '01.01.2000'),
('Stef', 1.77, 80.7, 'm', '01.01.2000'),
('Fil', 1.87, 89, 'm', '01.01.2000'),
('Roni', 1.73, 62, 'f', '01.01.2000')


--08. Create Table Users
CREATE TABLE [Users]
(
[Id] BIGINT PRIMARY KEY IDENTITY NOT NULL,
[Username] nvarchar(30) NOT NULL UNIQUE,
[Password] nvarchar(26) NOT NULL,
[ProfilePicture] VARBINARY(MAX),
CHECK (DATALENGTH([ProfilePicture]) <= 900000),
[LastLoginTime] datetime2 NOT NULL,
[IsDeleted] char(5)
CHECK ([IsDeleted] = 'true' OR [IsDeleted] = 'false'),
)

INSERT INTO [Users] ([Username], [Password], [LastLoginTime], [IsDeleted])
VALUES
('aL3kA', '112233', SYSDATETIME(), 'false' ),
('f1l1p40', '112233', SYSDATETIME(), 'false' ),
('stek40', '112233', SYSDATETIME(), 'false' ),
('r0nka7a', '112233', SYSDATETIME(), 'false' ),
('mty', '112233', SYSDATETIME(), 'true' )


--13. Movies Database
--Directors (Id, DirectorName, Notes)
CREATE TABLE [Directors]
(
[Id] BIGINT PRIMARY KEY IDENTITY NOT NULL,
[DirectorName] nvarchar(200) NOT NULL,
[Notes] nvarchar(MAX)
)

--Genres (Id, GenreName, Notes)
CREATE TABLE [Genres]
(
[Id] INT PRIMARY KEY IDENTITY NOT NULL,
[GenreName] nvarchar(200) NOT NULL,
[Notes] nvarchar(MAX)
)

--Categories (Id, CategoryName, Notes)
CREATE TABLE [Categories]
(
[Id] INT PRIMARY KEY IDENTITY NOT NULL,
[CategorieName] nvarchar(200) NOT NULL,
[Notes] nvarchar(MAX)
)

--Movies (Id, Title, DirectorId, CopyrightYear, Length, GenreId, CategoryId, Rating, Notes)
CREATE TABLE [Movies]
(
[Id] BIGINT PRIMARY KEY IDENTITY NOT NULL,
[Title] nvarchar(MAX) NOT NULL,
[DirectorId] BIGINT FOREIGN KEY REFERENCES Directors(Id) NOT NULL,
[CopyrightYear] DATE,
[Length] INT,
[GenreId] INT FOREIGN KEY REFERENCES Genres(Id) NOT NULL,
[CategoryId] INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
[Rating] INT,
[Notes] nvarchar(MAX)
)

INSERT INTO [Directors] ([DirectorName])
VALUES
('Martin Scorsese'),
('Steven Spielberg'),
('Stanley Kubrick'),
('Francis Ford Coppola'),
('Quentin Tarantino')

INSERT INTO [Genres] ([GenreName])
VALUES
('Drama'),
('Crime'),
('Comedy'),
('Animation'),
('Sci-Fi')

INSERT INTO Categories ([CategorieName])
VALUES
('Kids'),
('Family'),
('Christmas'),
('16+'),
('Series')

INSERT INTO Movies ([Title], [DirectorId], [Length], [GenreId], [CategoryId])
VALUES
('Goodfellas', 1, 100, 2, 4),
('Polar express', 2, 105, 4, 3),
('The Godfather', 5, 148, 1, 2),
('The Lord of the Rings', 4, 204, 5, 2),
('WALL·E', 5, 120, 4, 1)


--14. Car Rental Database
--Categories (Id, CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)

CREATE TABLE [Categories]
(
[Id] BIGINT PRIMARY KEY IDENTITY NOT NULL,
[CategoryName] nvarchar(200) NOT NULL, 
[DailyRate] DECIMAL(5,2) not null, 
[WeeklyRate] DECIMAL(5,2) not null, 
[MonthlyRate] DECIMAL(5,2) not null, 
[WeekendRate] DECIMAL(5,2) not null
)

 --Cars (Id, PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available)
CREATE TABLE [Cars]
(
[Id] BIGINT PRIMARY KEY IDENTITY NOT NULL,
[PlateNumber] nvarchar(10) NOT NULL,
[Manufacturer] nvarchar(50) NOT NULL,
[Model] nvarchar(50) NOT NULL,
[CarYear] int  NOT NULL,
CONSTRAINT CH_Cars CHECK (LEN([CarYear]) = 4),
[CategoryId] BIGINT FOREIGN KEY REFERENCES Categories(Id)  NOT NULL,
[Doors] int  NOT NULL
CONSTRAINT CH_Cars_Doors CHECK ([Doors] >= 2 and [Doors] <=5),
[Picture] VARBINARY(MAX),
[Condition] nvarchar(50),
[Available] char(5) NOT NULL
CHECK ([Available] = 'true' OR [Available] = 'false')
)

--Employees (Id, FirstName, LastName, Title, Notes)
CREATE TABLE [Employees]
(
[Id] BIGINT PRIMARY KEY IDENTITY NOT NULL,
[FirstName] nvarchar(50) NOT NULL,
[LastName] nvarchar(50) NOT NULL,
[Title] nvarchar(50) NOT NULL,
[Notes] nvarchar(MAX)
)

--Customers (Id, DriverLicenceNumber, FullName, Address, City, ZIPCode, Notes)
CREATE TABLE [Customers]
(
[Id] BIGINT PRIMARY KEY IDENTITY NOT NULL,
[DriverLicenceNumber] nvarchar(50) NOT NULL,
[FullName] nvarchar(200) NOT NULL,
[Address] nvarchar(200) NOT NULL,
[City] nvarchar(150) NOT NULL,
[ZIPCode] nvarchar(10) NOT NULL,
[Notes] nvarchar(MAX)
)

--RentalOrders (Id, EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes)
CREATE TABLE [RentalOrders]
(
[Id] BIGINT PRIMARY KEY IDENTITY NOT NULL,
[EmployeeId] BIGINT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
[CustomerId] BIGINT FOREIGN KEY REFERENCES Customers(Id) NOT NULL,
[CarId] BIGINT FOREIGN KEY REFERENCES Cars(Id) NOT NULL,
[TankLevel] int,
[KilometrageStart] int NOT NULL,
[KilometrageEnd] int,
[TotalKilometrage] int,
[StartDate] date not null,
[EndDate] date not null,
[TotalDays] int not null,
[RateApplied] nvarchar(150) NOT NULL,
[TaxRate] DECIMAL(3,2) not null,
[OrderStatus] nvarchar(200) NOT NULL,
[Notes] nvarchar(MAX)
)

--Set most appropriate data types for each column. Set primary key to each table. Populate each table with only 3 records. 
--Make sure the columns that are present in 2 tables would be of the same data type. 
--Consider which fields are always required and which are optional. 
--Submit your CREATE TABLE and INSERT statements as Run queries & check DB.

INSERT INTO [Categories] ([CategoryName], [DailyRate], [WeeklyRate], [MonthlyRate], [WeekendRate])
VALUES
('van', 15.70, 50, 150, 20),
('suv', 20, 60, 200.54, 30),
('sedan', 10, 30.12, 100, 15)

INSERT INTO [Cars] (PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Available)
VALUES
('AF1221AF', 'Fiat', 'Doblo', 1998, 1, 3, 'true' ),
('AS1221AS', 'Skoda', 'Superb', 2020, 3, 5, 'true' ),
('AV1221AW', 'VW', 'T-Roc', 2020, 2, 5, 'false' )

INSERT INTO [Employees] (FirstName, LastName, Title)
VALUES
('John', 'Doe', 'CEO'),
('Jean', 'Martin', 'Teller-Seller'),
('Sean', 'Bean', 'Cleaner')

INSERT INTO [Customers] (DriverLicenceNumber, FullName, [Address], City, ZIPCode)
VALUES
('LZ1234', 'Peter Parker', '32, Park Ave.', 'NY', '12NY123'),
('ALPHA2', 'Nathaly Barlow', '2, Maddison Ave.', 'Chicago', 'C76543AA'),
('123654', 'Sofia Ronn', '976, 5th Blvd.', 'Bonn', '44325')

INSERT INTO RentalOrders (EmployeeId, CustomerId, CarId, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus)
VALUES
(1, 1, 1, 230, 330, 100, '2022-12-01', '2022-12-07', 7, 'Weekly', 5, 'Complete'),
(2, 2, 2, 123, 125, 2, '2022-12-01', '2022-12-31', 31, 'Montly', 5, 'Complete'),
(3, 3, 3, 125, 127, 2, '2022-12-01', '2022-12-31', 31, 'Montly', 5, 'In Progress')


--15. Hotel Database
--Employees (Id, FirstName, LastName, Title, Notes)
CREATE TABLE [Employees]
(
[Id] BIGINT PRIMARY KEY IDENTITY NOT NULL,
[FirstName] nvarchar(50) NOT NULL,
[LastName] nvarchar(50) NOT NULL,
[Title] nvarchar(50) NOT NULL,
[Notes] nvarchar(MAX)
)

--Customers (AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes)
CREATE TABLE [Customers]
(
--[Id] BIGINT PRIMARY KEY IDENTITY NOT NULL,
[AccountNumber] nvarchar(20) PRIMARY KEY NOT NULL,
[FirstName] nvarchar(50) NOT NULL,
[LastName] nvarchar(50) NOT NULL,
[PhoneNumber] nvarchar(20) NOT NULL,
[EmergencyName] nvarchar(200) NOT NULL,
[EmergencyNumber] nvarchar(20) NOT NULL,
[Notes] nvarchar(MAX)
)

--RoomStatus (RoomStatus, Notes)
CREATE TABLE [RoomStatus]
(
[Id] INT PRIMARY KEY IDENTITY NOT NULL,
[RoomStatus] nvarchar(20) NOT NULL,
[Notes] nvarchar(MAX)
)

--RoomTypes (RoomType, Notes)
CREATE TABLE [RoomTypes]
(
[Id] INT PRIMARY KEY IDENTITY NOT NULL,
[RoomType] nvarchar(20) NOT NULL,
[Notes] nvarchar(MAX)
)

--BedTypes (BedType, Notes)
CREATE TABLE [BedTypeS]
(
[Id] INT PRIMARY KEY IDENTITY NOT NULL,
[BedType] nvarchar(20) NOT NULL,
[Notes] nvarchar(MAX)
)

--Rooms (RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes)
CREATE TABLE [Rooms]
(
[RoomNumber] BIGINT PRIMARY KEY NOT NULL,
[RoomTypeId] INT FOREIGN KEY REFERENCES RoomTypes(Id) NOT NULL,
[BedTypeId] INT FOREIGN KEY REFERENCES BedTypes(Id) NOT NULL,
[Rate] int,
[RoomStatusId] INT FOREIGN KEY REFERENCES RoomStatus(Id) NOT NULL,
[Notes] nvarchar(MAX)
)

--Payments (Id, EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes)
CREATE TABLE [Payments]
(
[Id] BIGINT PRIMARY KEY IDENTITY NOT NULL,
[EmployeeId] BIGINT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
[PaymentDate] date NOT NULL,
[AccountNumber] nvarchar(20) FOREIGN KEY REFERENCES Customers(AccountNumber) NOT NULL,
[FirstDateOccupied] date NOT NULL,
[LastDateOccupied] date NOT NULL,
[TotalDays] int NOT NULL,
[AmountCharged] decimal(6,2) NOT NULL,
[TaxRate] int NOT NULL,
[TaxAmount] decimal(5,2) NOT NULL,
[PaymentTotal] decimal(6,2) NOT NULL,
[Notes] nvarchar(MAX)
)

--Occupancies (Id, EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes)
CREATE TABLE [Occupancies]
(
[Id] BIGINT PRIMARY KEY IDENTITY NOT NULL,
[DateOccupied] date NOT NULL,
[EmployeeId] BIGINT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
[AccountNumber] nvarchar(20) FOREIGN KEY REFERENCES Customers(AccountNumber) NOT NULL,
[RoomNumber] BIGINT FOREIGN KEY REFERENCES Rooms(RoomNumber) NOT NULL,
[RateApplied] int NOT NULL,
[PhoneCharge] decimal(5,2),
[Notes] nvarchar(MAX)
)

INSERT INTO [Employees] (FirstName, LastName, Title) 
VALUES
('Budi', 'Odin', 'CEO'),
('Adi', 'Adin', 'Director'),
('Didi', 'Edin', 'Lecturer')

INSERT INTO [Customers] (AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber)
VALUES
('AN100200300', 'Ellie', 'Ellie', '+359852963741', 'Jane Dowe', '+359741258963'),
('AN100200400', 'Mellie', 'Ellie', '+359852963742', 'Jane Dow', '+359741258961'),
('AN100200500', 'Bellie', 'Ellie', '+359852963743', 'John Dowe', '+359741258964')

INSERT INTO RoomStatus (RoomStatus)
VALUES
('Free'),
('Occuped'),
('For Cleaning')

INSERT INTO RoomTypes (RoomType)
VALUES
('Family'),
('Standart'),
('Sea view')

--BedTypes (BedType, Notes)
INSERT INTO BedTypes (BedType)
VALUES
('Single'),
('Double'),
('Bunk bed')

--Payments (Id, EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes)
INSERT INTO [Payments] (EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal)
VALUES
(1, '2022-12-12', 'AN100200300', '2022-12-12', '2022-12-15', 3, 500, 10, 50, 550),
(2, '2022-12-12', 'AN100200400', '2022-11-12', '2022-11-15', 3, 500, 10, 60, 560),
(1, '2022-12-12', 'AN100200500', '2022-12-13', '2022-12-16', 3, 200, 10, 50, 250)

--Rooms (RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes)
INSERT INTO Rooms (RoomNumber, RoomTypeId, BedTypeId, Rate, RoomStatusId)
VALUES
('234', 1, 3, 4, 1),
('324', 3, 2, 5, 3),
('6234', 2, 2, 6, 1)

--Occupancies (Id, EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes)
INSERT INTO Occupancies (EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge)
VALUES
(1, '2022-12-12', 'AN100200300', '234', 4, NULL),
(2, '2022-11-12', 'AN100200500', '324', 7, 5),
(3, '2022-12-14', 'AN100200400', '6234', 4, NULL)


--19. Basic SELECT All Fields
SELECT * FROM Towns
SELECT * FROM Departments
SELECT * FROM Employees


--20. Basic SELECT All Fields and Order Them
SELECT * FROM Towns order by [Name] asc;
SELECT * FROM Departments order by [Name] asc;
SELECT * FROM Employees order by [Salary] desc;


--21. Basic SELECT Some Fields
SELECT [Name] from Towns order by [Name] asc;
SELECT [Name] from Departments order by [Name] asc;
SELECT FirstName, LastName, JobTitle, Salary from Employees order by Salary desc;


--22. Increase Employees Salary
UPDATE Employees
set Salary *= 1.1;
  
SELECT Salary from Employees;  


--23. Decrease Tax Rate
UPDATE Payments
set TaxRate *= 0.97;

SELECT TaxRate from Payments;


--24. Delete All Records
delete from Occupancies