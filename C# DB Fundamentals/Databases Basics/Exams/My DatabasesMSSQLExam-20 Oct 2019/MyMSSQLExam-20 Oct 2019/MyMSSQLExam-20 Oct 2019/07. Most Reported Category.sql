SELECT TOP(5) c.Name, COUNT(r.ID)
FROM Reports r
JOIN Categories c ON c.Id = r.CategoryId
GROUP BY c.Name
ORDER BY COUNT(r.ID) DESC, c.Name
