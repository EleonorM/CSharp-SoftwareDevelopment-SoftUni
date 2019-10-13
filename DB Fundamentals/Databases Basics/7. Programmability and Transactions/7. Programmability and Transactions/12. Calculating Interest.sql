CREATE PROC usp_CalculateFutureValueForAccount (@accountId INT, @intrestRate FLOAT)
AS
	SELECT ah.Id, 
	ah.FirstName, 
	ah.LastName, 
	a.Balance AS [Current Balance], 
	[dbo].[ufn_CalculateFutureValue](a.Balance, @intrestRate, 5)
	FROM AccountHolders AS ah
	JOIN Accounts AS a
	ON a.AccountHolderId = ah.Id
	WHERE a.Id = @accountId
GO

exec dbo.usp_CalculateFutureValueForAccount @accountId = 1, @intrestRate = 0.1;