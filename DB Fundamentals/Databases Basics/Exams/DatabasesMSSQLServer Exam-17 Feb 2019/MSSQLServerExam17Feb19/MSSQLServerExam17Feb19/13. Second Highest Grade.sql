SELECT  FirstName, LastName, Grade
FROM (SELECT FirstName, LastName, DENSE_RANK() OVER(PARTITION BY S.FirstName ORDER BY GRADE DESC) AS [Rank], Grade
	FROM Students s
	JOIN StudentsSubjects ss ON ss.StudentId = s.Id) AS t
WHERE [Rank] = 2
ORDER BY FirstName, LastName
