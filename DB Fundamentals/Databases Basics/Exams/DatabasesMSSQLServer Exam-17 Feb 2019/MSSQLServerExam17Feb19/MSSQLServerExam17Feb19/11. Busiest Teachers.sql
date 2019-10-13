SELECT TOP (10) FirstName, LastName, COUNT(st.StudentId) AS StudentsCount
FROM Teachers t
JOIN StudentsTeachers st ON st.TeacherId = t.Id
GROUP BY FirstName, LastName
ORDER BY COUNT(st.StudentId) DESC, FirstName, LastName