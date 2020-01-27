// <copyright file="IGameLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Game
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface IGameLogic.
    /// </summary>
    public interface IGameLogic
    {
        // move the tiles to the given direction (using keyboard input)

        /// <summary>
        /// MoveLeft function.
        /// </summary>
        /// <param name="grid">2D array of tiles.</param>
        /// <returns>bool whether change happened or not.</returns>
        bool MoveLeft(Tile[,] grid);

        /// <summary>
        /// MoveRight function.
        /// </summary>
        /// <param name="grid">2D array of tiles.</param>
        /// <returns>bool whether change happened or not.</returns>
        bool MoveRight(Tile[,] grid);

        /// <summary>
        /// MoveUp function.
        /// </summary>
        /// <param name="grid">2D array of tiles.</param>
        /// <returns>bool whether change happened or not.</returns>
        bool MoveUp(Tile[,] grid);

        /// <summary>
        /// MoveDown function.
        /// </summary>
        /// <param name="grid">2D array of tiles.</param>
        /// <returns>bool whether change happened or not.</returns>
        bool MoveDown(Tile[,] grid);

        /// <summary>
        /// change score when tiles are merged .
        /// </summary>
        /// <param name="tile">Tile whose value is used to increase the score.</param>
        void IncreaseScore(Tile tile);

        /// <summary>
        /// ListOfEmptyTiles function.
        /// </summary>
        /// <param name="grid">2D array of tiles.</param>
        /// <returns>List of empty tiles.</returns>
        List<Tile> ListOfEmptyTiles(Tile[,] grid);

        /// <summary>
        /// after every move, a new tile is placed randomly.
        /// </summary>
        /// <param name="grid">2D array of tiles.</param>
        void PlaceNewTile(Tile[,] grid);

        /// <summary>
        /// CheckGameOver function.
        /// </summary>
        /// <param name="grid">2D array of tiles.</param>
        /// <returns>bool whether change happened or not.</returns>
        bool CheckGameOver(Tile[,] grid);

        /// <summary>
        /// menu functions.
        /// </summary>
        void OpenMenu();
    }
}
