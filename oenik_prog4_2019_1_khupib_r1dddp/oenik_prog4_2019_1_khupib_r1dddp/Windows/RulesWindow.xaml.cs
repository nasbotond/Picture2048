// <copyright file="RulesWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Game
{
    using System.Windows;

    /// <summary>
    /// Interaction logic for ScoreboardWindow view.
    /// </summary>
    public partial class RulesWindow : Window
    {
        /// <summary>
        /// MenuViewModel instance.
        /// </summary>
        private MenuViewModel vM;

        /// <summary>
        /// Initializes a new instance of the <see cref="RulesWindow"/> class.
        /// RulesWindow constructor.
        /// </summary>
        public RulesWindow()
        {
            this.WindowStyle = WindowStyle.None;
            this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            this.InitializeComponent();
            this.vM = this.FindResource("VM") as MenuViewModel;
        }
    }
}
