DELETE
FROM StudentsTeachers
WHERE TeacherId IN (SELECT Id FROM Teachers
WHERE Phone LIKE '%72%')

DELETE
FROM Reports
WHERE [StatusId] = 4