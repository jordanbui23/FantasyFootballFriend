CREATE PROCEDURE InsertSchedule
	@GameId INT,
	@Week INT,
	@AwayTeam NVARCHAR(50),
	@HomeTeam NVARCHAR(50),
	@Stadium NVARCHAR(50)
AS
INSERT INTO Schedule (GameId, [Week], AwayTeam, HomeTeam, Stadium)
VALUES(@GameId, @Week, @AwayTeam, @HomeTeam, @Stadium)
GO