CREATE PROC usp_CancelFlights 
AS
BEGIN TRANSACTION
	UPDATE Flights SET ArrivalTime = NULL, DepartureTime = NULL
	FROM Flights
	WHERE ArrivalTime > DepartureTime
COMMIT