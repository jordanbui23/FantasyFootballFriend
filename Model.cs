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

        public List<Player> GetPlayers() {
            using (SqlConnection connection = new SqlConnection(database)) {
                using (SqlCommand command = new SqlCommand("SELECT * FROM [2021Player];", connection)) {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                        return ConvertPlayerList(reader);
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
                player.PlayerID = dataReader.GetInt32(PlayerID);
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
    }
}
