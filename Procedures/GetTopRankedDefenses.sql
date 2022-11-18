--Top ranking defenses for the week

CREATE PROCEDURE GetTopRankedDefenses @WeekNumber INT
AS
SELECT WDS.Team, WDS.StandardFantasyPoints,
	RANK () OVER(
		ORDER BY WDS.StandardFantasyPoints DESC
	) AS 'Team Rank', S.[Week]
FROM WeeklyDefensiveStats WDS
	INNER JOIN Schedule S ON S.GameId = WDS.GameId
WHERE [Week] = @WeekNumber
GROUP BY WDS.Team, WDS.StandardFantasyPoints, S.[Week]
ORDER BY WDS.StandardFantasyPoints DESC
GO
