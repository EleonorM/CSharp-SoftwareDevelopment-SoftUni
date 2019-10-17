  SELECT e.EmployeeID, e.FirstName, mng.EmployeeID, mng.FirstName
	FROM Employees AS e
	JOIN Employees AS mng ON e.ManagerID = mng.EmployeeID
   WHERE mng.EmployeeID IN (3,7)
ORDER BY e.EmployeeID