SELECT  f.Id, SUM(t.Price) AS Price
FROM Flights f
JOIN Tickets t
ON t.FlightId = f.Id
GROUP BY f.Id
ORDER BY  SUM(t.Price) DESC, f.Id