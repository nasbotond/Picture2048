// <copyright file="RulesViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Game
{
    using GalaSoft.MvvmLight;

    /// <summary>
    /// RulesViewModel implements ViewModelBase.
    /// </summary>
    public class RulesViewModel : ViewModelBase
    {
        /// <summary>
        /// MenuLogic instance.
        /// </summary>
        private IMenuLogic logic = new MenuLogic();

        /// <summary>
        /// Initializes a new instance of the <see cref="RulesViewModel"/> class.
        /// Constructor for RulesViewModel.
        /// </summary>
        public RulesViewModel()
        {
            this.Rules = this.logic.ViewRules();
        }

        /// <summary>
        /// Gets Rules.
        /// </summary>
        public string Rules { get; private set; }
    }
}
