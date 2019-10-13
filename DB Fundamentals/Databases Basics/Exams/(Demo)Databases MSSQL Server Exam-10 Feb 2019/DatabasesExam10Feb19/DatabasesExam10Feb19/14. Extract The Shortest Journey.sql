SELECT TOP(1) j.Id, p.Name, sp.Name, j.Purpose
FROM Planets AS p
JOIN Spaceports AS sp
ON sp.PlanetId = p.Id
JOIN Journeys AS j
ON j.DestinationSpaceportId = sp.Id
ORDER BY (j.JourneyEnd - j.JourneyStart)