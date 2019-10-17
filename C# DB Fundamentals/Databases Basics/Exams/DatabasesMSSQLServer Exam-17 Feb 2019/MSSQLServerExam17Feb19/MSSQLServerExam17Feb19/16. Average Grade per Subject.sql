SELECT sb.Name, AVG(ss.Grade)
FROM Subjects sb
JOIN StudentsSubjects ss ON ss.SubjectId = sb.Id
GROUP BY sb.Name, sb.ID
ORDER BY sb.Id