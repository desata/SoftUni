using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace FootballTeam.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CreateFootballTeam_ValidParameters()
        {
            FootballTeam team = new FootballTeam("Real Madrid", 21);


            Assert.IsNotNull(team);
            Assert.AreEqual("Real Madrid", team.Name);
            Assert.AreEqual(21, team.Capacity);


            Type t = team.Players.GetType();
            Type expectedType = typeof(List<FootballPlayer>);

            Assert.AreEqual(t, expectedType);
        }

        [Test]
        public void CreateFootballTeam_InvalidName()
        {
            FootballTeam team;

            Assert.Throws<ArgumentException>(() => team = new FootballTeam("", 15));
        }

        [Test]
        public void CreateFootballTeam_InvalidCapacity()
        {
            FootballTeam team;

            Assert.Throws<ArgumentException>(() => team = new FootballTeam("Barcelona", 14));
        }

        [Test]
        public void AddNewPlayer_ValidParameters()
        {
            FootballPlayer player = new FootballPlayer("PlayerName", 8, "Forward");
            FootballTeam team = new FootballTeam("Chocago Fire", 20);

            var actualOutput = team.AddNewPlayer(player);
            var expectedOutput = "Added player PlayerName in position Forward with number 8";

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void AddNewPlayer_CapacityFull()
        {
            FootballPlayer player1 = new FootballPlayer("Player1Name", 1, "Goalkeeper");
            FootballPlayer player2 = new FootballPlayer("Playe2rName", 2, "Goalkeeper");
            FootballPlayer player3 = new FootballPlayer("Player3Name", 3, "Midfielder");
            FootballPlayer player4 = new FootballPlayer("Player4Name", 4, "Midfielder");
            FootballPlayer player5 = new FootballPlayer("Player5Name", 5, "Midfielder");
            FootballPlayer player6 = new FootballPlayer("Player6Name", 6, "Midfielder");
            FootballPlayer player7 = new FootballPlayer("Player7Name", 7, "Midfielder");
            FootballPlayer player8 = new FootballPlayer("Player8Name", 8, "Midfielder");
            FootballPlayer player9 = new FootballPlayer("Player9Name", 9, "Midfielder");
            FootballPlayer player10 = new FootballPlayer("Player10Name", 10, "Midfielder");
            FootballPlayer player11 = new FootballPlayer("Player11Name",11, "Midfielder");
            FootballPlayer player12 = new FootballPlayer("Player12Name", 12, "Forward");
            FootballPlayer player13 = new FootballPlayer("Player13Name", 13, "Forward");
            FootballPlayer player14 = new FootballPlayer("Player14Name", 14, "Forward");
            FootballPlayer player15 = new FootballPlayer("Player15Name", 15, "Forward");
            FootballPlayer player16 = new FootballPlayer("Player16Name", 16, "Forward");
            FootballTeam team = new FootballTeam("Chocago Fire", 15);

            team.AddNewPlayer(player1);
            team.AddNewPlayer(player2);
            team.AddNewPlayer(player3);
            team.AddNewPlayer(player4);
            team.AddNewPlayer(player5);
            team.AddNewPlayer(player6);
            team.AddNewPlayer(player7);
            team.AddNewPlayer(player8);
            team.AddNewPlayer(player9);
            team.AddNewPlayer(player10);
            team.AddNewPlayer(player11);
            team.AddNewPlayer(player12);
            team.AddNewPlayer(player13);
            team.AddNewPlayer(player14);
            team.AddNewPlayer(player15);
            var actualResult = team.AddNewPlayer(player16);

            var expectedResult = "No more positions available!";

            Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        public void PickPlayer_ValidParameters()
        {
            FootballPlayer player = new FootballPlayer("PlayerName", 8, "Forward");
            FootballPlayer player2 = new FootballPlayer("PlayerName2", 8, "Forward");
            FootballTeam team = new FootballTeam("Chocago Fire", 20);
            team.AddNewPlayer(player);
            team.AddNewPlayer(player2);

            var expectedPlayer = team.PickPlayer("PlayerName");
            

            Assert.AreSame(expectedPlayer, player);
        }

        [Test]
        public void PlayerScore_IncreasesStatistics()
        {
            FootballPlayer player = new FootballPlayer("PlayerName", 8, "Forward");
            FootballPlayer player2 = new FootballPlayer("PlayerName2", 9, "Forward");
            FootballTeam team = new FootballTeam("Chocago Fire", 20);
            team.AddNewPlayer(player);
            team.AddNewPlayer(player2);

            string actualOutput = team.PlayerScore(8);

            var expectedOutput = "PlayerName scored and now has 1 for this season!";

            Assert.AreEqual(actualOutput, expectedOutput);
        }
    }
}