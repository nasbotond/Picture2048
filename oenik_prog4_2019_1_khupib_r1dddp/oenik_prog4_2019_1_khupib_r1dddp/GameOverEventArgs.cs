// <copyright file="GameOverEventArgs.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Game
{
    using System;

    /// <summary>
    /// GameOverEventArgs implements EventArgs.
    /// </summary>
    public class GameOverEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets FinalScore.
        /// </summary>
        public int FinalScore { get; set; }

        /// <summary>
        /// Gets or sets FinalTime.
        /// </summary>
        public TimeSpan FinalTime { get; set; }
    }
}