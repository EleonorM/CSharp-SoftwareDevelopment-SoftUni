CREATE FUNCTION udf_ExamGradesToUpdate(@studentId INT, @grade DECIMAL(15,2))
RETURNS VARCHAR(80)
AS
BEGIN
	DECLARE @result VARCHAR(80)
	DECLARE @count INT
	DECLARE @studentName VARCHAR(50)
	IF(@grade > 6.00)
	BEGIN
	SET @result = 'Grade cannot be above 6.00!'
	END
	ELSE IF ((SELECT COUNT(Id) FROM Students WHERE Id = @studentId) = 0)
	BEGIN
	SET @result = 'The student with provided id does not exist in the school!'
	END
	ELSE
	BEGIN
	SET @count =(SELECT COUNT(*) FROM Students S
						  JOIN StudentsExams se ON se.StudentId = s.Id 
						  WHERE s.ID = @studentId AND se.Grade BETWEEN @grade AND @grade+0.5)
	SET @studentName = (SELECT FirstName FROM Students S
						  WHERE s.ID = @studentId)
	SET @result = CONCAT('You have to update ', @count, ' grades for the student ', @studentName)
	END
	RETURN @result
END