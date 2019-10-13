CREATE OR ALTER FUNCTION udf_CalculateTickets(@origin VARCHAR(50), @destination VARCHAR(50), @peopleCount INT) 
RETURNS VARCHAR(50)
AS
BEGIN
	DECLARE @Result VARCHAR(50)
	DECLARE @flightId INT
	SET @flightId =(SELECT Id FROM Flights WHERE Origin = @origin AND Destination = @destination)

	DECLARE @flightPrice DECIMAL(15,2)
	SET @flightPrice =(SELECT Price FROM Tickets WHERE FlightId = @flightId)

	SET @Result = 'Total price '+CONVERT(VARCHAR(50) ,@flightPrice* @peopleCount)

	IF(@flightId IS NULL)
	BEGIN
		SET @Result = 'Invalid flight!'
	END
		
	IF(@peopleCount <= 0)
	BEGIN
		SET @Result = 'Invalid people count!'
	END

	RETURN @Result
END
GO

SELECT dbo.udf_CalculateTickets('Kolyshley','Rancabolang', 33)