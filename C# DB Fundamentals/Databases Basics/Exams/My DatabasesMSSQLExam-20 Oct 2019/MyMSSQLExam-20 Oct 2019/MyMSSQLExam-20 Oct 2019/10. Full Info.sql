SELECT IIF(e.FirstName IS NOT NULL AND e.LastName IS NOT NULL, CONCAT(e.FirstName,' ', e.LastName), 'None') AS FullName, 
	IIF(D.NAME IS NOT NULL, D.NAME, 'None'),
	c.Name, 
	r.Description, 
	FORMAT (OpenDate, 'dd.MM.yyyy') as OpenDate, 
	s.Label, 
	u.Name
FROM Reports r
LEFT JOIN Employees e ON r.EmployeeId = e.Id
LEFT JOIN Status s ON R.StatusId = s.Id
LEFT JOIN Categories c ON r.CategoryId = c.Id
LEFT JOIN Departments d ON E.DepartmentId = d.Id
LEFT JOIN Users u ON u.Id = r.UserId
ORDER BY e.FirstName DESC, e.LastName DESC, d.Name, c.Name, 
	r.Description, OpenDate, s.Label, 
	u.Name