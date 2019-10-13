CREATE OR ALTER PROC usp_ChangeJourneyPurpose(@JourneyId INT, @NewPurpose VARCHAR(11))
AS
BEGIN TRANSACTION
	IF((SELECT COUNT(Id) FROM Journeys WHERE Id = @JourneyId) = 0)
	BEGIN
	ROLLBACK
	RAISERROR('The journey does not exist!',16,1)
	RETURN
	END

	IF( (SELECT Purpose FROM Journeys WHERE Id = @JourneyId) = @NewPurpose)
	BEGIN
	ROLLBACK
	RAISERROR('You cannot change the purpose!',16,1)
	RETURN
	END

	UPDATE Journeys SET Purpose = @NewPurpose
	FROM Journeys
	WHERE Id = @JourneyId
COMMIT