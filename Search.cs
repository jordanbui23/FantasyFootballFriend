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
        private List<WeeklyOffensiveStats> _offensiveList;
        private List<WeeklyDefensiveStats> _defensiveList;
        private List<Schedule> _scheduleList;

        public void SetController(Controller controller) {
            _controller = controller;
        }

        private void uxPlayerButton_Click(object sender, EventArgs e) {
            uxPlayerList.Visible = true;
            uxDefensiveList.Visible = false;
            uxOffensiveList.Visible = false;
            uxScheduleList.Visible = false;

            _playerList = _controller.SearchPlayersTable();
            foreach (Player p in _playerList) {
                string[] row = new string[] { p.PlayerID.ToString(), p.PlayerName, p.Team, p.Position };
                ListViewItem item = new ListViewItem(row);
                uxPlayerList.Items.Add(item);
            }
        }

        private void uxOffensiveButton_Click(object sender, EventArgs e) {
            uxOffensiveList.Visible = true;
            uxPlayerList.Visible = false;
            uxDefensiveList.Visible = false;
            uxScheduleList.Visible = false;
        }

        private void uxEspnButton_Click(object sender, EventArgs e) { // Schedule button but it wont let me change the name for the click event
            uxScheduleList.Visible = true;
            uxPlayerList.Visible = false;
            uxDefensiveList.Visible = false;
            uxOffensiveList.Visible = false;
        }

        private void uxDefensiveButton_Click(object sender, EventArgs e) {
            uxDefensiveList.Visible = true;
            uxPlayerList.Visible = false;
            uxOffensiveList.Visible = false;
            uxScheduleList.Visible = false;
        }
    }
}
