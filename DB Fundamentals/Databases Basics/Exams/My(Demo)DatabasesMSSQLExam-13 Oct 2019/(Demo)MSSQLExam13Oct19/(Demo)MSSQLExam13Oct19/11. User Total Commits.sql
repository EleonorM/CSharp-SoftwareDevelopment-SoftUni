CREATE FUNCTION udf_UserTotalCommits(@username VARCHAR(30)) 
RETURNS INT
AS
BEGIN
	DECLARE @Count INT
	SET @Count = (SELECT COUNT(*)  
	FROM Users u
	JOIN Commits c ON c.ContributorId = u.Id
	WHERE Username = @username)
	RETURN @Count
END

SELECT dbo.udf_UserTotalCommits('UnderSinduxrein')