using FootballWorldCupScoreBoard.Domain;
using FootballWorldCupScoreBoard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void FinishGame(long id)
        {
            _scoreBoardRepository.Games = _scoreBoardRepository.Games.Where(x => x.Id != id).ToList();
        }

        public int GetNumberOfMatches()
        {
            return _scoreBoardRepository.Games.Count;
        }

    }
}
