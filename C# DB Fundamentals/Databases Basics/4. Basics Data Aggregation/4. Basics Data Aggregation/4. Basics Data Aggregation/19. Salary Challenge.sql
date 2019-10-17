SELECT TOP(10) FirstName, LastName, DepartmentID
FROM Employees AS E
WHERE Salary > (SELECT AVG(SALARY)
				FROM Employees AS EM
				WHERE E.DepartmentID = EM.DepartmentID
				GROUP BY DepartmentID)
ORDER BY DepartmentID