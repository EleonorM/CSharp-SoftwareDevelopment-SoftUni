CREATE FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME) 
RETURNS INT
AS
BEGIN 
	DECLARE @totalHours INT
	IF(@StartDate IS NULL)
	BEGIN
		SET @totalHours = 0
	END
	ELSE IF(@EndDate IS NULL)
	BEGIN
		SET @totalHours = 0
	END
	ELSE
	BEGIN
		SET @totalHours = DATEDIFF(HOUR, @StartDate, @EndDate)
	END

	RETURN @totalHours
END
GO

SELECT dbo.udf_HoursToComplete(OpenDate, CloseDate) AS TotalHours
   FROM Reports
