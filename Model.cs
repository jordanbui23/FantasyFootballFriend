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

        public List<string[]> getTop(int week) {
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
    }
}
