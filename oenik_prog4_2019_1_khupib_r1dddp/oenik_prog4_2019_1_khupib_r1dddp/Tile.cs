// <copyright file="Tile.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Game
{
    using System;
    using System.Windows;

    /// <summary>
    /// Serializable Tile class.
    /// </summary>
    [Serializable]
    public class Tile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Tile"/> class.
        /// Constructor for Tile.
        /// </summary>
        /// <param name="row">Row of tile.</param>
        /// <param name="col">Column of tile.</param>
        /// <param name="size">Size of tile.</param>
        /// <param name="value">Value of tile.</param>
        public Tile(int row, int col, int size, int value)
        {
            this.PosRow = row;
            this.PosCol = col;
            this.Size = size;
            this.Value = value;
            this.TileArea = new Rect(col * size, (row * size) + Config.Height - Config.Width, size, size);
        }

        // numerical value of tile instance

        /// <summary>
        /// Gets or sets Value.
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Gets or sets PosRow.
        /// </summary>
        public int PosRow { get; set; } // column position of the tile on the grid

        /// <summary>
        /// Gets or sets PosCol.
        /// </summary>
        public int PosCol { get; set; } // row position of the tile on the grid

        /// <summary>
        /// Gets or sets Size.
        /// </summary>
        public int Size { get; set; } // size of the tile determined by the size of the game (4x4, 6x6, etc.) TODO

        /// <summary>
        /// Gets or sets TileArea.
        /// </summary>
        public Rect TileArea { get; set; }
    }
}
