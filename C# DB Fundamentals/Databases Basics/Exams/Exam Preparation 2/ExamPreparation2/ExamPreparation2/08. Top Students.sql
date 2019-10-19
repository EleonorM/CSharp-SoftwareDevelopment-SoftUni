SELECT TOP(10) FirstName, LastName,  CAST(AVG(Grade) AS DECIMAL(10,2)) AS Grade
FROM Students s
JOIN StudentsExams se ON se.StudentId = s.Id
GROUP BY FirstName, LastName
ORDER BY AVG(Grade) DESC, FirstName, LastName