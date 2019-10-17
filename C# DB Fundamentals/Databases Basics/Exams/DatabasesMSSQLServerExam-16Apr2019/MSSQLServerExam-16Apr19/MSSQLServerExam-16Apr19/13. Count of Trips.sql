SELECT  p.FirstName,P.LastName, COUNT(t.FlightId) AS [Total Trips]
FROM Passengers p
LEFT JOIN Tickets t ON t.PassengerId= p.Id
GROUP BY p.FirstName,P.LastName
ORDER BY [Total Trips] DESC, FirstName, LastName