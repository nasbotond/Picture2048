// <copyright file="ScoreboardItemsLogicTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Game.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Game.Data;
    using Moq;
    using NUnit.Framework;

    /// <summary>
    /// ScoreboardItemsLogicTests class.
    /// </summary>
    [TestFixture]
    public class ScoreboardItemsLogicTests
    {
        /// <summary>
        /// Mock instance.
        /// </summary>
        private Mock<IRepository<scoreboard_items>> m;

        /// <summary>
        /// List of scoreboard_items.
        /// </summary>
        private List<scoreboard_items> list;

        /// <summary>
        /// ScoreboardItemLogic instance.
        /// </summary>
        private ScoreboardItemLogic logic;

        /// <summary>
        /// Test SetUp method.
        /// </summary>
        [SetUp]
        public void ScoreboardItemSetUp()
        {
            this.list = new List<scoreboard_items>()
            {
                new scoreboard_items() { sbItem_id = 1, sbItem_playerName = "player1", sbItem_score = 3000, sbItem_time = new TimeSpan(0, 39, 9) },
                new scoreboard_items() { sbItem_id = 2, sbItem_playerName = "player2", sbItem_score = 1000, sbItem_time = new TimeSpan(0, 18, 55) },
                new scoreboard_items() { sbItem_id = 3, sbItem_playerName = "player3", sbItem_score = 6500, sbItem_time = new TimeSpan(0, 45, 1) },
                new scoreboard_items() { sbItem_id = 4, sbItem_playerName = "player4", sbItem_score = 86830, sbItem_time = new TimeSpan(5, 24, 55) },
                new scoreboard_items() { sbItem_id = 5, sbItem_playerName = "player5", sbItem_score = 326, sbItem_time = new TimeSpan(0, 39, 24) }
            };
            this.m = new Mock<IRepository<scoreboard_items>>();
            this.m.Setup(x => x.GetAll()).Returns(this.list.AsQueryable());
            this.m.Setup(x => x.GetById(It.IsAny<int>())).Returns((int id) => this.list.Where(x => x.sbItem_id == id).FirstOrDefault());

            this.logic = new ScoreboardItemLogic(this.m.Object);
        }

        /// <summary>
        /// Test GetAllReturnsExpectedNumberOfEntities.
        /// </summary>
        [Test]
        public void TestGetAllReturnsExpectedNumberOfEntities()
        {
            var res = this.logic.GetAll();
            Assert.That(res.Count(), Is.EqualTo(this.list.Count));
        }

        /// <summary>
        /// Test GetAllReturnsCorrectEntities
        /// </summary>
        [Test]
        public void TestGetAllReturnsCorrectEntities()
        {
            var res = this.logic.GetAll();
            Assert.That(res, Is.EqualTo(this.list));
        }

        /// <summary>
        /// Test GetAllIsNotEmpty.
        /// </summary>
        [Test]
        public void TestGetAllIsNotEmpty()
        {
            var res = this.logic.GetAll();
            Assert.That(res, Is.Not.Empty);
        }

        /// <summary>
        /// Test GetByIdDoesNotReturnNull.
        /// </summary>
        [Test]
        public void TestGetByIdDoesNotReturnNull()
        {
            var res = this.logic.GetById(1);
            Assert.That(res, Is.Not.Null);
        }

        /// <summary>
        /// Test GetByIdReturnsExpectedValue.
        /// </summary>
        [Test]
        public void TestGetByIdReturnsExpectedValue()
        {
            var res = this.logic.GetById(1);
            Assert.That(res.sbItem_score, Is.EqualTo(3000));
        }

        /// <summary>
        /// Test GetTopScoreTest.
        /// </summary>
        [Test]
        public void TestGetTopScoreReturnsCorrectValue()
        {
            var top = this.logic.GetTopScore();
            Assert.That(top.Equals(86830));            
        }
    }
}
