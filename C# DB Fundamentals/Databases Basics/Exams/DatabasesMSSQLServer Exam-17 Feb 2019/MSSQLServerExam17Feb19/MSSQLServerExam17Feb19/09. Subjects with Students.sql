SELECT CONCAT(FirstName, ' ' ,LastName) AS FullName,  CONCAT(s.Name,'-', Lessons) AS Subjects, COUNT(st.StudentId) AS Students
FROM Teachers t
JOIN Subjects s ON s.Id = t.SubjectId
JOIN StudentsTeachers st ON st.TeacherId = t.Id
GROUP BY  CONCAT(FirstName, ' ' ,LastName),  CONCAT(s.Name,'-', Lessons)
ORDER BY COUNT(st.StudentId) DESC, FullName, Subjects