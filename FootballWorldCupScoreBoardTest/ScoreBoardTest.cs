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
            var scoreBoardService = new scoreBoardService();
            var game = new Game();

            //Act
            scoreBoardService.AddMatch(game);

            //Assert
            Assert.Equal(1, scoreBoardService.GetNumberOfMatches());

        }
    }
}
