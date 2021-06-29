using FootballWorldCupScoreBoard.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballWorldCupScoreBoard.Repository
{
    public class ScoreBoardRepository
    {
        public List<Game> Games;

        public ScoreBoardRepository()
        {
            Games = new List<Game>();
        }

        public void Add(Game game)
        {
            Games.Add(game);
        }
        
    }
}
