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


