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

        public Game GetGame(long id)
        {
            return _scoreBoardRepository.Get(id);
        }

        public void AddGame(Game game)
        {
            _scoreBoardRepository.Add(game);
        }

        public void AddGames(List<Game> games)
        {
            _scoreBoardRepository.Add(games);
        }

        public void UpdateGame(Game game)
        {
            _scoreBoardRepository.Update(game);
        }

        public void FinishGame(long id)
        {
            _scoreBoardRepository.Games = _scoreBoardRepository.Games.Where(x => x.Id != id).ToList();
        }

        public int GetNumberOfMatches()
        {
            return _scoreBoardRepository.Games.Count;
        }

        public List<Game> GetSummaryFromScoreBoard()
        {
            return _scoreBoardRepository.GetAll().OrderByDescending(x => x.TotalScore)
                                                 .ThenByDescending(x => x.AddedOn)
                                                 .ToList();
        }

        public List<string> GetDisplaySummaryOfBoardGame()
        {
            var summaryOfGames = new List<string>();
            foreach (var game in GetSummaryFromScoreBoard())
            {
                summaryOfGames.Add($"{game.HomeTeam.Name} {game.HomeTeamScore} - {game.AwayTeam.Name} {game.AwayTeamScore}");
            }

            return summaryOfGames;
        }

    }
}
