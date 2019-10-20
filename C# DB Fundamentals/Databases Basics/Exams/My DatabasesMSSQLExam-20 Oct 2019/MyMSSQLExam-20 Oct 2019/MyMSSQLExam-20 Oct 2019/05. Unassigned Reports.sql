SELECT Description,  FORMAT (OpenDate, 'dd-MM-yyyy') as OpenDate
FROM Reports r
WHERE EmployeeId IS NULL
ORDER BY r.OpenDate, Description

SELECT *
FROM Reports
