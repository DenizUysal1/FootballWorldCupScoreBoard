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
        private readonly IBaseRepository<Game> _gameRepository;
        
        public ScoreBoardService()
        {
            _gameRepository = new BaseRepository<Game>();
        }

        public Game GetGame(long id)
        {
            return _gameRepository.Get(id);
        }

        public void AddGame(Game game)
        {
            _gameRepository.Add(game);
        }

        public void AddGames(List<Game> games)
        {
            _gameRepository.Add(games);
        }

        public void UpdateGame(Game game)
        {
            var gameRetrieved = _gameRepository.Get(game.Id);
            gameRetrieved.HomeTeamScore = game.HomeTeamScore;
            gameRetrieved.AwayTeamScore = game.AwayTeamScore;
        }

        public void FinishGame(long id)
        {
            _gameRepository.Remove(id);
        }

        public int GetNumberOfMatches()
        {
            return _gameRepository.GetAll().Count;
        }

        public List<Game> GetSummaryFromScoreBoard()
        {
            return _gameRepository.GetAll().OrderByDescending(x => x.TotalScore)
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
