CREATE TABLE Logs
(LogId INT IDENTITY,
AccountId INT,
OldSum MONEY,
NewSum MONEY)
GO

CREATE TRIGGER tr_sum_change
ON Accounts
FOR UPDATE
AS
BEGIN
    INSERT INTO Logs 
	(AccountId, OldSum, NewSum)
	SELECT i.Id, d.Balance, i.Balance
	FROM inserted AS i
	JOIN deleted AS d ON d.Id = i.Id
   
END
GO

UPDATE Accounts
SET Balance += 10
WHERE Id = 2 

SELECT * FROM Logs
