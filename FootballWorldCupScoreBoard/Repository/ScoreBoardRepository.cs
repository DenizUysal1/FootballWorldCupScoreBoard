using FootballWorldCupScoreBoard.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public Game Get(long id)
        {
            return Games.Where(x => x.Id == id).FirstOrDefault();
        }

        public void Update(Game gameUpdated)
        {
            var game = Games.Where(x => x.Id == gameUpdated.Id).FirstOrDefault();
            game.HomeTeamScore = gameUpdated.HomeTeamScore;
            game.AwayTeamScore = gameUpdated.AwayTeamScore;
        }
        
    }
}
