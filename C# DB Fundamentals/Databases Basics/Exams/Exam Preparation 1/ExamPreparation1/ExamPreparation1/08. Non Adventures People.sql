SELECT p.FirstName, p.LastName, p.Age
FROM Passengers p
LEFT JOIN Tickets t ON t.PassengerId = p.Id
WHERE t.Id IS NULL
ORDER BY p.Age DESC, p.FirstName,p.LastName