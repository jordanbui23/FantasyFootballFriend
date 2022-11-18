--INSERT PLAYER INTO PlayerTable
CREATE PROCEDURE InsertPlayer
	@PlayerName NVARCHAR(50) ,
	@PlayerId INT,
	@EspnId INT ,
	@Position NVARCHAR(50)  ,
	@Team NVARCHAR(50)  
AS
INSERT INTO Player (PlayerName, PlayerId, EspnId, Position, Team)
VALUES (@PlayerName, @PlayerId, @EspnId, @Position, @Team)
GO
