SELECT * INTO TestTable
FROM Employees
WHERE Salary > 30000

DELETE 
FROM TestTable
WHERE ManagerID = 42

UPDATE TestTable
SET Salary += 5000
WHERE DepartmentID=1

SELECT DepartmentID, AVG(Salary) AS AverageSalary
FROM TestTable
GROUP BY DepartmentID