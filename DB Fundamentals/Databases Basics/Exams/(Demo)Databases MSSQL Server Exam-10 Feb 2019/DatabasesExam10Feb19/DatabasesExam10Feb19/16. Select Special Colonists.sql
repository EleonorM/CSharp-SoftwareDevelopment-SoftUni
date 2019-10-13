SELECT * 
FROM( SELECT tc.JobDuringJourney,
	CONCAT(c.FirstName, ' ', c.LastName) AS FullName, 
	DENSE_RANK() OVER(PARTITION BY tc.JobDuringJourney ORDER BY c.BirthDate ASC) AS JobRank
FROM Journeys AS j
JOIN TravelCards AS tc
ON tc.JourneyId = j.Id
JOIN Colonists AS c
ON tc.ColonistId = c.Id) AS Temp
WHERE JobRank = 2
