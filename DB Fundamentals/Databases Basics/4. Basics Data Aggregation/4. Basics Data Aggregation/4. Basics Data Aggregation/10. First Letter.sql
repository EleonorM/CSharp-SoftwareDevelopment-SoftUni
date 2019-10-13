SELECT LEFT(FirstName, 1) AS FirstLetter
FROM WizzardDeposits AS wd
WHERE wd.DepositGroup = 'Troll Chest'
GROUP BY LEFT(FirstName, 1)