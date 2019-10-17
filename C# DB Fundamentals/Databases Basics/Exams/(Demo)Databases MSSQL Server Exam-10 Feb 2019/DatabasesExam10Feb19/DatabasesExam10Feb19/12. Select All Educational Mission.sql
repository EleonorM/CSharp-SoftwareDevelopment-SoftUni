SELECT p.Name, sp.Name
FROM Planets AS p
JOIN Spaceports AS sp
ON sp.PlanetId = p.Id
JOIN Journeys AS j
ON j.DestinationSpaceportId = sp.Id
WHERE j.Purpose = 'Educational'
ORDER BY sp.Name DESC