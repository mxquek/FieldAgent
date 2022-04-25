CREATE PROCEDURE [TopAgents]
AS
BEGIN

SELECT TOP (3)
    a.AgentId,
    Count(m.MissionId) 'NumberOfMissions'
FROM Agent a
INNER JOIN MissionAgent ma ON a.AgentId = ma.AgentId
INNER Join Mission m ON ma.MissionId = m.MissionId
WHERE m.ActualEndDate IS NOT NULL
GROUP BY a.AgentId
ORDER BY NumberOfMissions DESC;

END