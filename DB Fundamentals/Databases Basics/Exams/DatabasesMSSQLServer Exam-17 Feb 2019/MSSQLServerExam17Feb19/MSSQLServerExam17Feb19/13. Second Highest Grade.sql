SELECT FirstName, LastName, Grade
FROM (SELECT s.Id, FirstName, LastName, ROW_NUMBER() OVER(PARTITION BY S.Id ORDER BY GRADE DESC) AS [Rank], Grade
	FROM Students s
	JOIN StudentsSubjects ss ON ss.StudentId = s.Id) AS t
WHERE [Rank] = 2
ORDER BY FirstName, LastName
