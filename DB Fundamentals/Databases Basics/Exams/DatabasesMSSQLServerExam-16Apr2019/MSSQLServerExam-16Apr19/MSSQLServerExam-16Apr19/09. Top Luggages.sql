SELECT lt.Type, COUNT(p.ID) AS [MostUsedLuggage]
FROM LuggageTypes lt 
JOIN Luggages l ON l.LuggageTypeId = lt.Id
JOIN Passengers p ON p.ID=l.PassengerId
GROUP BY lt.Type
ORDER BY COUNT(p.ID) DESC, lt.Type