using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FantasyFootballFriend {
    public partial class Search : Form {
        public Search() {
            InitializeComponent();
        }

        private Controller _controller;
        private List<Player> _playerList;

        public void SetController(Controller controller) {
            _controller = controller;
        }

        private void uxPlayerButton_Click(object sender, EventArgs e) {
            _playerList = _controller.Search();
            foreach (Player p in _playerList) {
                string[] row = new string[] { p.PlayerID.ToString(), p.PlayerName, p.Team, p.Position };
                ListViewItem item = new ListViewItem(row);
                uxPlayerList.Items.Add(item);
            }
        }

        private void uxOffensiveButton_Click(object sender, EventArgs e) {

        }

        private void uxEspnButton_Click(object sender, EventArgs e) {

        }

        private void uxDefensiveButton_Click(object sender, EventArgs e) {

        }
    }
}
