// <copyright file="MenuWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Game
{
    using System.Windows;

    /// <summary>
    /// Interaction logic for MenuWindow view.
    /// </summary>
    public partial class MenuWindow : Window
    {
        /// <summary>
        /// private MenuViewModel instance.
        /// </summary>
        private MenuViewModel vM;

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuWindow"/> class.
        /// MenuWindow constructor.
        /// </summary>
        public MenuWindow()
        {
            this.WindowStyle = WindowStyle.None;
            this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            this.InitializeComponent();
            this.vM = this.FindResource("VM") as MenuViewModel;
        }

        /// <summary>
        /// SaveButtonClick event.
        /// </summary>
        /// <param name="sender">sender object.</param>
        /// <param name="e">RoutedEventArgs event arguments.</param>
        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        /// <summary>
        /// LoadButtonClick event.
        /// </summary>
        /// <param name="sender">sender object.</param>
        /// <param name="e">RoutedEventArgs event arguments.</param>
        private void LoadButtonClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        /// <summary>
        /// CloseMenuClick event.
        /// </summary>
        /// <param name="sender">sender object.</param>
        /// <param name="e">RoutedEventArgs event arguments.</param>
        private void CloseMenuClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        /// <summary>
        /// ScoreboardClick event.
        /// </summary>
        /// <param name="sender">sender object.</param>
        /// <param name="e">RoutedEventArgs event arguments.</param>
        private void ScoreboardClick(object sender, RoutedEventArgs e)
        {
            ScoreboardWindow window = new ScoreboardWindow();
            window.Owner = Application.Current.MainWindow;
            if (window.ShowDialog() == true)
            {
            }
        }

        /// <summary>
        /// RulesClick event.
        /// </summary>
        /// <param name="sender">sender object.</param>
        /// <param name="e">RoutedEventArgs event arguments.</param>
        private void RulesClick(object sender, RoutedEventArgs e)
        {
            RulesWindow window = new RulesWindow();
            window.Owner = Application.Current.MainWindow;
            if (window.ShowDialog() == true)
            {
            }
        }
    }
}
