CREATE PROC usp_GetEmployeesFromTown (@townName NVARCHAR(50))
AS
	SELECT FirstName, LastName
	FROM Employees AS e
	JOIN Addresses AS ad
	ON e.AddressID = ad.AddressID
	JOIN Towns AS t
	ON ad.TownID = t.TownID
	WHERE t.Name = @townName
GO

EXEC usp_GetEmployeesFromTown Sofia