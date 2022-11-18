

SELECT * FROM WeeklyOffensiveStats O
INNER JOIN Player P ON P.PlayerId = O.PlayerId


ALTER TABLE WeeklyOffensiveStats
DROP COLUMN Interceptions;

SELECT * FROM DefensiveWeeklyStats


-- First Query
CREATE OR ALTER PROCEDURE SearchPlayer
	@Player NVARCHAR(64)
AS
SELECT * FROM Player P
WHERE P.PlayerName = @Player


SELECT * FROM Player P
WHERE P.PlayerName = 'josh allen'

DECLARE 
	