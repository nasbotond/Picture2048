// <copyright file="GameModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Game
{
    using System;

    /// <summary>
    /// Serializable GameModel class.
    /// </summary>
    [Serializable]
    public class GameModel
    {
        /// <summary>
        /// Size of the tile as an integer.
        /// </summary>
        private int tileSize;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameModel"/> class.
        /// GameModel constructor.
        /// </summary>
        public GameModel()
        {
            this.GridSize = 4;
            this.tileSize = (int)Config.Width / this.GridSize;

            this.Grid = new Tile[this.GridSize, this.GridSize];

            for (int i = 0; i < this.GridSize; i++)
            {
                for (int j = 0; j < this.GridSize; j++)
                {
                    this.Grid[i, j] = new Tile(i, j, this.tileSize, 0);
                }
            }
        }

        /// <summary>
        /// Gets or sets playerName.
        /// </summary>
        public string PlayerName { get; set; }

        /// <summary>
        /// Gets or sets currentScore.
        /// </summary>
        public int CurrentScore { get; set; }

        /// <summary>
        /// Gets or sets gridSize.
        /// </summary>
        public int GridSize { get; set; }

        /// <summary>
        /// Gets or sets grid.
        /// </summary>
        public Tile[,] Grid { get; set; }

        /// <summary>
        /// Gets or sets hours.
        /// </summary>
        public int Hours { get; set; }

        /// <summary>
        /// Gets or sets minutes.
        /// </summary>
        public int Minutes { get; set; }

        /// <summary>
        /// Gets or sets seconds.
        /// </summary>
        public int Seconds { get; set; }

        /// <summary>
        /// Gets or sets topScore.
        /// </summary>
        public int TopScore { get; set; }
    }
}
