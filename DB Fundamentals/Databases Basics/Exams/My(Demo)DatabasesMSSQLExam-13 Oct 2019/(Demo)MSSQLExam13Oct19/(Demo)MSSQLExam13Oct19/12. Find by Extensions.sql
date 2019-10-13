CREATE OR ALTER PROC usp_FindByExtension(@extension VARCHAR(30))
AS
BEGIN TRANSACTION
	DECLARE @t TABLE(Id INT, Name VARCHAR(30), Size VARCHAR(30))
	INSERT INTO @t (Id, Name, Size)
	SELECT Id, Name, CONCAT(Size,'KB')	
	FROM FILES
	WHERE Name LIKE '%.'+@extension
	SELECT * FROM @t
COMMIT

EXEC usp_FindByExtension 'txt'