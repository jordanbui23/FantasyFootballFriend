using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace FantasyFootballFriend {
    public class Model {
        private string database;
        public Model(string database) {
            this.database = database;
        }

        /// <summary>
        /// Returns all players
        /// </summary>
        /// <returns></returns>
        public List<Player> GetPlayers(string name, string position) {
            using (SqlConnection connection = new SqlConnection(database)) {
                if (name == "" && position == "") {
                    using (SqlCommand command = new SqlCommand("SELECT * FROM Player;", connection)) {
                        command.CommandType = CommandType.Text;
                        connection.Open();
                        using (var data = command.ExecuteReader())
                            return ConvertPlayerList(data);
                    }
                } else if (name != "" && position != "") {
                    using (SqlCommand command = new SqlCommand("SearchPlayerName", connection)) {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("PlayerName", name);
                        connection.Open();
                        using (var data = command.ExecuteReader())
                            return ConvertPlayerList(data);
                    }
                } else if (name != "") {
                    using (SqlCommand command = new SqlCommand("SearchPlayerName", connection)) {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("Player", name);
                        connection.Open();
                        using (var data = command.ExecuteReader())
                            return ConvertPlayerList(data);
                    }
                } else if (position != "") {
                    using (SqlCommand command = new SqlCommand("SearchPlayerPosition", connection)) {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("Position", position);
                        connection.Open();
                        using (var data = command.ExecuteReader())
                            return ConvertPlayerList(data);
                    }
                } else {
                    MessageBox.Show("Something went really wrong");
                    return new List<Player>();
                }
            }
        }
 
        public List<Player> ConvertPlayerList(SqlDataReader dataReader) {
            List<Player> players = new List<Player>();
            int PlayerID = dataReader.GetOrdinal("PlayerID");
            int PlayerName = dataReader.GetOrdinal("PlayerName");
            int Team = dataReader.GetOrdinal("Team");
            int Position = dataReader.GetOrdinal("Position");
            while (dataReader.Read()) {
                Player player = new Player();
                player.PlayerID = dataReader.GetInt16(PlayerID);
                player.PlayerName = dataReader.GetString(PlayerName);
                player.Team = dataReader.GetString(Team);
                try {
                    player.Position = dataReader.GetString(Position);
                } catch (Exception e) {
                    player.Position = "N/A";
                }
                players.Add(player);
            }
            return players;
        }

        public List<string[]> GetTop(int week) {
            using (SqlConnection connection = new SqlConnection(database)) {
                using (SqlCommand command = new SqlCommand("GetTop25Scorers", connection)) {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("WeekNumber", week);
                    connection.Open();
                    using (var dataReader = command.ExecuteReader()) {
                        List<string[]> ret = new List<string[]>();
                        int PlayerID = dataReader.GetOrdinal("PlayerID");
                        int PlayerName = dataReader.GetOrdinal("PlayerName");
                        int Position = dataReader.GetOrdinal("Position");
                        int Team = dataReader.GetOrdinal("Team");
                        int TotalPoints = dataReader.GetOrdinal("TotalPoints");
                        int Week = dataReader.GetOrdinal("Week");
                        int Stadium = dataReader.GetOrdinal("Stadium");
                        int Touchdowns = dataReader.GetOrdinal("TouchDownsScored");
                        while (dataReader.Read()) {
                            string[] temp = new string[8];
                            temp[0] = (dataReader.GetInt32(PlayerID).ToString());
                            temp[1] = (dataReader.GetString(PlayerName).ToString());
                            temp[2] = (dataReader.GetString(Position).ToString());
                            temp[3] = (dataReader.GetString(Team).ToString());
                            temp[4] = (dataReader.GetDouble(TotalPoints).ToString());
                            temp[5] = (dataReader.GetInt32(Week).ToString());
                            temp[6] = (dataReader.GetString(Stadium).ToString());
                            temp[7] = (dataReader.GetInt32(Touchdowns).ToString());
                            ret.Add(temp);
                        }
                        return ret;
                    }
                }
                
            }
        }

        public List<Schedule> GetMatchups(int week) {
            using (SqlConnection connection = new SqlConnection(database)) {
                using (SqlCommand command = new SqlCommand("GetMatchupsForWeek", connection)) {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("WeekNumber", week);
                    connection.Open();
                    using (var dataReader = command.ExecuteReader()) {
                        List<Schedule> schedule = new List<Schedule>();
                        int GameId = dataReader.GetOrdinal("GameId");
                        int Week = dataReader.GetOrdinal("Week");
                        int HomeTeam = dataReader.GetOrdinal("HomeTeam");
                        int AwayTeam = dataReader.GetOrdinal("AwayTeam");
                        int Stadium = dataReader.GetOrdinal("Stadium");
                        while (dataReader.Read()) {
                            Schedule player = new Schedule();
                            player.GameId = dataReader.GetInt32(GameId);
                            player.Week = dataReader.GetInt32(Week);
                            player.HomeTeam = dataReader.GetString(HomeTeam);
                            player.AwayTeam = dataReader.GetString(AwayTeam);
                            player.Stadium = dataReader.GetString(Stadium);
                            schedule.Add(player);
                        }
                        return schedule;
                    }
                }
            }
        }

        public List<WeeklyDefensiveStats> GetDefense(string team) {
            using (SqlConnection connection = new SqlConnection(database)) {
                using (SqlCommand command = new SqlCommand("GetDefenseStatsForTeam", connection)) {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("Team", team);
                    connection.Open();
                    using (var dataReader = command.ExecuteReader()) {
                        List<WeeklyDefensiveStats> w = new List<WeeklyDefensiveStats>();
                        int WeeklyId = dataReader.GetOrdinal("WeeklyId");
                        int GameId = dataReader.GetOrdinal("GameId");
                        int Team = dataReader.GetOrdinal("Team");
                        int Sacks = dataReader.GetOrdinal("Sacks");
                        int Interceptions = dataReader.GetOrdinal("Interceptions");
                        int FumblesRecovered = dataReader.GetOrdinal("FumblesRecovered");
                        int FumblesForced = dataReader.GetOrdinal("FumblesForced");
                        int DefensiveTouchdowns = dataReader.GetOrdinal("DefensiveTouchdowns");
                        int Safeties = dataReader.GetOrdinal("Safeties");
                        int SpecialTeamsTouchdowns = dataReader.GetOrdinal("SpecialTeamsTouchdowns");
                        int StandardFantasyPoints = dataReader.GetOrdinal("StandardFantasyPoints");
                        while (dataReader.Read()) {
                            WeeklyDefensiveStats wts = new WeeklyDefensiveStats();
                            wts.WeeklyId = dataReader.GetInt32(WeeklyId);
                            wts.GameId = dataReader.GetInt32(GameId);
                            wts.Team = dataReader.GetString(Team);
                            wts.Sacks = dataReader.GetInt32(Sacks);
                            wts.Interceptions = dataReader.GetInt32(Interceptions);
                            wts.FumblesRecovered = dataReader.GetInt32(FumblesRecovered);
                            wts.FumblesForced = dataReader.GetInt32(FumblesForced);
                            wts.DefensiveTouchdowns = dataReader.GetInt32(DefensiveTouchdowns);
                            wts.Safeties = dataReader.GetInt32(Safeties);
                            wts.SpecialTeamsTouchdowns = dataReader.GetInt32(SpecialTeamsTouchdowns);
                            wts.StandardFantasyPoints = dataReader.GetInt32(StandardFantasyPoints);
                            w.Add(wts);
                        }
                        return w;
                    }
                }
            }
        }

        public List<WeeklyOffensiveStats> GetOffense(int id) {
            using (SqlConnection connection = new SqlConnection(database)) {
                using (SqlCommand command = new SqlCommand("GetOffenseStatsWithPlayerId", connection)) {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("PlayerId", id);
                    connection.Open();
                    using (var dataReader = command.ExecuteReader()) {
                        List<WeeklyOffensiveStats> w = new List<WeeklyOffensiveStats>();
                        int OffensiveStatId = dataReader.GetOrdinal("OffensiveStatId");
                        int PlayerId = dataReader.GetOrdinal("PlayerId");
                        int PassingYards = dataReader.GetOrdinal("PassingYards");
                        int PassingTouchdowns = dataReader.GetOrdinal("PassingTouchdowns");
                        int PassingAttempts = dataReader.GetOrdinal("PassingAttempts");
                        int Completions = dataReader.GetOrdinal("Completions");
                        int RushingAttempts = dataReader.GetOrdinal("RushingAttempts");
                        int RushingYards = dataReader.GetOrdinal("RushingYards");
                        int RushingTouchdowns = dataReader.GetOrdinal("RushingTouchdowns");
                        int Receptions = dataReader.GetOrdinal("Receptions");
                        int Targets = dataReader.GetOrdinal("Targets");
                        int ReceivingYards = dataReader.GetOrdinal("ReceivingYards");
                        int ReceivingTouchdowns = dataReader.GetOrdinal("ReceivingTouchdowns");
                        int FumblesLost = dataReader.GetOrdinal("FumblesLost");
                        int StandardFantasyPoints = dataReader.GetOrdinal("StandardFantasyPoints");
                        int GameId = dataReader.GetOrdinal("GameId");
                        while (dataReader.Read()) {
                            WeeklyOffensiveStats wts = new WeeklyOffensiveStats();
                            wts.OffensiveStatId = dataReader.GetInt32(OffensiveStatId);
                            wts.PlayerId = dataReader.GetInt32(PlayerId);
                            wts.PassingYards = dataReader.GetInt32(PassingYards);
                            wts.PassingTouchdowns = dataReader.GetInt32(PassingTouchdowns);
                            wts.PassingAttempts = dataReader.GetInt32(PassingAttempts);
                            wts.Completions = dataReader.GetInt32(Completions);
                            wts.RushingAttempts = dataReader.GetInt32(RushingAttempts);
                            wts.RushingYards = dataReader.GetInt32(RushingYards);
                            wts.RushingTouchdowns = dataReader.GetInt32(RushingTouchdowns);
                            wts.Receptions = dataReader.GetInt32(Receptions);
                            wts.Targets = dataReader.GetInt32(Targets);
                            wts.ReceivingYards = dataReader.GetInt32(ReceivingYards);
                            wts.ReceivingTouchdowns = dataReader.GetInt32(ReceivingTouchdowns);
                            wts.FumblesLost = dataReader.GetInt32(FumblesLost);
                            wts.StandardFantasyPoints = dataReader.GetDouble(StandardFantasyPoints);
                            wts.GameId = dataReader.GetInt32(GameId);
                            w.Add(wts);
                        }
                        return w;
                    }
                }
            }
        }
    }
}
