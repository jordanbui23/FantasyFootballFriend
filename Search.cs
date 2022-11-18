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
        private List<string[]> _totalPoints;
        private List<string[]> _highestScorer;
        private List<string[]> _topDefense;

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
            uxTopDefenseList.Visible = false;
            uxHighestScorerList.Visible = false;
            uxTotalPointsList.Visible = false;
        }

        private void uxOffensiveButton_Click(object sender, EventArgs e) {
            uxOffensiveList.Visible = true;
            uxPlayerList.Visible = false;
            uxDefensiveList.Visible = false;
            uxScheduleList.Visible = false;
            uxSubmitButton.Enabled = true;
            uxTop25List.Visible = false;
            uxTopDefenseList.Visible = false;
            uxHighestScorerList.Visible = false;
            uxTotalPointsList.Visible = false;
        }

        private void uxEspnButton_Click(object sender, EventArgs e) { // Schedule button but it wont let me change the name for the click event
            uxScheduleList.Visible = true;
            uxPlayerList.Visible = false;
            uxDefensiveList.Visible = false;
            uxOffensiveList.Visible = false;
            uxSubmitButton.Enabled = true;
            uxTop25List.Visible = false;
            uxTopDefenseList.Visible = false;
            uxHighestScorerList.Visible = false;
            uxTotalPointsList.Visible = false;
        }

        private void uxDefensiveButton_Click(object sender, EventArgs e) {
            uxDefensiveList.Visible = true;
            uxPlayerList.Visible = false;
            uxOffensiveList.Visible = false;
            uxScheduleList.Visible = false;
            uxSubmitButton.Enabled = true;
            uxTop25List.Visible = false;
            uxTopDefenseList.Visible = false;
            uxHighestScorerList.Visible = false;
            uxTotalPointsList.Visible = false;
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
            } else if (uxDefensiveList.Visible) {
                if (uxTeamComboBox.Text != "") {
                    string team = uxTeamComboBox.Text;
                    _defensiveList = _controller.GetDefense(team);
                    foreach (WeeklyDefensiveStats d in _defensiveList) {
                        string[] row = new string[] { d.WeeklyId.ToString(),
                            d.GameId.ToString(),
                            d.Team,
                            d.Sacks.ToString(),
                            d.Interceptions.ToString(),
                            d.FumblesRecovered.ToString(),
                            d.FumblesForced.ToString(),
                            d.DefensiveTouchdowns.ToString(),
                            d.Safeties.ToString(),
                            d.SpecialTeamsTouchdowns.ToString(),
                            d.StandardFantasyPoints.ToString()
                        };
                        ListViewItem item = new ListViewItem(row);
                        uxDefensiveList.Items.Add(item);
                    }
                } else {
                    MessageBox.Show("Input a team please");
                }
            } else if (uxOffensiveList.Visible) {
                if (uxPlayerId.Text != "") {
                    string id = uxPlayerId.Text;
                    _offensiveList = _controller.GetOffense(Int32.Parse(id));
                    foreach (WeeklyOffensiveStats o in _offensiveList) {
                        string[] row = new string[] { o.OffensiveStatId.ToString(),
                            o.PlayerId.ToString(),
                            o.PassingYards.ToString(),
                            o.PassingTouchdowns.ToString(),
                            o.PassingAttempts.ToString(),
                            o.Completions.ToString(),
                            o.RushingAttempts.ToString(),
                            o.RushingYards.ToString(),
                            o.RushingTouchdowns.ToString(),
                            o.Receptions.ToString(),
                            o.Targets.ToString(),
                            o.ReceivingYards.ToString(),
                            o.ReceivingTouchdowns.ToString(),
                            o.FumblesLost.ToString(),
                            o.StandardFantasyPoints.ToString(),
                            o.GameId.ToString()
                        };
                        ListViewItem item = new ListViewItem(row);
                        uxOffensiveList.Items.Add(item);
                    }
                } else {
                    MessageBox.Show("Input a week please");
                }
            } else if (uxScheduleList.Visible) {
                if (uxScheduleWeek.Text != "") {
                    string weekNum = uxScheduleWeek.Text;
                    _scheduleList = _controller.GetMatchups(Int32.Parse(weekNum));
                    foreach (Schedule s in _scheduleList) {
                        string[] row = new string[] { s.GameId.ToString(), s.Week.ToString(), s.AwayTeam, s.HomeTeam, s.Stadium };
                        ListViewItem item = new ListViewItem(row);
                        uxScheduleList.Items.Add(item);
                    }
                } else {
                    MessageBox.Show("Input a week please");
                }
            } else if (uxTop25List.Visible) {
                if (uxTop25Box.Text != "") {
                    _top25 = _controller.Top25(Int32.Parse(uxTop25Box.Text));
                    foreach (string[] list in _top25) {
                        uxTop25List.Items.Add(new ListViewItem(list));
                    }
                } else {
                    MessageBox.Show("Input a week please");
                }
            } else if (uxTotalPointsList.Visible) {
                if (uxTotalPointsPlayer.Text != "") {
                    _totalPoints = _controller.GetTotalPoints(uxTotalPointsPlayer.Text);
                    foreach (string[] list in _totalPoints) {
                        uxTotalPointsList.Items.Add(new ListViewItem(list));
                    }
                } else {
                    MessageBox.Show("Input a Name please");
                }
            } else if (uxHighestScorerList.Visible) {
                if (uxHighestScorerBox.Text != "") {
                    _highestScorer = _controller.GetHighestScorer(Int32.Parse(uxHighestScorerBox.Text));
                    foreach (string[] list in _highestScorer) {
                        uxHighestScorerList.Items.Add(new ListViewItem(list));
                    }
                } else {
                    MessageBox.Show("Input a Week please");
                }
            } else if (uxTopDefenseList.Visible) {
                if (uxTopDefWeek.Text != "") {
                    _topDefense = _controller.GetTopDefense(Int32.Parse(uxTopDefWeek.Text));
                    foreach (string[] list in _topDefense) {
                        uxTopDefenseList.Items.Add(new ListViewItem(list));
                    }
                } else {
                    MessageBox.Show("Input a Week please");
                }
            }
        }

        private void uxTop25Button_Click(object sender, EventArgs e) {
            uxDefensiveList.Visible = false;
            uxPlayerList.Visible = false;
            uxOffensiveList.Visible = false;
            uxScheduleList.Visible = false;
            uxSubmitButton.Enabled = true;
            uxTop25List.Visible = true;
            uxTopDefenseList.Visible = false;
            uxHighestScorerList.Visible = false;
            uxTotalPointsList.Visible = false;
        }

        private void uxTotalPoints_Click(object sender, EventArgs e) {
            uxTotalPointsList.Visible = true;
            uxDefensiveList.Visible = false;
            uxPlayerList.Visible = false;
            uxOffensiveList.Visible = false;
            uxScheduleList.Visible = false;
            uxSubmitButton.Enabled = true;
            uxTop25List.Visible = false;
            uxTopDefenseList.Visible = false;
            uxHighestScorerList.Visible = false;
        }

        private void uxHighestScorerButton_Click(object sender, EventArgs e) {
            uxHighestScorerList.Visible = true;
            uxTotalPointsList.Visible = false;
            uxDefensiveList.Visible = false;
            uxPlayerList.Visible = false;
            uxOffensiveList.Visible = false;
            uxScheduleList.Visible = false;
            uxSubmitButton.Enabled = true;
            uxTop25List.Visible = false;
            uxTopDefenseList.Visible = false;
        }

        private void uxTopDefButton_Click(object sender, EventArgs e) {
            uxTopDefenseList.Visible = true;
            uxHighestScorerList.Visible = false;
            uxTotalPointsList.Visible = false;
            uxDefensiveList.Visible = false;
            uxPlayerList.Visible = false;
            uxOffensiveList.Visible = false;
            uxScheduleList.Visible = false;
            uxSubmitButton.Enabled = true;
            uxTop25List.Visible = false;
        }
    }
}
