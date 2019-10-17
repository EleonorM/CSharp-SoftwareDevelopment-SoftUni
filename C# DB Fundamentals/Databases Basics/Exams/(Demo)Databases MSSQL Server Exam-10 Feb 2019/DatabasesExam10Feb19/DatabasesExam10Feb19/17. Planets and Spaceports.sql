SELECT p.Name, COUNT(sp.Name) AS [Count]
FROM Planets AS p
LEFT JOIN Spaceports AS sp
ON sp.PlanetId = p.Id
GROUP BY p.Name
ORDER BY COUNT(sp.Id) DESC, p.Name
