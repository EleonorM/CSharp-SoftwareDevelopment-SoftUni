  SELECT c.CountryCode, m.MountainRange, p.PeakName, p.Elevation
	FROM Mountains AS m
	JOIN MountainsCountries AS mc ON m.Id=mc.MountainId
	JOIN Countries AS c ON c.CountryCode = mc.CountryCode
	JOIN Peaks AS p ON p.MountainId = m.Id
   WHERE p.Elevation > 2835 AND c.CountryCode = 'BG'
ORDER BY p.Elevation DESC