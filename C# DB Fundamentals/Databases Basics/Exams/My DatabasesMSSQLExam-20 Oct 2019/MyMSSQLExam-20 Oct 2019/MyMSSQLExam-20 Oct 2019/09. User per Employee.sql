SELECT CONCAT( e.FirstName,' ', e.LastName) AS FullName, COUNT(u.ID)
FROM Employees e
LEFT JOIN Reports r ON e.Id = r.EmployeeId
LEFT JOIN Users u ON u.Id = r.UserId
GROUP BY e.FirstName, e.LastName
ORDER BY COUNT(u.ID) DESC, FullName