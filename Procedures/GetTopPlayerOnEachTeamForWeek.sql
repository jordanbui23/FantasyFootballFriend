--Top Player on each team for given week
CREATE PROCEDURE GetTopPlayerOnEachTeamForWeek @WeekNumber INT
AS
SELECT P.PlayerName AS 'Highest Scorer On Team', ROUND(OWS.StandardFantasyPoints,2) AS TotalPoints, P.Team
FROM WeeklyOffensiveStats OWS
	INNER JOIN Player P ON P.PlayerId = OWS.PlayerId
	INNER JOIN Schedule S ON S.GameId = OWS.GameId
WHERE S.[Week] = @WeekNumber
GROUP BY P.PlayerName, P.Team, OWS.StandardFantasyPoints
ORDER BY OWS.StandardFantasyPoints DESC
OFFSET 0 ROWS
FETCH NEXT 32 ROWS ONLY;
GO