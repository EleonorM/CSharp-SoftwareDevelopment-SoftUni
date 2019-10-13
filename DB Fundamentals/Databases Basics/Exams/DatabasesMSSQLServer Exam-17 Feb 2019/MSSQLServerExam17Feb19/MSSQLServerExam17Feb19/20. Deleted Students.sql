CREATE TABLE ExcludedStudents
(StudentId INT,
StudentName VARCHAR(30))
GO

CREATE TRIGGER tr_whenStudentExcluded
ON Students
AFTER DELETE
AS
	INSERT INTO ExcludedStudents
	SELECT Id, CONCAT(FirstName, ' ', LastName)
	FROM deleted