SELECT u.Username, c.Name
FROM Reports r
JOIN Users u ON R.UserId = u.Id
JOIN Categories c ON c.Id = r.CategoryId
WHERE DATEPART(DAY,r.OpenDate) = DATEPART(DAY,u.Birthdate) AND DATEPART(MONTH,r.OpenDate) = DATEPART(MONTH,u.Birthdate)
ORDER BY u.Username, c.Name