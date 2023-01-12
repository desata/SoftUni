/*****Table Relations*****/

--01. One-To-One Relationship
CREATE TABLE [dbo].[Passports](
	PassportID [bigint] PRIMARY KEY IDENTITY(101,1) NOT NULL,
	PassportNumber [nvarchar](50) UNIQUE NOT NULL
	)

CREATE TABLE [dbo].[Persons](
	[PersonID] [bigint] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[Salary] decimal (10,2),
	PassportID [bigint] FOREIGN KEY REFERENCES Passports(PassportID)
	)

insert into Passports (PassportNumber)
VALUES
('N34FG21B'),
('K65LO4R7'),
('ZE657QP2')

insert into Persons (FirstName,	Salary,	PassportID)
VALUES
('Roberto',43300.00, 102),
('Tom', 56100.00, 103),
('Yana', 60200.00, 101)


--02. One-To-Many Relationship
CREATE TABLE [dbo].Manufacturers(
	[ManufacturerID] [bigint] Primary Key IDENTITY(1,1) NOT NULL,
	[Name] NVarchar(50) Not Null,
	[EstablishedOn] date
)

Insert into [Manufacturers] ([Name], [EstablishedOn])
VALUES
('BMW', '07/03/1916'),
('Tesla', '01/01/2003'),
('Lada', '01/05/1966')


CREATE TABLE [dbo].Models
(
	[ModelID] [bigint] Primary Key IDENTITY(100,1) NOT NULL,
	[Name] NVarchar(50) Not Null,
	[ManufacturerID] [bigint] Foreign Key References Manufacturers([ManufacturerID])
)

Insert into Models
VALUES
('X1', 1),
('i6', 1),
('Model S',	2),
('Model X',	2),
('Model 3',	2),
('Nova', 3)

--03. Many-To-Many Relationship
Create table Students
(
[StudentID] bigint IDENTITY(1,1) NOT NULL,
[Name] nvarchar(200) NOT NULL,
PRIMARY KEY (StudentID)
)

Create table Exams
(
ExamID bigint IDENTITY(101,1) NOT NULL,
[Name] nvarchar(200) NOT NULL,
PRIMARY KEY (ExamID)
)

Create table StudentsExams
(
StudentID bigint references Students(StudentID) NOT NULL,
ExamID bigint references Exams(ExamID) NOT NULL,
PRIMARY KEY (StudentID, ExamID)
)

insert into Students
VALUES
('Mila'),
('Toni'),
('Ron')

insert into Exams
VALUES
('SpringMVC'),
('Neo4j'),
('Oracle 11g')

insert into StudentsExams
VALUES
(1	,101  ),
(1	,102  ),
(2	,101  ),
(3	,103  ),
(2	,102  ),
(2	,103  )

--04. Self-Referencing
CREATE TABLE Teachers
(
[TeacherID] bigint PRIMARY KEY IDENTITY(101,1) NOT NULL,
[Name] nvarchar(50),
[ManagerID] bigint foreign key references Teachers(TeacherID)
)

INSERT INTO Teachers
VALUES
('John',	NULL),
('Maya', 106),
('Silvia', 106),
('Ted', 105),
('Mark', 101),
('Greta', 101)

--05. Online Store Database
CREATE TABLE Cities
(
[CityID] bigint PRIMARY KEY IDENTITY NOT NULL,
[Name] nvarchar(200) NOT NULL
)

CREATE TABLE Customers
(
[CustomerID] bigint PRIMARY KEY IDENTITY NOT NULL,
[Name] nvarchar(200) NOT NULL,
[Birthday] date,
[CityID] bigint FOREIGN KEY REFERENCES Cities(CityID) NOT NULL
)

CREATE TABLE Orders
(
[OrderID] bigint PRIMARY KEY IDENTITY NOT NULL,
[CustomerID] bigint FOREIGN KEY REFERENCES Customers(CustomerID) NOT NULL
)

CREATE TABLE ItemTypes
(
[ItemTypeID] bigint PRIMARY KEY IDENTITY NOT NULL,
[Name] nvarchar(200) NOT NULL
)


CREATE TABLE Items
(
[ItemID] bigint PRIMARY KEY IDENTITY NOT NULL,
[Name] nvarchar(200) NOT NULL,
[ItemTypeID] bigint FOREIGN KEY REFERENCES ItemTypes(ItemTypeID) NOT NULL
)

CREATE TABLE OrderItems
(
[OrderID] bigint FOREIGN KEY REFERENCES Orders(OrderID) NOT NULL,
[ItemID] bigint FOREIGN KEY REFERENCES Items(ItemID) NOT NULL
PRIMARY KEY ([OrderID], [ItemID])
)

--06. University Database
CREATE TABLE [Majors](
    [MajorID] INT PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(70) NOT NULL
)
 
CREATE TABLE [Students](
    [StudentID] INT PRIMARY KEY IDENTITY,
    [StudentNumber] VARCHAR(15) NOT NULL,
    [StudentName] NVARCHAR(70) NOT NULL,
    [MajorID] INT FOREIGN KEY REFERENCES [Majors]([MajorID]) NOT NULL
)
 
CREATE TABLE [Payments](
    [PaymentID] INT PRIMARY KEY IDENTITY,
    [PaymentDate] DATETIME2 NOT NULL,
    [PaymentAmount] DECIMAL(8, 2) NOT NULL,
    [StudentID] INT FOREIGN KEY REFERENCES [Students]([StudentID]) NOT NULL
)
 
CREATE TABLE [Subjects](
    [SubjectID] INT PRIMARY KEY IDENTITY,
    [SubjectName] NVARCHAR(70) NOT NULL
)
 
CREATE TABLE [Agenda](
    [StudentID] INT FOREIGN KEY REFERENCES [Students]([StudentID]),
    [SubjectID] INT FOREIGN KEY REFERENCES [Subjects]([SubjectID]),
    PRIMARY KEY ([StudentID], [SubjectID])
)


--09. *Peaks in Rila
select m.MountainRange,	p.PeakName,	p.Elevation
from mountains m
join peaks p on m.Id = p.MountainId
where m.MountainRange = 'Rila'
order by Elevation desc
