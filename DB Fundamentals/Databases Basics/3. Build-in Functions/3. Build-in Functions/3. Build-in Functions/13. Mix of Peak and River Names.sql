SELECT PeakName, RiverName,	LOWER(CONCAT(SUBSTRING(PeakName,1,LEN(PeakName)-1), RiverName)) AS Mix
FROM Peaks AS p
JOIN Rivers AS r
ON RIGHT( p.PeakName, 1)=LEFT (r.RiverName,1)
ORDER BY Mix