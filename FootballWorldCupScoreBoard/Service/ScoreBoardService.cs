using FootballWorldCupScoreBoard.Domain;
using FootballWorldCupScoreBoard.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballWorldCupScoreBoard.Service
{
    public class ScoreBoardService
    {
        private readonly ScoreBoardRepository _scoreBoardRepository;
        
        public ScoreBoardService()
        {
            _scoreBoardRepository = new ScoreBoardRepository();
        }

        public void AddGame(Game game)
        {
            _scoreBoardRepository.Add(game);
        }

        public int GetNumberOfMatches()
        {
            return _scoreBoardRepository.Games.Count;
        }

    }
}
