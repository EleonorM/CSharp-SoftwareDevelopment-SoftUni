DELETE 
FROM RepositoriesContributors
WHERE RepositoryId = (SELECT ID FROM Repositories 
WHERE Name = 'Softuni-Teamwork')

DELETE 
FROM Issues
WHERE RepositoryId = (SELECT ID FROM Repositories 
WHERE Name = 'Softuni-Teamwork')