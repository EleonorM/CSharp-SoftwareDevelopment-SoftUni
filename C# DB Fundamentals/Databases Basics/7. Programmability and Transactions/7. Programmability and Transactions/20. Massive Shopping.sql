SELECT *
FROM Users AS u
JOIN UsersGames AS ug
ON ug.UserId = u.Id
JOIN Games AS g 
ON g.Id = ug.GameId
JOIN UserGameItems AS ugi
ON ugi.UserGameId = ug.Id
JOIN Items AS i
ON i.Id = ugi.ItemId
WHERE u.FirstName = 'Stamat' AND g.Name = 'Safflower'
ORDER BY g.Name
GO

SELECT *
FROM Games AS g 
JOIN GameTypes AS gt
ON gt.Id = g.GameTypeId
JOIN GameTypeForbiddenItems AS gtfi
ON gtfi.GameTypeId = gt.Id
JOIN Items AS i
ON i.Id = gtfi.ItemId
WHERE g.Name= 'Safflower' AND MinLevel in (11,12,19,20,21)
GO

SELECT *
FROM Items AS i
WHERE i.MinLevel IN (11,12,19,20,21)
GO

SELECT *
FROM Users u
JOIN UsersGames ug ON u.Id = ug.UserId
WHERE u.FirstName = 'Stamat'
GO

CREATE PROC udp_buyIems
AS
BEGIN TRANSACTION
	DECLARE @Sum INT
	SET @Sum =(SELECT SUM(Price)
				  FROM Items 
				  WHERE MinLevel IN (11,12))

	UPDATE UsersGames SET Cash -= @Sum
	FROM Users AS u
	JOIN UsersGames AS ug
	ON ug.UserId = u.Id
	WHERE u.FirstName = 'Stamat'


COMMIT