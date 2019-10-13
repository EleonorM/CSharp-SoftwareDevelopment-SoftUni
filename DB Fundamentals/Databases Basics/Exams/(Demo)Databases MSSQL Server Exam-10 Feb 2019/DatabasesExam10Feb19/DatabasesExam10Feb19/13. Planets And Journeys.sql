SELECT p.Name, COUNT(j.Id)
FROM Planets AS p
JOIN Spaceports AS sp
ON sp.PlanetId = p.Id
JOIN Journeys AS j
ON j.DestinationSpaceportId = sp.Id
GROUP BY p.Name
ORDER BY COUNT(j.Id) DESC, p.Name 