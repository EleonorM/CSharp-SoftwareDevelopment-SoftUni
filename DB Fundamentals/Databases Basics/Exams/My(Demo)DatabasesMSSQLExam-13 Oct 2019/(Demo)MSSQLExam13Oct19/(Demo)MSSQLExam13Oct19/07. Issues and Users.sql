SELECT i.ID, CONCAT(u.Username, ' : ', i.Title) AS IssueAssignee
FROM Issues i
JOIN Users u ON u.Id = i.AssigneeId
ORDER BY i.Id DESC, u.Id 