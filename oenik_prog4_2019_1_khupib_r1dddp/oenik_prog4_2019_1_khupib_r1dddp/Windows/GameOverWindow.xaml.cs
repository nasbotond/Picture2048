// <copyright file="GameOverWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Game
{
    using System.Windows;

    /// <summary>
    /// Interaction logic for GameOverWindow view.
    /// </summary>
    public partial class GameOverWindow : Window
    {
        /// <summary>
        /// MenuViewModel VM.
        /// </summary>
        private MenuViewModel vM;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameOverWindow"/> class.
        /// GameOverWindow.
        /// </summary>
        public GameOverWindow()
        {
            this.WindowStyle = WindowStyle.None;
            this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            this.InitializeComponent();
            this.vM = this.FindResource("VM") as MenuViewModel;
        }

        /// <summary>
        /// button click event.
        /// </summary>
        /// <param name="sender">sender object.</param>
        /// <param name="e">RoutedEventArgs event arguments.</param>
        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
