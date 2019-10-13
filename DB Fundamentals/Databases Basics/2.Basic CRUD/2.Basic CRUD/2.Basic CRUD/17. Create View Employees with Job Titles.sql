CREATE VIEW V_EmployeeNameJobTitle AS
SELECT FirstName + ' '+
CASE
    WHEN MiddleName IS NULL THEN ''
	ELSE MiddleName
END
 + ' '+ LastName AS FullName, JobTitle
FROM Employees