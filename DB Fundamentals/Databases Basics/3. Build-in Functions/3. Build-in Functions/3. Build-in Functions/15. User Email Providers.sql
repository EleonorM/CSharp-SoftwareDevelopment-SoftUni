SELECT Username, SUBSTRING(Email, CHARINDEX('@', Email,1)+1,100) AS 'Email Provider'
FROM USERS
ORDER BY 'Email Provider', Username