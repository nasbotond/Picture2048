// <copyright file="Config.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Game
{
    /// <summary>
    /// Statics for the game width and height
    /// Config.
    /// </summary>
    public static class Config
    {
        /// <summary>
        /// Width of the game screen.
        /// </summary>
        private static double width = 400;

        /// <summary>
        /// Height of the game screen.
        /// </summary>
        private static double height = 600;

        /// <summary>
        /// Gets or sets width.
        /// </summary>
        public static double Width { get => width; set => width = value; }

        /// <summary>
        /// Gets or sets height.
        /// </summary>
        public static double Height { get => height; set => height = value; }
    }
}
