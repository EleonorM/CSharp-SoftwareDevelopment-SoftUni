CREATE TABLE DeletedJourneys
(Id INT,
JourneyStart DATETIME,
JourneyEnd DATETIME,
Purpose VARCHAR(11),
DestinationSpaceportId INT,
SpaceshipId INT)
GO

CREATE TRIGGER tr_deleted
ON Journeys
AFTER DELETE
AS
	INSERT INTO DeletedJourneys (Id, JourneyStart,JourneyEnd, Purpose, DestinationSpaceportId, SpaceshipId)
	SELECT Id, JourneyStart, JourneyEnd, Purpose, DestinationSpaceportId, SpaceshipId
	FROM deleted


DELETE FROM TravelCards
WHERE JourneyId =  2

DELETE FROM Journeys
WHERE Id =  1

SELECT * FROM DeletedJourneys
