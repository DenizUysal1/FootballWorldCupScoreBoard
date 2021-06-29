using FootballWorldCupScoreBoard.Domain;
using FootballWorldCupScoreBoard.Service;
using System;
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
    }
}
