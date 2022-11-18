using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyFootballFriend {
    public class WeeklyDefensiveStats {
        public int WeeklyId { get; set; }
        public int GameId { get; set; }
        public int TeamWeeklyId { get; set; }
        public int Week { get; set; }
        public int WeekRank { get; set; }
        public string Team { get; set; }
        public int Sacks { get; set; }
        public int Interceptions { get; set; }
        public int FumblesRecovered { get; set; }
        public int FumblesForced { get; set; }
        public int DefensiveTouchdowns { get; set; }
        public int Safeties { get; set; }
        public int SpecialTeamsTouchdowns { get; set; }
        public int StandardFantasyPoints { get; set; }
    }
}
