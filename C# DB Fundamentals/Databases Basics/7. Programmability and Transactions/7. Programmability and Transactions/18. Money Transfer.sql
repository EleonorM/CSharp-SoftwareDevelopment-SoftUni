CREATE or alter PROC usp_TransferMoney(@SenderId INT, @ReceiverId INT, @Amount MONEY)
AS
BEGIN TRANSACTION
	EXEC usp_DepositMoney @ReceiverId, @Amount
	EXEC usp_WithdrawMoney @SenderId, @Amount
	IF(CAST(@Amount AS DECIMAL(15,4))< 0)
	BEGIN
		ROLLBACK
		RAISERROR('Money should be a positive numebr', 16,1)
		RETURN
	END
COMMIT