SELECT k.ContinentCode, k.CurrencyCode, k.CurrencyUsage
FROM (
		SELECT ContinentCode,
			   CurrencyCode,
			   COUNT(CurrencyCode) AS CurrencyUsage,
			   DENSE_RANK() OVER(PARTITION BY ContinentCode ORDER BY COUNT(CurrencyCode) DESC) AS CurrencyRank
		FROM Countries AS cou
		GROUP BY CurrencyCode, ContinentCode
		HAVING COUNT(CurrencyCode) > 1) AS k
WHERE k.CurrencyRank = 1
ORDER BY ContinentCode