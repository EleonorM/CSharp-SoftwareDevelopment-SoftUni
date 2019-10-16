SELECT Destination, COUNT(t.Id) AS [FilesCount]
FROM Flights f
LEFT JOIN Tickets t ON t.FlightId = f.Id
GROUP BY Destination
ORDER BY FilesCount DESC, Destination 