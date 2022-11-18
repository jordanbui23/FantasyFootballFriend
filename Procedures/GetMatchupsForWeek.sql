-- Gets the matchups for the given week
CREATE PROCEDURE GetMatchupsForWeek @WeekNumber INT
AS
SELECT *
FROM Schedule
WHERE [Week] = @WeekNumber
GO