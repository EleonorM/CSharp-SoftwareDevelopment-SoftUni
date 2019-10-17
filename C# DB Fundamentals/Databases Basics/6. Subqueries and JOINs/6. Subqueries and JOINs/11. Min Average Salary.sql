SELECT MIN(AvgSalary)  AS 'MinAverageSalary'
FROM (SELECT	 AVG(Salary) AS AvgSalary
				FROM Employees AS e
				JOIN Departments AS dep ON e.DepartmentID = dep.DepartmentID
			GROUP BY dep.DepartmentID) AS TestTable