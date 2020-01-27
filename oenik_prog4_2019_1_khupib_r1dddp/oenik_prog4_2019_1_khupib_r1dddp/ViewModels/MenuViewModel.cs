// <copyright file="MenuViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Game
{
    using System.Windows.Input;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.CommandWpf;

    /// <summary>
    /// MenuViewModel implements ViewModelBase.
    /// </summary>
    public class MenuViewModel : ViewModelBase
    {
        /// <summary>
        /// new instance of Logic.
        /// </summary>
        private IMenuLogic logic = new MenuLogic();

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuViewModel"/> class.
        /// Constructor for MenuViewModel.
        /// </summary>
        public MenuViewModel()
        {
            this.NewGameCmd = new RelayCommand(() => this.logic.StartNewGame());
            this.SaveGameCmd = new RelayCommand(() => this.logic.SaveGame("temp"));
            this.LoadGameCmd = new RelayCommand(() => this.logic.LoadGame("temp"));
            this.ExitGameCmd = new RelayCommand(() => this.logic.ExitGame());
            this.ViewScoreboardCmd = new RelayCommand(() => this.logic.ViewScoreBoard());
            this.ViewRulesCmd = new RelayCommand(() => this.logic.ViewRules());
            this.CloseMenuCmd = new RelayCommand(() => this.logic.CloseMenu());
        }

        /// <summary>
        /// Gets NewGame command.
        /// </summary>
        public ICommand NewGameCmd { get; private set; }

        /// <summary>
        /// Gets SaveGame command.
        /// </summary>
        public ICommand SaveGameCmd { get; private set; }

        /// <summary>
        /// Gets LoadGame command.
        /// </summary>
        public ICommand LoadGameCmd { get; private set; }

        /// <summary>
        /// Gets ExitGame command.
        /// </summary>
        public ICommand ExitGameCmd { get; private set; }

        /// <summary>
        /// Gets ViewScoreboard command.
        /// </summary>
        public ICommand ViewScoreboardCmd { get; private set; }

        /// <summary>
        /// Gets ViewRules command.
        /// </summary>
        public ICommand ViewRulesCmd { get; private set; }

        /// <summary>
        /// Gets CloseMenu command.
        /// </summary>
        public ICommand CloseMenuCmd { get; private set; }
    }
}
