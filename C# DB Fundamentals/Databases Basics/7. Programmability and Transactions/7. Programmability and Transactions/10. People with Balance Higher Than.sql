CREATE PROC usp_GetHoldersWithBalanceHigherThan (@minMoney MONEY)
AS
BEGIN
	SELECT ah.FirstName, ah.LastName
	FROM AccountHolders AS ah
	JOIN Accounts AS a
	ON a.AccountHolderId = ah.Id
	GROUP BY ah.FirstName, ah.LastName
	HAVING SUM(a.Balance) > @minMoney
	ORDER BY ah.FirstName, ah.LastName
END
GO