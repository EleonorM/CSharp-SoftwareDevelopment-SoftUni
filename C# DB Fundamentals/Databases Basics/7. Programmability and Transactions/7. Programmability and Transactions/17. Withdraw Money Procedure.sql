CREATE PROC usp_WithdrawMoney (@AccountId INT, @MoneyAmount MONEY)
AS
BEGIN TRANSACTION
	UPDATE Accounts SET Balance -= CAST(@MoneyAmount AS DECIMAL(15,4))
	WHERE Id = @AccountId
	IF(CAST(@MoneyAmount AS DECIMAL(15,4))< 0)
	BEGIN
		ROLLBACK
		RAISERROR('Money should be a positive numebr', 17,1)
		RETURN
	END
COMMIT

EXEC usp_WithdrawMoney 5, 25
SELECT * FROM Accounts