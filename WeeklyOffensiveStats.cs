using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyFootballFriend {
    public class WeeklyOffensiveStats {
        public int OffensiveStatId { get; set; }
        public int PlayerId { get; set; }
        public int PassingYards { get; set; }
        public int PassingTouchdowns { get; set; }
        public int PassingAttempts { get; set; }
        public int Completions { get; set; }
        public int RushingAttempts { get; set; }
        public int RushingYards { get; set; }
        public int RushingTouchdowns { get; set; }
        public int Receptions { get; set; }
        public int Targets { get; set; }
        public int ReceivingYards { get; set; }
        public int ReceivingTouchdowns { get; set; }
        public int FumblesLost { get; set; }
        public double StandardFantasyPoints { get; set; }
        public int GameId{ get; set; }
    }
}
