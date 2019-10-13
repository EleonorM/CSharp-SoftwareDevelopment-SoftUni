CREATE FUNCTION udf_GetColonistsCount(@PlanetName VARCHAR (30)) 
RETURNS INT
	BEGIN
	DECLARE @Count INT
	SET @Count = (SELECT COUNT(C.Id)
				FROM Colonists AS c
				full JOIN TravelCards AS tc
				ON tc.ColonistId = c.Id
				full JOIN Journeys AS j
				ON j.Id = tc.JourneyId
				full JOIN Spaceports AS sp
				ON sp.Id = j.DestinationSpaceportId
				full JOIN Planets AS p
				ON p.Id = sp.PlanetId
				WHERE p.Name= @PlanetName)
	RETURN @Count
	END