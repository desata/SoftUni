using NUnit.Framework;
using System;
using System.Numerics;
using System.Xml.Linq;

namespace FootballTeam.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TeamCtor()
        {
            FootballTeam footballTeam = new FootballTeam("name", 25);

            Assert.AreEqual("name", footballTeam.Name);
        }

        [Test]
        public void TeamCtorNot()
        {
            Assert.Throws<ArgumentException>(() => new FootballTeam("name", 5), "Capacity min value = 15");

            Assert.Throws<ArgumentException>(() => new FootballTeam(null, 50), "Name cannot be null or empty!");

        }

        [Test]
        public void AddPlayerS()
        {
            FootballPlayer player = new FootballPlayer("Ivan", 6, "Goalkeeper");
            FootballTeam footballTeam = new FootballTeam("name", 25);

            Assert.AreEqual(0, footballTeam.Players.Count);

            footballTeam.AddNewPlayer(player);

            Assert.AreEqual(1, footballTeam.Players.Count);
        }
        [Test]
        public void AddPlayerN()
        {
            FootballPlayer player0 = new FootballPlayer("Ivan", 6, "Goalkeeper");
            FootballPlayer player1 = new FootballPlayer("Ivan", 6, "Goalkeeper");
            FootballPlayer player2= new FootballPlayer("Ivan", 6, "Goalkeeper");
            FootballPlayer player3 = new FootballPlayer("Ivan", 6, "Goalkeeper");
            FootballPlayer player4= new FootballPlayer("Ivan", 6, "Goalkeeper");
            FootballPlayer player5 = new FootballPlayer("Ivan", 6, "Goalkeeper");
            FootballPlayer player6 = new FootballPlayer("Ivan", 6, "Goalkeeper");
            FootballPlayer player7 = new FootballPlayer("Ivan", 6, "Goalkeeper");
            FootballPlayer player8 = new FootballPlayer("Ivan", 6, "Goalkeeper");
            FootballPlayer player9 = new FootballPlayer("Ivan", 6, "Goalkeeper");
            FootballPlayer player10 = new FootballPlayer("Ivan", 6, "Goalkeeper");
            FootballPlayer player11= new FootballPlayer("Ivan", 6, "Goalkeeper");
            FootballPlayer player12 = new FootballPlayer("Ivan", 6, "Goalkeeper");
            FootballPlayer player13 = new FootballPlayer("Ivan", 6, "Goalkeeper");
            FootballPlayer player14 = new FootballPlayer("Ivan", 6, "Goalkeeper");
            FootballPlayer player15 = new FootballPlayer("Ivan", 6, "Goalkeeper");

            FootballTeam footballTeam = new FootballTeam("name", 15);

            
            footballTeam.AddNewPlayer(player0);
            footballTeam.AddNewPlayer(player1);
            footballTeam.AddNewPlayer(player2);
            footballTeam.AddNewPlayer(player3);
            footballTeam.AddNewPlayer(player4);
            footballTeam.AddNewPlayer(player5);
            footballTeam.AddNewPlayer(player6);
            footballTeam.AddNewPlayer(player7);
            footballTeam.AddNewPlayer(player8);
            footballTeam.AddNewPlayer(player9);
            footballTeam.AddNewPlayer(player10);
            footballTeam.AddNewPlayer(player11);
            footballTeam.AddNewPlayer(player12);
            footballTeam.AddNewPlayer(player13);
            footballTeam.AddNewPlayer(player14);
            footballTeam.AddNewPlayer(player15);

            Assert.AreEqual(15, footballTeam.Players.Count);
        }

    }
}