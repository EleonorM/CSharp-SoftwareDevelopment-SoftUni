SELECT f.Id, f.Name, CONCAT(f.Size, 'KB') AS Size
FROM Files f
FULL JOIN Files p ON p.ParentId = f.Id
WHERE p.ID IS NULL
ORDER BY ID, Name, Size DESC

SELECT *
