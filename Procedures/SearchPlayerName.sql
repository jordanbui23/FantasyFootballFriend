-- This procedure returns the player with the name if it matches
CREATE PROCEDURE SearchPlayerName @Player NVARCHAR(64)
AS
SELECT * FROM Player
WHERE PlayerName = @Player
GO