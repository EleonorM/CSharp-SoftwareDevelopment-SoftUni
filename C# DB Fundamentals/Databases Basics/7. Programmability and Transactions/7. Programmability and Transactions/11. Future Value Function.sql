CREATE FUNCTION ufn_CalculateFutureValue (@sum DECIMAL(15,2), @yearlyInterestRate FLOAT, @numberOfYears INT)
RETURNS DECIMAL(15,4)
AS
BEGIN
	DECLARE @output DECIMAL(15,4)
	SET @output = @sum * POWER((1+@yearlyInterestRate),@numberOfYears)
	RETURN @output
END