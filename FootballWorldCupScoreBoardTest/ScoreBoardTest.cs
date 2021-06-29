using FootballWorldCupScoreBoard.Domain;
using FootballWorldCupScoreBoard.Repository;
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
        public void Should_Throw_Exception_Of_Game_Null()
        {
            //Arrange
            var scoreBoardService = new ScoreBoardService();

            //Act
            //Assert
            Assert.Throws<ArgumentException>(() => scoreBoardService.AddGame(null));
        }

        [Fact]
        public void Should_Throw_Exception_Of_Null_List()
        {
            //Arrange
            var scoreBoardService = new ScoreBoardService();

            //Act
            //Assert
            Assert.Throws<ArgumentException>(() => scoreBoardService.AddGames(null));
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
        public void Should_Initialize_A_Game_With_Both_Scores_At_Zero()
        {
            //Arrange
            var scoreBoardService = new ScoreBoardService();
            var game = new Game()
            {
                Id = 1
            };

            //Act
            scoreBoardService.AddGame(game);
            var gameRetrieved = scoreBoardService.GetGame(1);

            //Assert
            Assert.Equal(0, gameRetrieved.AwayTeamScore);
            Assert.Equal(0, gameRetrieved.HomeTeamScore);

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
        public void Should_Calculate_Ten_For_Total_Score_For_A_Game()
        {
            //Arrange
            var scoreBoardService = new ScoreBoardService();
            var game = new Game()
            {
                Id = 1,
                HomeTeamScore = 5,
                AwayTeamScore = 5
            };

            //Act
            scoreBoardService.AddGame(game);

            //Assert
            var gameRetrieved = scoreBoardService.GetGame(1);

            Assert.Equal(10, gameRetrieved.TotalScore);
        }

        [Fact]
        public void Should_Order_Games_By_Total_Score_And_Most_Recent_Added()
        {
            //Arrange
            var scoreBoardService = new ScoreBoardService();
            var games = GetGamesSample();


            //Act
            scoreBoardService.AddGames(games);
            var summary = scoreBoardService.GetSummaryFromScoreBoard();

            //Assert
            Assert.Equal(4,summary[0].Id);
            Assert.Equal(2,summary[1].Id);
            Assert.Equal(1,summary[2].Id);
            Assert.Equal(5,summary[3].Id);
            Assert.Equal(3,summary[4].Id);
        }

        [Fact]
        public void Should_Return_List_Of_Summary_Ordered_By_Total_Score_And_Most_Recent_Added()
        {
            //Arrange
            var scoreBoardService = new ScoreBoardService();
            var games = GetGamesSample();
            var display = GetDisplayOfSummarySample();

            //Act
            scoreBoardService.AddGames(games);
            var summary = scoreBoardService.GetDisplaySummaryOfBoardGame();

            //Assert
            Assert.Equal(display, summary);
        }

        [Fact]
        public void Should_Add_One_Team_To_Repository()
        {
            //Arrange
            IBaseRepository<Team> teamRepository = new BaseRepository<Team>();
            var team = new Team()
            {
                Id = 1,
                Name = "NiP"
            };

            //Act
            teamRepository.Add(team);


            //Assert
            var numberOfTeams = teamRepository.GetAll().Count;
            Assert.Equal(1, numberOfTeams);
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
        private List<string> GetDisplayOfSummarySample()
        {
            return new List<string>()
            {
                "Uruguay 6 - Italy 6",
                "Spain 10 - Brazil 2",
                "Mexico 0 - Canada 5",
                "Argentina 3 - Australia 1",
                "Germany 2 - France 2",
            };
        }
    }
}
