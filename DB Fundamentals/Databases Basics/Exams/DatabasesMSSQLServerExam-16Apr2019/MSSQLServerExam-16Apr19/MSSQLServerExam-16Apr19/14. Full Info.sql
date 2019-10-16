SELECT  CONCAT (p.FirstName, ' ', p.LastName) AS FullName, 
		pl.Name,
		CONCAT (f.Origin, ' - ', f.Destination) AS Trip, 
		lt.Type
FROM Passengers p
JOIN Tickets t ON t.PassengerId = p.Id
JOIN Flights f ON f.Id = t.FlightId
JOIN Planes pl ON pl.Id = f.PlaneId
JOIN Luggages l ON l.Id = t.LuggageId
JOIN LuggageTypes lt ON lt.Id = l.LuggageTypeId
ORDER BY FullName, pl.Name, f.Origin, f.Destination, lt.Type