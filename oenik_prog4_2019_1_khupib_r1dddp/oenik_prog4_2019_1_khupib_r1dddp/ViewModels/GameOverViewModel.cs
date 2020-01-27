// <copyright file="GameOverViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Game
{
    using System.Windows.Input;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.CommandWpf;

    /// <summary>
    /// GameOverViewModel implements ViewModelBase.
    /// </summary>
    public class GameOverViewModel : ViewModelBase
    {
        /// <summary>
        /// Gets Logic.
        /// </summary>
        private IMenuLogic logic = new MenuLogic();

        /// <summary>
        /// Initializes a new instance of the <see cref="GameOverViewModel"/> class.
        /// Constructor for GameOverViewModel.
        /// </summary>
        public GameOverViewModel()
        {
            this.NewGameCmd = new RelayCommand(() => this.logic.StartNewGame());
            this.ExitGameCmd = new RelayCommand(() => this.logic.ExitGame());
        }

        /// <summary>
        /// Gets NewGame command.
        /// </summary>
        public ICommand NewGameCmd { get; private set; }

        /// <summary>
        /// Gets ExitGame command.
        /// </summary>
        public ICommand ExitGameCmd { get; private set; }
    }
}
