CREATE PROC usp_GetTownsStartingWith (@string NVARCHAR(50))
AS
	SELECT Name AS Town
	FROM Towns
	WHERE Name LIKE @string + '%'
GO

EXEC usp_GetTownsStartingWith 'b'