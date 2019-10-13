  SELECT TOP(50) e.EmployeeID, e.FirstName + ' ' + e.LastName AS 'EmployeeName', mng.FirstName + ' ' + mng.LastName AS 'ManagerName', dep.Name
	FROM Employees AS e
	JOIN Employees AS mng ON e.ManagerID = mng.EmployeeID
	JOIN Departments AS dep ON e.DepartmentID = dep.DepartmentID
ORDER BY e.EmployeeID