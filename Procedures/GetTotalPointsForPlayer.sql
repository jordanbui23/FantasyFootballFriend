-- Total Points for a given player
CREATE PROCEDURE GetTotalPointsForPlayer @SelectedPlayer NVARCHAR(64)
AS
SELECT OWS.PlayerId, P.PlayerName, Round(SUM(OWS.StandardFantasyPoints), 2) AS TotalPoints, P.Team
FROM WeeklyOffensiveStats OWS
	INNER JOIN Player P ON P.PlayerId = OWS.PlayerId
WHERE P.PlayerName = @SelectedPlayer
GROUP BY OWS.PlayerId, P.PlayerName, P.Team
ORDER BY TotalPoints DESC
GO