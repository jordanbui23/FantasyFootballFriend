-- Gets the offensive stats for a player id
CREATE PROCEDURE GetOffenseStatsWithPlayerId @PlayerId INT
AS
SELECT * FROM WeeklyOffensiveStats
WHERE PlayerId = @PlayerId
GO