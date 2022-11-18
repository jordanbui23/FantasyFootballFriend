
CREATE PROCEDURE InsertWeeklyDefensiveStats
	@WeeklyId INT,
	@GameId INT ,
	@Team NVARCHAR(50),
	@Sacks INT ,
	@Interceptions INT,
	@FumblesRecovered INT,
	@FumblesForced INT ,
	@DefensiveTouchdowns INT ,
	@Safeties INT ,
	@SpecialTeamsTouchdowns INT,
	@StandardFantasyPoints INT
AS
INSERT INTO WeeklyDefensiveStats (WeeklyId, GameId, Team, Sacks, Interceptions, 
FumblesRecovered, FumblesForced, DefensiveTouchdowns, Safeties, SpecialTeamsTouchdowns, StandardFantasyPoints)
VALUES (@WeeklyId, @GameId, @Team, @Sacks, @Interceptions, @FumblesRecovered, @FumblesForced, @DefensiveTouchdowns, 
@Safeties, @SpecialTeamsTouchdowns, @StandardFantasyPoints)
GO
