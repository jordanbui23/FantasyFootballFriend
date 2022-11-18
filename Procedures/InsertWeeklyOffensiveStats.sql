--Insert statment for Weekly Offensive Stats
CREATE PROCEDURE InsertWeeklyOffensiveStats
	@OffensiveStatId INT,
	@PlayerId INT,
	@PassingYards INT,
	@PassingTouchdowns INT ,
	@PassingAttempts INT ,
	@Completions INT,
	@RushingAttempts INT,
	@RushingYards INT,
	@RushingTouchdowns INT,
	@Receptions INT,
	@Targets INT ,
	@ReceivingYards INT,
	@ReceivingTouchdowns INT,
	@FumblesLost INT,
	@StandardFantasyPoints FLOAT,
	@GameId INT
AS
INSERT INTO WeeklyOffensiveStats (OffensiveStatId, PlayerId, PassingYards, PassingTouchdowns, PassingAttempts, Completions, RushingAttempts, RushingYards, 
RushingTouchdowns, Receptions, Targets, ReceivingYards, ReceivingTouchdowns, FumblesLost, StandardFantasyPoints, GameId)

VALUES (@OffensiveStatId, @PlayerId, @PassingYards, @PassingTouchdowns,@PassingAttempts,@Completions,@RushingAttempts, @RushingYards, @RushingTouchdowns,
	@Receptions, @Targets, @ReceivingYards, @ReceivingTouchdowns, @FumblesLost, @StandardFantasyPoints, @GameId)
GO