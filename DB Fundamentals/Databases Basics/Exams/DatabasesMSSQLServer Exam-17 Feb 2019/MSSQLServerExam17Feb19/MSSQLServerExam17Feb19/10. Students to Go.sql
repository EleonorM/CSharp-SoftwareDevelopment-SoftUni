SELECT CONCAT(FirstName, ' ' ,LastName) AS FullName
FROM Students s
LEFT JOIN StudentsExams se ON se.StudentId = s.Id
WHERE se.ExamId IS NULL
ORDER BY FullName