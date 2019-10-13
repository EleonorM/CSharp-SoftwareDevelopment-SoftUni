SELECT TOP(1) j.Id, tc.JobDuringJourney
FROM Journeys AS j
JOIN TravelCards AS tc
ON tc.JourneyId = j.Id
JOIN Colonists AS c
ON tc.ColonistId = c.Id
ORDER BY DENSE_RANK() OVER(ORDER BY j.JourneyEnd - j.JourneyStart DESC)