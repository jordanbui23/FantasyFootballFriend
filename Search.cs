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
            uxSubmitButton.Enabled = false;
        }

        private Controller _controller;
        private List<Player> _playerList;
        private List<WeeklyOffensiveStats> _offensiveList;
        private List<WeeklyDefensiveStats> _defensiveList;
        private List<Schedule> _scheduleList;
        private List<string[]> _top25;

        public void SetController(Controller controller) {
            _controller = controller;
        }

        private void uxPlayerButton_Click(object sender, EventArgs e) {
            uxPlayerList.Visible = true;
            uxDefensiveList.Visible = false;
            uxOffensiveList.Visible = false;
            uxScheduleList.Visible = false;
            uxSubmitButton.Enabled = true;
            uxTop25List.Visible = false;

        }

        private void uxOffensiveButton_Click(object sender, EventArgs e) {
            uxOffensiveList.Visible = true;
            uxPlayerList.Visible = false;
            uxDefensiveList.Visible = false;
            uxScheduleList.Visible = false;
            uxSubmitButton.Enabled = true;
            uxTop25List.Visible = false;
        }

        private void uxEspnButton_Click(object sender, EventArgs e) { // Schedule button but it wont let me change the name for the click event
            uxScheduleList.Visible = true;
            uxPlayerList.Visible = false;
            uxDefensiveList.Visible = false;
            uxOffensiveList.Visible = false;
            uxSubmitButton.Enabled = true;
            uxTop25List.Visible = false;
        }

        private void uxDefensiveButton_Click(object sender, EventArgs e) {
            uxDefensiveList.Visible = true;
            uxPlayerList.Visible = false;
            uxOffensiveList.Visible = false;
            uxScheduleList.Visible = false;
            uxSubmitButton.Enabled = true;
            uxTop25List.Visible = false;
        }

        private void uxSubmitButton_Click(object sender, EventArgs e) {
            /*
            uxPlayerList.Clear();
            uxOffensiveList.Clear();
            uxDefensiveList.Clear();
            uxScheduleList.Clear();
            */
            if (uxPlayerList.Visible) {
                string name = uxNameBox.Text;
                string position = uxPositionBox.Text;
                if (name != "" && position != "") {
                    _playerList = _controller.SearchPlayersTable(name, position);
                } else if (name != "") {
                    _playerList = _controller.SearchPlayersTable(name, "");
                } else if (position != "") {
                    _playerList = _controller.SearchPlayersTable("", position);
                } else {
                    _playerList = _controller.SearchPlayersTable("", "");
                }
                uxPositionBox.Text = "";
                uxNameBox.Text = "";
                if (_playerList != null) {
                    foreach (Player p in _playerList) {
                        string[] row = new string[] { p.PlayerID.ToString(), p.PlayerName, p.Team, p.Position };
                        ListViewItem item = new ListViewItem(row);
                        uxPlayerList.Items.Add(item);
                    }
                }
            }
        }

        private void uxTop25Button_Click(object sender, EventArgs e) {
            uxDefensiveList.Visible = false;
            uxPlayerList.Visible = false;
            uxOffensiveList.Visible = false;
            uxScheduleList.Visible = false;
            uxSubmitButton.Enabled = true;  //FIX TOMORROWWWWWWWWWWWWWWWWWWWWWWWWWWWW
            uxTop25List.Visible = true;
            if (uxTop25Box.Text != "") {
                _top25 = _controller.Top25(Int32.Parse(uxTop25Box.Text));
                foreach(string[] list in _top25) {
                    uxTop25List.Items.Add(new ListViewItem(list));
                }
            } else {
                MessageBox.Show("Fucking dumbass");
            }
        }
    }
}
