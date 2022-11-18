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

        public List<Player> SearchPlayersTable() {
            return Model.GetPlayers();
        }

    }
}
