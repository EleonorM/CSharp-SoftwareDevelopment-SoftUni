SELECT SS.Name, SS.Manufacturer
FROM Colonists AS c
JOIN TravelCards AS tc
ON tc.ColonistId = c.Id
JOIN Journeys AS j
ON j.Id = tc.JourneyId
JOIN Spaceships AS ss
ON ss.Id = j.SpaceshipId
WHERE DATEDIFF(YEAR, c.BirthDate, '2019-01-01') < 30 AND tc.JobDuringJourney = 'Pilot'
ORDER BY ss.Name