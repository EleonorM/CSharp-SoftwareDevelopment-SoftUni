   SELECT COUNT(c.CountryCode) AS CountryCode
	 FROM Mountains AS m
LEFT JOIN MountainsCountries AS mc ON m.Id=mc.MountainId
FULL JOIN Countries AS c ON c.CountryCode = mc.CountryCode
	WHERE m.Id IS NULL