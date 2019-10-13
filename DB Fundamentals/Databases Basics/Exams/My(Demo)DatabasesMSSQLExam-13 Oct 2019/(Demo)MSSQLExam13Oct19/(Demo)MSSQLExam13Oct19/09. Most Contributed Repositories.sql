SELECT TOP(5) r.ID, r.Name, COUNT(c.ID)
FROM REPOSITORIES r
JOIN Commits c ON c.RepositoryId = r.Id
JOIN RepositoriesContributors rs ON rs.RepositoryId = r.Id
JOIN Users u ON u.Id = rs.ContributorId
GROUP BY r.ID, r.Name
ORDER BY COUNT(c.Id) DESC, r.Id, r.Name