SELECT TOP(2) DepositGroup
FROM WizzardDeposits AS wD
GROUP BY wD.DepositGroup
ORDER BY AVG(wD.MagicWandSize)