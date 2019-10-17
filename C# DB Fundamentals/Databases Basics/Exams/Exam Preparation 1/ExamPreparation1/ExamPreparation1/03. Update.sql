UPDATE Tickets SET Price += Price * 0.13
FROM Flights f
JOIN Tickets t
ON t.FlightId = f.Id
WHERE Destination = 'Carlsbad'