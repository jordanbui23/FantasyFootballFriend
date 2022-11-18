using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
