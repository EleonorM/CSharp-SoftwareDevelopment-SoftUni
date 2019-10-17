SELECT e.DepartmentID, MIN(e.Salary) AS MinimumSalary
FROM Employees e
WHERE HireDate > '01/01/2000'
GROUP BY e.DepartmentID
HAVING DepartmentID IN (2,5,7) 