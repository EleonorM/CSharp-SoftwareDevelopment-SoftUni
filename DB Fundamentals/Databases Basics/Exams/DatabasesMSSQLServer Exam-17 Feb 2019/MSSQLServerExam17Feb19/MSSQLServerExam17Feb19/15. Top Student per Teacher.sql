SELECT t.FirstName, sb.Name, s.FirstName, 
	DENSE_RANK() OVER(PARTITION BY sb.Name ORDER BY (SELECT AVG(ss.GRADE) FROM Teachers t
							JOIN Subjects sb ON sb.Id = t.SubjectId
							JOIN StudentsSubjects ss ON ss.SubjectId = sb.Id
							JOIN Students s ON s.Id = ss.StudentId
							GROUP BY sb.Id, s.ID)) AS [Rank]
FROM Teachers t
JOIN Subjects sb ON sb.Id = t.SubjectId
JOIN StudentsSubjects ss ON ss.SubjectId = sb.Id
JOIN Students s ON s.Id = ss.StudentId