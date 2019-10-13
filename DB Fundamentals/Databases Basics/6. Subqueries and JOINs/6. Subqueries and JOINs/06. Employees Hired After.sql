   SELECT e.FirstName, e.LastName, e.HireDate, dep.Name
	 FROM Employees AS e
LEFT JOIN Departments AS dep ON e.DepartmentID = dep.DepartmentID
    WHERE e.HireDate > '1.1.1999 ' AND dep.Name = 'Sales' OR dep.Name = 'Finance'
 ORDER BY e.HireDate