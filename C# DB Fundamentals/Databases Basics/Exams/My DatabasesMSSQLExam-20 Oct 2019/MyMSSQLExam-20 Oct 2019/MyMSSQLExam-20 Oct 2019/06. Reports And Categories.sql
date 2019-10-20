SELECT Description, c.Name
FROM Reports r
JOIN Categories c ON c.Id = r.CategoryId
WHERE CategoryId IS NOT NULL
ORDER BY Description, c.Name