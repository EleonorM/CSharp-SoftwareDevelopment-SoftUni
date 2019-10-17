CREATE TABLE DeletedPlanes
(Id INT,
[Name]  VARCHAR(50),
Seats INT,
[Range] INT)

CREATE TRIGGER tr_deletedPlanes
ON Planes
AFTER DELETE
AS
	INSERT INTO DeletedPlanes
	SELECT Id, Name, Seats, Range
	FROM deleted