SELECT  t2.[Teacher Full Name],
		t2.[Subject Name],
		t2.[Student Full Name],
		t2.[Grade]
FROM
(SELECT  t1.[Teacher Full Name],
		t1.[Subject Name],
		t1.[Student Full Name],
		t1.[Grade],
		ROW_NUMBER() OVER(PARTITION BY t1.[Teacher Full Name] ORDER BY t1.[Grade] DESC) AS [Row] 
FROM
(SELECT CONCAT(t.FirstName, ' ',t.LastName) AS [Teacher Full Name],
			sb.Name AS [Subject Name],
			CONCAT(s.FirstName,' ', s.LastName) AS [Student Full Name],
			CONVERT( DECIMAL(15,2),AVG(ss.Grade)) AS [Grade] 
										 FROM  Teachers t 
										 JOIN Subjects sb ON t.SubjectId = sb.Id
										 JOIN StudentsSubjects ss ON sb.Id = ss.SubjectId
										 JOIN Students s ON s.Id = ss.StudentId
										 JOIN StudentsTeachers AS st ON s.Id = st.StudentId AND t.Id = st.TeacherId
							GROUP BY t.FirstName, T.LastName,sb.Name, S.FirstName, s.LastName) AS t1) AS t2
WHERE t2.Row = 1
ORDER BY t2.[Subject Name], t2.[Teacher Full Name], t2.[Grade]
GO