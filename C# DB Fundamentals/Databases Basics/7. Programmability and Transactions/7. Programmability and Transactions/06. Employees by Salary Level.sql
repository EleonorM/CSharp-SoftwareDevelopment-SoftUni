CREATE PROC usp_EmployeesBySalaryLevel  (@levelOfSalary NVARCHAR(10))
AS
	SELECT FirstName, LastName
	FROM Employees AS e
	WHERE [dbo].[ufn_GetSalaryLevel](e.Salary) = @levelOfSalary
