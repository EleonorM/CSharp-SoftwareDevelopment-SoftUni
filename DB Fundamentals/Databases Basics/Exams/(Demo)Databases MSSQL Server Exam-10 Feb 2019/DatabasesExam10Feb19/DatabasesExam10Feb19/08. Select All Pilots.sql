SELECT c.Id, CONCAT(c.firstName, ' ', c.LastName) AS full_name
FROM Colonists AS c
JOIN TravelCards AS tc
ON tc.ColonistId = c.Id
WHERE tc.JobDuringJourney = 'Pilot'
ORDER BY c.Id