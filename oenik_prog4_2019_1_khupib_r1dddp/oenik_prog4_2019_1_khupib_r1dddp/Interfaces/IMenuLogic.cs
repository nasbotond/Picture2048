// <copyright file="IMenuLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Game
{
    /// <summary>
    /// Interface IMenuLogic.
    /// </summary>
    public interface IMenuLogic
    {
        /// <summary>
        /// StartNewGame function.
        /// </summary>
        void StartNewGame();

        /// <summary>
        /// SaveGame function.
        /// </summary>
        /// <param name="fileName">string filename.</param>
        void SaveGame(string fileName);

        /// <summary>
        /// LoadGame function.
        /// </summary>
        /// <param name="fileName">string filename.</param>
        void LoadGame(string fileName);

        /// <summary>
        /// ViewScoreBoard function.
        /// </summary>
        /// <returns>string of the scoreboard content.</returns>
        string ViewScoreBoard();

        /// <summary>
        /// ViewRules function.
        /// </summary>
        /// <returns>string of the rules.</returns>
        string ViewRules();

        /// <summary>
        /// CloseMenu function.
        /// </summary>
        void CloseMenu();

        /// <summary>
        /// ExitGame function.
        /// </summary>
        void ExitGame();
    }
}
