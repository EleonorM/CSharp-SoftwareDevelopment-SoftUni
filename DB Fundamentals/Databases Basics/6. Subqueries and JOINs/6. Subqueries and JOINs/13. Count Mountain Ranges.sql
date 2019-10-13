  SELECT c.CountryCode, COUNT(MountainRange)
	FROM Mountains AS m
	JOIN MountainsCountries AS mc ON m.Id=mc.MountainId
	JOIN Countries AS c ON c.CountryCode = mc.CountryCode
GROUP BY c.CountryCode
  HAVING c.CountryCode IN('BG', 'RU', 'US')