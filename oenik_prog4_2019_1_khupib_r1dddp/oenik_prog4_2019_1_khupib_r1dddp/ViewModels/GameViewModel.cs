// <copyright file="GameViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Game
{
    using System.Windows.Input;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using Microsoft.Practices.ServiceLocation;

    /// <summary>
    /// GameViewModel implements ViewModelBase.
    /// </summary>
    public class GameViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GameViewModel"/> class.
        /// GameViewModel constructor.
        /// </summary>
        public GameViewModel()
        {
            this.MenuCmd = new RelayCommand(() => this.Logic.OpenMenu());
        }

        /// <summary>
        /// Gets Menu command.
        /// </summary>
        public ICommand MenuCmd { get; private set; }

        /// <summary>
        /// Gets or sets Control.
        /// </summary>
        public GameControl Control { get; set; }

        /// <summary>
        /// Gets Logic.
        /// </summary>
        private IGameLogic Logic
        {
            get { return ServiceLocator.Current.GetInstance<IGameLogic>(); }
        }
    }
}
