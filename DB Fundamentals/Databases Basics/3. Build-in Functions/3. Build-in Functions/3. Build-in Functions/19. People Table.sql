CREATE TABLE People
(Id INT IDENTITY,
Name NVARCHAR(50),
Birthday DATETIME)

INSERT INTO People
VALUES
('Victor', '2000-12-07'),
('Steven', '1992-09-10'),
('Stephen', '1910-09-19'),
('John', '2010-01-06')

SELECT NAME,
	DATEDIFF(YEAR, Birthday, GETDATE()) AS 'Age in Years', 
	DATEDIFF(MONTH, Birthday,GETDATE()) AS 'Age in Months', 
	DATEDIFF(DAY,Birthday,GETDATE()) AS 'Age in Days',
	DATEDIFF(MINUTE, Birthday,GETDATE()) AS 'Age in Minutes'
FROM People