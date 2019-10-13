CREATE TABLE NotificationEmails
(Id INT IDENTITY,
Recipient INT,
[Subject] VARCHAR(100),
Body VARCHAR(200))
GO

CREATE TRIGGER tr_notificationEmails
ON Logs
FOR INSERT
AS
BEGIN
    INSERT INTO NotificationEmails 
	(Recipient, [Subject], Body)
	SELECT AccountId,
	 'Balance change for account: ' + CONVERT(VARCHAR,AccountId),
	 'On ' + convert(varchar, getdate(), 0) +' your balance was changed from '+ CONVERT(VARCHAR,OldSum) + 'to' + CONVERT(VARCHAR,NewSum) + '.'
	FROM inserted
END
GO

UPDATE Accounts
SET Balance += 10
WHERE Id = 1 

SELECT * FROM Logs
SELECT * FROM NotificationEmails
