SELECT Username, AVG(f.Size)
FROM Users u
JOIN Commits c ON c.ContributorId = u.Id
JOIN Files f ON f.CommitId = c.Id
GROUP BY Username
ORDER BY AVG(f.Size) DESC, Username