--1.	Create Table Logs
--Create a table – Logs (LogId, AccountId, OldSum, NewSum). 
--Add a trigger to the Accounts table that enters a new entry into the Logs table every time the sum on an account change. 
--Submit only the query that creates the trigger.
CREATE TABLE [Logs]
(
	[LogId] INT PRIMARY KEY IDENTITY,
	[AccountId] INT REFERENCES [Accounts](Id),
	[OldSum] MONEY NOT NULL,
	[NewSum] MONEY NOT NULL
)



CREATE TRIGGER tr_AddToLogsOnAccountUpdate
ON Accounts FOR UPDATE
AS
  INSERT INTO Logs(AccountId, OldSum, NewSum)
  SELECT i.Id, d.Balance, i.Balance
  FROM inserted AS i
  JOIN deleted AS d ON i.Id = d.Id
  WHERE i.Balance != d.Balance

  /*2.	Create Table Emails
Create another table – NotificationEmails(Id, Recipient, Subject, Body). 
Add a trigger to logs table and create new email whenever new record is inserted in logs table. 
The following data is required to be filled for each email:
•	Recipient – AccountId
•	Subject – "Balance change for account: {AccountId}"
•	Body - "On {date} your balance was changed from {old} to {new}."
Submit your query only for the trigger action.
*/
CREATE TABLE NotificationEmails
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Recipient] INT REFERENCES [Accounts](Id),
	[Subject] NVARCHAR (200) NOT NULL, 
	[Body] NVARCHAR (200) NOT NULL
)

CREATE TRIGGER tr_OnNewLogAddEmailNotification
ON [Logs] FOR INSERT
AS
	DECLARE @AccountId INT = (SELECT TOP(1) [AccountId] FROM inserted);
	DECLARE @OldSum MONEY = (Select TOP(1) [OldSum] FROM inserted);
	DECLARE @NewSum MONEY = (Select TOP(1) [NewSum] FROM inserted);

	INSERT INTO [NotificationEmails](Recipient, Subject, Body) 
	VALUES
	(
		@AccountId,
		'Balance change for account: ' + CAST(@AccountId AS NVARCHAR(50)),
		CONCAT('On',' ', GETDATE(), ' your balance was changed from ', CAST(@OldSum AS NVARCHAR(50)), ' to ', CAST(@NewSum AS NVARCHAR(50)), ' .')
	)


/*3.	Deposit Money
Add stored procedure usp_DepositMoney(AccountId, MoneyAmount) that deposits money to an existing account. 
Make sure to guarantee valid positive MoneyAmount with precision up to the fourth sign after the decimal point. 
The procedure should produce exact results working with the specified precision.
*/

GO
CREATE PROC usp_DepositMoney (@accountId INT, @moneyAmount MONEY)
AS
BEGIN TRANSACTION
	IF NOT EXISTS(SELECT [Id] FROM [Accounts] WHERE [Id] = @accountId )
	BEGIN
		ROLLBACK;
		THROW 50001, 'Invalid Account Number', 1
	END

	IF @moneyAmount < 0
	BEGIN
		ROLLBACK;
		THROW 50002, 'Invalid deposit amount', 2
	END

UPDATE [Accounts]
	SET [Balance] += @moneyAmount
	WHERE [Id] = @accountId
COMMIT
GO

SELECT * FROM Accounts

EXEC usp_DepositMoney 1, 1000

/*4.	Withdraw Money Procedure
Add stored procedure usp_WithdrawMoney (AccountId, MoneyAmount) that withdraws money from an existing account. 
Make sure to guarantee valid positive MoneyAmount with precision up to the fourth sign after decimal point. 
The procedure should produce exact results working with the specified precision.
*/
GO
CREATE PROC usp_WithdrawMoney (@accountId INT, @moneyAmount MONEY)
AS
BEGIN TRANSACTION
	IF NOT EXISTS(SELECT [Id] FROM [Accounts] WHERE [Id] = @accountId )
	BEGIN
		ROLLBACK;
		THROW 50001, 'Invalid Account Number', 1
	END

	IF (SELECT [Balance] FROM [Accounts] WHERE [Id] = @accountId ) < @moneyAmount
	BEGIN
		ROLLBACK;
		THROW 50002, 'Not enough funds!', 2
	END

UPDATE [Accounts]
	SET [Balance] -= @moneyAmount
	WHERE [Id] = @accountId
COMMIT
GO

SELECT * FROM Accounts WHERE Id = 1

EXEC usp_WithdrawMoney 1, 2000

/*5.	Money Transfer
Create stored procedure usp_TransferMoney(SenderId, ReceiverId, Amount) that transfers money from one account
to another. Make sure to guarantee valid positive MoneyAmount with precision up to the fourth sign
after the decimal point. Make sure that the whole procedure passes without errors and if an error occurs
make no change in the database. You can use both: "usp_DepositMoney", "usp_WithdrawMoney"
(look at the previous two problems about those procedures). 
*/

