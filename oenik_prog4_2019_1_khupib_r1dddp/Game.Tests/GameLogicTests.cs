// <copyright file="GameLogicTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Game.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using NUnit.Framework;

    /// <summary>
    /// GameLogicTests class.
    /// </summary>
    [TestFixture]
    public class GameLogicTests
    {
        /// <summary>
        /// Instance of GameModel.
        /// </summary>
        private GameModel model;

        /// <summary>
        /// Instance of GameLogic.
        /// </summary>
        private GameLogic logic;

        /// <summary>
        /// SetUp method.
        /// </summary>
        [SetUp]
        public void GameLogicSetup()
        {
            this.model = new GameModel();

            this.model.Grid = new Tile[,]
            {
                { new Tile(0, 0, 0, 2), new Tile(0, 1, 0, 2), new Tile(0, 2, 0, 0), new Tile(0, 3, 0, 0) },
                { new Tile(1, 0, 0, 0), new Tile(1, 1, 0, 0), new Tile(1, 2, 0, 0), new Tile(1, 3, 0, 0) },
                { new Tile(2, 0, 0, 0), new Tile(2, 1, 0, 0), new Tile(2, 2, 0, 2), new Tile(2, 3, 0, 0) },
                { new Tile(3, 0, 0, 0), new Tile(3, 1, 0, 2), new Tile(3, 2, 0, 0), new Tile(3, 3, 0, 0) }
            };

            this.model.CurrentScore = 12;
            this.logic = new GameLogic(this.model);
        }

        /// <summary>
        /// Test IncreaseScoreIncreasesScoreCorrectly.
        /// </summary>
        [Test]
        public void TestIncreaseScoreIncreasesScoreCorrectly()
        {
            this.logic.IncreaseScore(new Tile(0, 0, 0, 4));
            Assert.That(this.model.CurrentScore, Is.EqualTo(20));
        }

        /// <summary>
        /// Test MoveLeftMovesAllTilesAndMergesAllTilesCorrectlyToTheLeft.
        /// </summary>
        [Test]
        public void TestMoveLeftMovesAllTilesAndMergesAllTilesCorrectlyToTheLeft()
        {
            this.logic.MoveLeft(this.model.Grid);
            Assert.That(this.model.Grid[3, 0].Value, Is.EqualTo(2));
            Assert.That(this.model.Grid[0, 0].Value, Is.EqualTo(4));
        }

        /// <summary>
        /// Test MoveRightMovesAllTilesAndMergesAllTilesCorrectlyToTheRight.
        /// </summary>
        [Test]
        public void TestMoveRightMovesAllTilesAndMergesAllTilesCorrectlyToTheRight()
        {
            this.logic.MoveRight(this.model.Grid);
            Assert.That(this.model.Grid[3, 3].Value, Is.EqualTo(2));
            Assert.That(this.model.Grid[0, 3].Value, Is.EqualTo(4));
        }

        /// <summary>
        /// Test MoveUpMovesAllTilesAndMergesAllTilesCorrectlyUpwards.
        /// </summary>
        [Test]
        public void TestMoveUpMovesAllTilesAndMergesAllTilesCorrectlyUpwards()
        {
            this.logic.MoveUp(this.model.Grid);
            Assert.That(this.model.Grid[0, 1].Value, Is.EqualTo(4));
            Assert.That(this.model.Grid[0, 2].Value, Is.EqualTo(2));
        }

        /// <summary>
        /// Test MoveDownMovesAllTilesAndMergesAllTilesCorrectlyDownwards.
        /// </summary>
        [Test]
        public void TestMoveDownMovesAllTilesAndMergesAllTilesCorrectlyDownwards()
        {
            this.logic.MoveDown(this.model.Grid);
            Assert.That(this.model.Grid[3, 1].Value, Is.EqualTo(4));
            Assert.That(this.model.Grid[3, 0].Value, Is.EqualTo(2));
        }

        /// <summary>
        /// Test ListOfEmptyTilesReturnsTheCorrectNumberOfTiles.
        /// </summary>
        [Test]
        public void TestListOfEmptyTilesReturnsTheCorrectNumberOfTiles()
        {
            var res = this.logic.ListOfEmptyTiles(this.model.Grid).Count;
            Assert.That(res, Is.EqualTo(12));
        }

        /// <summary>
        /// Test PlaceNewTilePlacesANewTileInCorrectSpot.
        /// </summary>
        [Test]
        public void TestPlaceNewTilePlacesANewTileInCorrectSpot()
        {
            this.logic.PlaceNewTile(this.model.Grid);
            var res = this.logic.ListOfEmptyTiles(this.model.Grid).Count;
            Assert.That(res, Is.EqualTo(11));
        }

        /// <summary>
        /// Test CheckGameOverReturnsTheCorrectValue.
        /// </summary>
        [Test]
        public void TestCheckGameOverReturnsTheCorrectValue()
        {
            var res = this.logic.CheckGameOver(this.model.Grid);
            Assert.That(res, Is.EqualTo(false));
        }
    }
}
