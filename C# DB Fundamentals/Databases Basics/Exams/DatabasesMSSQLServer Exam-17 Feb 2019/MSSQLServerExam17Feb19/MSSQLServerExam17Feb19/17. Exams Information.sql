SELECT 
CASE
	WHEN DATEPART(QUARTER, e.Date) = 1 THEN 'Q1'
	WHEN DATEPART(QUARTER, e.Date) = 2 THEN 'Q2'
	WHEN DATEPART(QUARTER, e.Date) = 3 THEN 'Q3'
	WHEN DATEPART(QUARTER, e.Date) = 4 THEN 'Q4'
	ELSE 'TBA'
END AS [Quarter],
s.Name, COUNT(ss.StudentId)
FROM Exams AS e
JOIN Subjects s ON s.Id = e.SubjectId
JOIN StudentsExams ss ON ss.ExamId= e.Id
WHERE ss.Grade >= 4.0
GROUP BY DATEPART(QUARTER, e.Date), s.Name
ORDER BY Quarter, S.Name