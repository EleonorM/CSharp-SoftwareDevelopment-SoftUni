SELECT 
CASE
    WHEN  s.MiddleName IS NOT NULL THEN CONCAT(FirstName, ' ', MiddleName, ' ' ,LastName)
    ELSE CONCAT(FirstName, ' ' ,LastName)
END AS FullName
FROM Students s
LEFT JOIN StudentsSubjects ss ON ss.StudentId = s.Id
WHERE SubjectId IS NULL
ORDER BY FullName