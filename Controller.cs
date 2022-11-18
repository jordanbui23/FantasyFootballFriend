using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Transactions;

namespace FantasyFootballFriend {
    public class Controller {
        Model Model;

        public Controller() {
            Model = new Model(@"Server=(localdb)\MSSQLLocalDb;Database=Fantasy;Integrated Security=SSPI;");
        }

        public List<Player> SearchPlayersTable(string name, string position) {
            return Model.GetPlayers(name, position);
        }

        public List<string[]> Top25(int week) {
            return Model.GetTop(week);
        }

        public List<Schedule> GetMatchups(int week) {
            return Model.GetMatchups(week);
        }

        public List<WeeklyDefensiveStats> GetDefense(string team) {
            return Model.GetDefense(team);
        }

        public List<WeeklyOffensiveStats> GetOffense(int id) {
            return Model.GetOffense(id);
        }

        public List<string[]> GetTotalPoints (string name) {
            return Model.GetTotalPoints(name);
        }

        public List<string[]> GetHighestScorer(int week) {
            return Model.GetHighestScorer(week);
        }

        public List<string[]> GetTopDefense(int week) {
            return Model.GetTopDefense(week);
        }

        public void AddOffensiveStat(int offid, int playerid, int gameid, int passingyard, int passingtd, int passingattempts, int completions, int rushingattempts, int rushingyards, int rushingtouchdowns, int receptions, int targets, int receivingyards, int receivingtouchdowns, int fumbleslost, float standardpoints) {
            using (var t = new TransactionScope()) {
                using (var connection = new SqlConnection(@"Server=(localdb)\MSSQLLocalDb;Database=Fantasy;Integrated Security=SSPI;")) {
                    using (var command = new SqlCommand("InsertWeeklyOffensiveStats", connection)) {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("OffensiveStatId", offid);
                        command.Parameters.AddWithValue("PlayerId", playerid);
                        command.Parameters.AddWithValue("GameId", gameid);
                        command.Parameters.AddWithValue("PassingYards", passingyard);
                        command.Parameters.AddWithValue("PassingTouchdowns", passingtd);
                        command.Parameters.AddWithValue("PassingAttempts", passingattempts);
                        command.Parameters.AddWithValue("Completions", completions);
                        command.Parameters.AddWithValue("RushingYards", rushingyards);
                        command.Parameters.AddWithValue("RushingTouchdowns", rushingtouchdowns);
                        command.Parameters.AddWithValue("Receptions", receptions);
                        command.Parameters.AddWithValue("Targets", targets);
                        command.Parameters.AddWithValue("ReceivingYards", receivingyards);
                        command.Parameters.AddWithValue("ReceivingTouchdowns", receivingtouchdowns);
                        command.Parameters.AddWithValue("RushingAttempts", rushingattempts);
                        command.Parameters.AddWithValue("FumblesLost", fumbleslost);
                        command.Parameters.AddWithValue("StandardFantasyPoints", standardpoints);
                        connection.Open();
                        try {
                            command.ExecuteNonQuery();
                            t.Complete();
                            MessageBox.Show("Success");
                        } catch (Exception e) {
                            MessageBox.Show(e.ToString());
                        }
                    }
                }
            }
        }

        public void AddDefensiveStat(int weekid, int gameid, int teamid, int sakcs, int interceptions, int fumblesrecovered, int fumblesforced, int deftouchdowns, int safeties, int specialtouchdown, int points) {
            using (var t = new TransactionScope()) {
                using (var connection = new SqlConnection(@"Server=(localdb)\MSSQLLocalDb;Database=Fantasy;Integrated Security=SSPI;")) {
                    using (var command = new SqlCommand("InsertWeeklyDefensiveStats", connection)) {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("WeeklyId", weekid);
                        command.Parameters.AddWithValue("GameId", gameid);
                        command.Parameters.AddWithValue("Team", teamid);
                        command.Parameters.AddWithValue("Sacks", sakcs);
                        command.Parameters.AddWithValue("Interceptions", interceptions);
                        command.Parameters.AddWithValue("FumblesRecovered", fumblesrecovered);
                        command.Parameters.AddWithValue("FumblesForced", fumblesforced);
                        command.Parameters.AddWithValue("DefensiveTouchdowns", deftouchdowns);
                        command.Parameters.AddWithValue("Safeties", safeties);
                        command.Parameters.AddWithValue("SpecialTeamsTouchdowns", specialtouchdown);
                        command.Parameters.AddWithValue("StandardFantasyPoints", points);
                        connection.Open();
                        try {
                            command.ExecuteNonQuery();
                            t.Complete();
                            MessageBox.Show("Success");
                        } catch (Exception e) {
                            MessageBox.Show(e.ToString());
                        }
                    }
                }
            }
        }

        public void AddPlayer(int playerid, int espnid, string playername, string team, string position) {
            using (var t = new TransactionScope()) {
                using (var connection = new SqlConnection(@"Server=(localdb)\MSSQLLocalDb;Database=Fantasy;Integrated Security=SSPI;")) {
                    using (var command = new SqlCommand("InsertPlayer", connection)) {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("PlayerId", playerid);
                        command.Parameters.AddWithValue("EspnId", espnid);
                        command.Parameters.AddWithValue("PlayerName", playername);
                        command.Parameters.AddWithValue("Team", team);
                        command.Parameters.AddWithValue("Position", position);
                        connection.Open();
                        try {
                            command.ExecuteNonQuery();
                            t.Complete();
                            MessageBox.Show("Success");
                        } catch (Exception e) {
                            MessageBox.Show(e.ToString());
                        }
                    }
                }
            }
            
        }

        public void AddSchedule(int gameid, int week, string awayteam, string hometeam, string stadium) {
            using (var t = new TransactionScope()) {
                using (var connection = new SqlConnection(@"Server=(localdb)\MSSQLLocalDb;Database=Fantasy;Integrated Security=SSPI;")) {
                    using (var command = new SqlCommand("InsertSchedule", connection)) {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("GameId", gameid);
                        command.Parameters.AddWithValue("Week", week);
                        command.Parameters.AddWithValue("AwayTeam", awayteam);
                        command.Parameters.AddWithValue("HomeTeam", hometeam);
                        command.Parameters.AddWithValue("Stadium", stadium);
                        try {
                            command.ExecuteNonQuery();
                            t.Complete();
                            MessageBox.Show("Success");
                        } catch (Exception e) {
                            MessageBox.Show(e.ToString());
                        }
                    }
                }
            }

        }
    }
}
