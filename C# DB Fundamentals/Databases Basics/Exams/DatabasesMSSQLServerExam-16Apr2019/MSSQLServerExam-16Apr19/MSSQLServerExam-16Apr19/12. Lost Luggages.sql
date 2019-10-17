SELECT PassportId, Address
FROM Passengers p
LEFT JOIN Luggages l ON l.PassengerId = p.Id
WHERE l.Id IS NULL
ORDER BY PassportId, Address