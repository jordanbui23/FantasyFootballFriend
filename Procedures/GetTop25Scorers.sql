-- Returns the TOP 25 Scoreres for a given week
CREATE PROCEDURE GetTop25Scorers @WeekNumber INT
AS
SELECT OWS.PlayerID, P.PlayerName,P.Position, P.Team, ROUND(OWS.StandardFantasyPoints, 2) AS TotalPoints, S.[Week], S.Stadium, 
	SUM(OWS.PassingTouchdowns + OWS.RushingTouchdowns + OWS.ReceivingTouchdowns) AS TouchDownsScored
FROM WeeklyOffensiveStats OWS
	INNER JOIN Player P ON P.PlayerId = OWS.PlayerID
	INNER JOIN Schedule S ON S.GameId =  OWS.GameId 
WHERE S.[Week] = @WeekNumber 
GROUP BY OWS.PlayerID, StandardFantasyPoints, S.[Week], P.PlayerName, P.Team, P.Position, S.Stadium
ORDER BY TotalPoints DESC
OFFSET 0 ROWS
FETCH NEXT 25 ROWS ONLY;
GO