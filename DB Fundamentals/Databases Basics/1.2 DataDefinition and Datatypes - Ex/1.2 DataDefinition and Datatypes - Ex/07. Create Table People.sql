CREATE TABLE People (
	Id INT IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	Picture VARBINARY(2000),
	Height  DECIMAL(15,2),
	[Weight]  DECIMAL(15,2),
	Gender VARCHAR(1) NOT NULL CHECK (Gender IN ('m', 'f')),
	Birthdate DATE,
	Biography NVARCHAR(MAX)

	CONSTRAINT PK_People PRIMARY KEY(Id)
)

INSERT INTO People
VALUES
('Eli', NULL, 174,54.6,'f',CONVERT(date, '1996-07-25'), 'Cool'),
('Didi', NULL, 174,54,'f',CONVERT(date, '1996-07-26'), 'Cool'),
('Titi', NULL, 174,54,'m',CONVERT(date, '1996-07-27'), 'Cool'),
('Koko', NULL, 174,54.8,'m',CONVERT(date, '1996-07-28'), 'Cool'),
('Pesho', NULL, 174,54.9,'m',CONVERT(date, '1996-07-29'), 'Cool')

SELECT * FROM People

DROP TABLE PEOPLE