GO
CREATE PROC usp_TransferMoney(@senderId INT, @receiverId INT, @amount MONEY)
AS
	BEGIN TRANSACTION
		EXEC usp_WithdrawMoney @senderId, @amount
		EXEC usp_DepositMoney @receiverId, @amount
	COMMIT
GO

SELECT * FROM Accounts WHERE Id IN (1,2)
EXEC usp_TransferMoney 1, 2, 1000

/* 6.*Massive Shopping
User Stamat in Safflower game wants to buy some items. He likes all items from Level 11 to 12
as well as all items from Level 19 to 21. As it is a bulk operation you have to use transactions. 
A transaction is the operation of taking out the cash from the user in the current game as well
as adding up the items. 
Write transactions for each level range. If anything goes wrong turn back the changes inside of the transaction.
Extract all of Stamat's item names in the given game sorted by name alphabetically.
*/

--GameID = 87
--StamatID = 9

DECLARE @userGameId INT = (SELECT Id FROM UsersGames WHERE UserId = 9 AND GameId = 87)
DECLARE @cash MONEY = (SELECT Cash FROM UsersGames WHERE Id = @userGameId)
DECLARE @itemsPrice MONEY = (SELECT SUM(Price) AS TotalPrice FROM Items WHERE MinLevel BETWEEN 11 AND 12)

IF @cash >= @itemsPrice
BEGIN
	BEGIN TRANSACTION
	UPDATE UsersGames
		SET Cash -= @itemsPrice
		WHERE UserId = 9 AND GameId = 87

	INSERT INTO UserGameItems (ItemId, UserGameId)
	SELECT Id, @userGameId FROM Items WHERE MinLevel BETWEEN 11 AND 12
	COMMIT
END


SET @cash = (SELECT Cash FROM UsersGames WHERE Id = @userGameId);
SET @itemsPrice = (SELECT SUM(Price) AS TotalPrice FROM Items WHERE MinLevel BETWEEN 19 AND 21)

IF @cash >= @itemsPrice
BEGIN
	BEGIN TRANSACTION
	UPDATE UsersGames
		SET Cash -= @itemsPrice
		WHERE UserId = 9 AND GameId = 87

	INSERT INTO UserGameItems (ItemId, UserGameId)
	SELECT Id, @userGameId FROM Items WHERE MinLevel BETWEEN 19 AND 21
	COMMIT
END

SELECT i.Name
	FROM Users AS u
	JOIN UsersGames AS ug
	  ON ug.UserId = u.Id
	JOIN Games AS g
	  ON g.Id = ug.GameId	   
	JOIN UserGameItems AS ugi
	  ON ugi.UserGameId = ug.Id
	JOIN Items AS i
	  ON i.Id = ugi.ItemId
	WHERE u.Username = 'Stamat' AND g.Name = 'Safflower'
	ORDER BY i.Name



/*
8.	Employees with Three Projects
Create a procedure usp_AssignProject(@emloyeeId, @projectID) that assigns projects to an employee.
If the employee has more than 3 project throw exception and rollback the changes.
The exception message must be: "The employee has too many projects!" with Severity = 16, State = 1.
*/

GO
CREATE OR ALTER PROC usp_AssignProject(@emloyeeId INT, @projectID INT)
AS
BEGIN TRANSACTION
	DECLARE @employee INT = (SELECT EmployeeID FROM Employees WHERE EmployeeID = @emloyeeId)
	DECLARE @project INT = (SELECT ProjectID FROM Projects WHERE ProjectID = @projectID)
	
	DECLARE @countProjects INT = (SELECT COUNT(*)FROM EmployeesProjects 
								  WHERE EmployeeID = @emloyeeId)

	IF (@employee IS NULL OR @project IS NULL)
	BEGIN
		ROLLBACK;
		THROW 50001, 'Invalid employee or project', 2
	END
	IF (@countProjects) >= 3
	BEGIN
		ROLLBACK;
		THROW 50002, 'The employee has too many projects!', 1
	END
	INSERT INTO EmployeesProjects(EmployeeID, ProjectID) VALUES
	(@emloyeeId, @projectID)
COMMIT
GO

/*
9.	Delete Employees
Create a table Deleted_Employees(EmployeeId PK, FirstName, LastName, MiddleName, JobTitle, DepartmentId, Salary)
that will hold information about fired (deleted) employees from the Employees table.
Add a trigger to Employees table that inserts the corresponding information
about the deleted records in Deleted_Employees.
*/

CREATE TABLE Deleted_Employees
(
	EmployeeId INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	MiddleName VARCHAR(50),
	JobTitle VARCHAR(150) NOT NULL,
	DepartmentId INT REFERENCES Departments(DepartmentID),
	Salary MONEY NOT NULL
)

GO
CREATE TRIGGER tr_LogDeletedEmployees
ON Employees FOR DELETE
AS
	INSERT INTO Deleted_Employees(FirstName, LastName, MiddleName, JobTitle, DepartmentId, Salary)
	SELECT FirstName, LastName, MiddleName, JobTitle, DepartmentId, Salary FROM deleted
GO
