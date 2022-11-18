-- Gets the defense stats for all the games played by the team
CREATE PROCEDURE GetDefenseStatsForTeam @Team NVARCHAR(64)
AS
SELECT * FROM WeeklyDefensiveStats
WHERE Team = @Team
GO