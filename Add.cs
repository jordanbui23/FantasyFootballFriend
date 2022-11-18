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
    public partial class Add : Form {
        public Add() {
            InitializeComponent();
        }
        private Controller _controller;

        public void SetController(Controller controller) {
            _controller = controller;
        }

        private bool _offensive = false;
        private bool _defensive = false;
        private bool _player = false;
        private bool _schedule = false;

        private void uxOffensiveButton_Click(object sender, EventArgs e) {
            uxSubmitButton.Enabled = true;
            _offensive = true;
            _defensive = false;
            _player = false;
            _schedule = false;
        }

        private void uxDefensiveButton_Click(object sender, EventArgs e) {
            uxSubmitButton.Enabled = true;
            _offensive = false;
            _defensive = true;
            _player = false;
            _schedule = false;
        }

        private void uxPlayerButton_Click(object sender, EventArgs e) {
            uxSubmitButton.Enabled = true;
            _offensive = false;
            _defensive = false;
            _player = true;
            _schedule = false;
        }

        private void uxScheduleButton_Click(object sender, EventArgs e) {
            uxSubmitButton.Enabled = true;
            _offensive = false;
            _defensive = false;
            _player = false;
            _schedule = true;
        }

        private void uxSubmitButton_Click(object sender, EventArgs e) {
            if (_offensive) {
                try {
                    _controller.AddOffensiveStat(Int32.Parse(offStatId.Text), Int32.Parse(offPlayerId.Text), Int32.Parse(offGameId.Text), Int32.Parse(offPassingYards.Text), Int32.Parse(offPassingTouchdowns.Text), Int32.Parse(offPassingAttempts.Text), Int32.Parse(offCompletions.Text), Int32.Parse(offRushingAttempts.Text), Int32.Parse(offRushingYards.Text), Int32.Parse(offRushingTouchdowns.Text), Int32.Parse(offReceptions.Text), Int32.Parse(offTargets.Text), Int32.Parse(offReceivingYards.Text), Int32.Parse(offReceivingTouchdowns.Text), Int32.Parse(offFumblesLost.Text), float.Parse(offStandardFantasyPoints.Text));
                } catch (Exception) {
                    MessageBox.Show("Please input all fields");
                }
            } else if (_defensive) {
                try {
                    _controller.AddDefensiveStat(Int32.Parse(defWeeklyId.Text), Int32.Parse(defGameId.Text), Int32.Parse(defTeamWeeklyId.Text), Int32.Parse(defSacks.Text), Int32.Parse(defInterceptions.Text), Int32.Parse(defFumblesRecovered.Text), Int32.Parse(defFumblesForced.Text), Int32.Parse(defTouchdowns.Text), Int32.Parse(defSafeties.Text), Int32.Parse(defSpecialTeamsTouchdowns.Text), Int32.Parse(defFantasyPoints.Text));
                } catch (Exception) {
                    MessageBox.Show("Please input all fields");
                }
            } else if (_player) {
                try {
                    _controller.AddPlayer(Int32.Parse(plaPlayerId.Text), Int32.Parse(plaEspnId.Text), plaPlayerName.Text, plaTeam.Text, plaPosition.Text);
                } catch (Exception) {
                    MessageBox.Show("Please input all fields");
                }
            } else if (_schedule) {
                try {
                    _controller.AddSchedule(Int32.Parse(schGameId.Text), Int32.Parse(schWeek.Text), schAwayTeam.Text, schHomeTeam.Text, schStadium.Text);
                } catch (Exception) {
                    MessageBox.Show("Please input all fields");
                }
            }
        }
    }
}
