// <copyright file="ScoreboardViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Game
{
    using GalaSoft.MvvmLight;

    /// <summary>
    /// ScoreboardViewModel implements ViewModelBase.
    /// </summary>
    public class ScoreboardViewModel : ViewModelBase
    {
        /// <summary>
        /// MenuLogic instance.
        /// </summary>
        private IMenuLogic logic = new MenuLogic();

        /// <summary>
        /// Initializes a new instance of the <see cref="ScoreboardViewModel"/> class.
        /// Constructor for ScoreboardViewModel.
        /// </summary>
        public ScoreboardViewModel()
        {
            this.Scoreboard = this.logic.ViewScoreBoard();
        }

        /// <summary>
        /// Gets Scoreboard.
        /// </summary>
        public string Scoreboard { get; private set; }
    }
}
