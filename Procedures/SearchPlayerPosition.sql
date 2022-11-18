-- This procedure returns players with the position
CREATE PROCEDURE SearchPlayerPosition @Position NVARCHAR(64)
AS
SELECT * FROM Player
WHERE Position = @Position
GO