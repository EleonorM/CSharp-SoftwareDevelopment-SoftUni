SELECT w.DepositGroup,
SUM(w.DepositAmount) AS TotalSum
FROM WizzardDeposits AS w
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY w.DepositGroup