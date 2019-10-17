SELECT DepartmentID, MAX(salary) AS ThirdHighestSalary
  FROM Employees AS E
WHERE Salary < (SELECT MAX(Salary) 
						FROM Employees AS EM
						WHERE E.DepartmentID = EM.DepartmentID
						AND Salary < (SELECT MAX(Salary) 
										FROM Employees AS EM
									   WHERE E.DepartmentID = EM.DepartmentID
									GROUP BY DepartmentID)
						GROUP BY DepartmentID)
GROUP BY DepartmentID

--OTHER SOLUTION

SELECT DepartmentID,Salary AS[ThirdHighestSalary]
FROM(
SELECT DepartmentID, Salary, DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS Ranking
FROM EMPLOYEES
GROUP BY DepartmentID,Salary) AS [RankTable]
WHERE Ranking = 3
