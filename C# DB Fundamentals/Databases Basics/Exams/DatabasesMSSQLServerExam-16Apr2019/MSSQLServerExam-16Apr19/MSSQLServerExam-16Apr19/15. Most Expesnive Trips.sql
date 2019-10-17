SELECT FirstName, LastName, Destination,Price
FROM
(SELECT FirstName, LastName, Destination, Price,
ROW_NUMBER() OVER(PARTITION BY p.ID ORDER BY PRICE DESC)AS [Row]
FROM Passengers p
JOIN Tickets t ON t.PassengerId = p.Id
JOIN Flights f ON f.Id = t.FlightId) AS t
WHERE Row = 1
ORDER BY Price DESC, FirstName, LastName, Destination