SELECT TOP(1) ss.Name , sp.Name AS Manufacturer
FROM Spaceports AS sp
JOIN Journeys AS j
ON j.DestinationSpaceportId = sp.Id
JOIN Spaceships AS ss
ON ss.Id = j.SpaceshipId
ORDER BY LightSpeedRate DESC