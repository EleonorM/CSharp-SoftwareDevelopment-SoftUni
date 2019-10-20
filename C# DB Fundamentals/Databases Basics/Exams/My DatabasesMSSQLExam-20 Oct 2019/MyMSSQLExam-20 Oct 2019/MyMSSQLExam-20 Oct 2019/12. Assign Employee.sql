CREATE OR ALTER PROC usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT) 
AS
BEGIN TRANSACTION 
	DECLARE @employeeDepartement INT
	DECLARE @reportDepartmen INT
	SET @employeeDepartement = (SELECT DepartmentId
								FROM Employees WHERE Id = @EmployeeId)
	SET @reportDepartmen = (SELECT C.DepartmentId 
								FROM Reports r
								JOIN Categories c ON c.ID = r.CategoryId
								WHERE r.Id = @ReportId)
	
	IF(@reportDepartmen = @employeeDepartement)
	BEGIN
		UPDATE Reports SET EmployeeId = @EmployeeId
		FROM Reports
		WHERE Id = @ReportId
	END
	 ELSE
	 BEGIN
		THROW 50001, 'Employee doesn''t belong to the appropriate department!', 1;
	 END
	
COMMIT
GO

EXEC usp_AssignEmployeeToReport 30, 1
