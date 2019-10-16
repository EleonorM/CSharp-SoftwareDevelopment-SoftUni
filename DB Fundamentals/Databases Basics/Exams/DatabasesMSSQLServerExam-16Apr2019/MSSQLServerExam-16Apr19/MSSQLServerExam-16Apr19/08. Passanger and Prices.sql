SELECT TOP(10) FirstName, LastName, Price
FROM Passengers p
JOIN Tickets t ON t.PassengerId = p.Id
ORDER BY Price DESC, FirstName, LastName