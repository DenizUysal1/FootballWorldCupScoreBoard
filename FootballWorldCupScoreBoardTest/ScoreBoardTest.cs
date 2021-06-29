using FootballWorldCupScoreBoard.Domain;
using FootballWorldCupScoreBoard.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FootballWorldCupScoreBoardTest
{
    public class ScoreBoardTest
    {
        [Fact]
        public void Should_Add_One_Game_To_Score_Board()
        {
            //Arrange
            var scoreBoardService = new ScoreBoardService();
            var game = new Game();

            //Act
            scoreBoardService.AddGame(game);

            //Assert
            Assert.Equal(1, scoreBoardService.GetNumberOfMatches());

        }

        [Fact]
        public void Should_Add_Five_Games_To_Score_Board()
        {
            //Arrange
            var scoreBoardService = new ScoreBoardService();
            var games = GetGamesSample();

            //Act
            scoreBoardService.AddGames(games);

            //Assert
            Assert.Equal(5, scoreBoardService.GetNumberOfMatches());

        }

        [Fact]
        public void Should_Finish_One_Game_From_Score_Board()
        {
            //Arrange
            var scoreBoardService = new ScoreBoardService();
            var game = new Game()
            {
                Id = 1
            };

            //Act
            scoreBoardService.AddGame(game);
            scoreBoardService.FinishGame(game.Id);

            //Assert
            Assert.Equal(0, scoreBoardService.GetNumberOfMatches());

        }

        [Fact]
        public void Should_Update_One_Match_From_Score_Board()
        {
            //Arrange
            var scoreBoardService = new ScoreBoardService();
            var game = new Game()
            {
                Id = 1
            };

            var gameUpdated = new Game()
            {
                Id = 1,
                HomeTeamScore = 5,
                AwayTeamScore = 3
            };

            //Act
            scoreBoardService.AddGame(game);
            scoreBoardService.UpdateGame(gameUpdated);

            //Assert
            var gameRetrieved = scoreBoardService.GetGame(1);

            Assert.Equal(5, gameRetrieved.HomeTeamScore);
            Assert.Equal(3, gameRetrieved.AwayTeamScore);
        }

        [Fact]
        public void Should_Order_Games_By_Total_Score_And_Most_Recent_Added()
        {
            //Arrange
            var scoreBoardService = new ScoreBoardService();
            var games = GetGamesSample();
            foreach (var game in games)
            {
                scoreBoardService.AddGame(game);
            }

            //Act
            var summary = scoreBoardService.GetSummaryFromScoreBoard();

            //Assert
            Assert.Equal(4,summary[0].Id);
            Assert.Equal(2,summary[1].Id);
            Assert.Equal(1,summary[2].Id);
            Assert.Equal(5,summary[3].Id);
            Assert.Equal(3,summary[4].Id);
        }

        private List<Game> GetGamesSample()
        {
            var games = new List<Game>()
            {
                new Game()
                {
                    Id = 1,
                    AddedOn = DateTime.Today.AddDays(-5),
                    AwayTeam = new Team()
                    {
                        Name = "Canada"
                    },
                    HomeTeam = new Team()
                    {
                        Name = "Mexico"
                    },
                    AwayTeamScore = 5,
                    HomeTeamScore = 0
                },
                new Game()
                {
                    Id = 2,
                    AddedOn = DateTime.Today.AddDays(-4),
                    AwayTeam = new Team()
                    {
                        Name = "Brazil"
                    },
                    HomeTeam = new Team()
                    {
                        Name = "Spain"
                    },
                    AwayTeamScore = 2,
                    HomeTeamScore = 10
                },
                new Game()
                {
                    Id = 3,
                    AddedOn = DateTime.Today.AddDays(-3),
                    AwayTeam = new Team()
                    {
                        Name = "France"
                    },
                    HomeTeam = new Team()
                    {
                        Name = "Germany"
                    },
                    AwayTeamScore = 2,
                    HomeTeamScore = 2
                },
                new Game()
                {
                    Id = 4,
                    AddedOn = DateTime.Today.AddDays(-2),
                    AwayTeam = new Team()
                    {
                        Name = "Italy"
                    },
                    HomeTeam = new Team()
                    {
                        Name = "Uruguay"
                    },
                    AwayTeamScore = 6,
                    HomeTeamScore = 6
                },
                new Game()
                {
                    Id = 5,
                    AddedOn = DateTime.Today.AddDays(-1),
                    AwayTeam = new Team()
                    {
                        Name = "Australia"
                    },
                    HomeTeam = new Team()
                    {
                        Name = "Argentina"
                    },
                    AwayTeamScore = 1,
                    HomeTeamScore = 3
                }
            };

            return games;
        }
    }
}
