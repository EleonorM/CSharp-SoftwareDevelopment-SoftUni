UPDATE Reports SET CloseDate = GETDATE()
FROM Reports 
WHERE CloseDate IS NULL

SELECT *
FROM Reports

WHERE CloseDate IS NULL
