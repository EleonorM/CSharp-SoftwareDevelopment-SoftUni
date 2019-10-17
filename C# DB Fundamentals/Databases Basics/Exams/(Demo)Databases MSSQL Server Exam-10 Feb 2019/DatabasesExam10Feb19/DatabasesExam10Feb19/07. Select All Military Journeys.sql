SELECT Id, CONVERT(VARCHAR, JourneyStart, 103), CONVERT(VARCHAR, JourneyEnd, 103)
FROM Journeys
WHERE Purpose = 'Military'
ORDER BY JourneyStart