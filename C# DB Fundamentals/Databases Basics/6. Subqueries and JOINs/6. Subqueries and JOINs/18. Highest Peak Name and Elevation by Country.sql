SELECT TOP(5) temp.CountryName, temp.[Highest Peak Name], temp.[Highest Peak Elevation], temp.MountainName
FROM(
	 SELECT c.CountryName,
	 	   ISNULL(p.PeakName, '(no highest peak)') AS [Highest Peak Name],
	 	   ISNULL(p.Elevation,0) AS [Highest Peak Elevation],
	 	   ISNULL(m.MountainRange, '(no mountain)') AS MountainName,
	 	   DENSE_RANK() OVER (PARTITION BY CountryName ORDER BY p.Elevation DESC) AS ElevationRank
	 FROM Countries AS c
	 LEFT JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
	 LEFT JOIN Mountains AS m ON m.Id = mc.MountainId
	 LEFT JOIN Peaks AS p ON p.MountainId = m.Id) as temp
WHERE temp.ElevationRank = 1
ORDER BY temp.CountryName, temp.[Highest Peak Name]

