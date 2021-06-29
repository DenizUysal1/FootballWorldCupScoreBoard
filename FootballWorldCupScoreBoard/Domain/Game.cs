using System;
using System.Collections.Generic;
using System.Text;

namespace FootballWorldCupScoreBoard.Domain
{
    public class Game
    {
        public long Id { get; set; }

        //When the game is added to the score board.
        public DateTime AddedOn { get; set; }
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }

        public int HomeTeamScore { get; set; } = 0;
        public int AwayTeamScore { get; set; } = 0;
        public int TotalScore => HomeTeamScore + AwayTeamScore;
    }
}
