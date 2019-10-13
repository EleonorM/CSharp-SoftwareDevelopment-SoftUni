SELECT SUM(ISNULL([Host Wizard Deposit] - [Guest Wizard Deposit], 0)) as SumDifference
from(
SELECT FirstName AS [Host Wizard], DepositAmount AS [Host Wizard Deposit], 
LEAD(FirstName) OVER (
ORDER By Id
 ) As 'Guest Wizard',
 LEAD(DepositAmount) OVER (
ORDER By Id
 ) As 'Guest Wizard Deposit'
FROM WizzardDeposits)
AS NewTable
