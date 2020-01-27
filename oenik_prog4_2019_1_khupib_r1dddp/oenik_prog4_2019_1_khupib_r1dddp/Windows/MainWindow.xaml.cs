// <copyright file="MainWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Game
{
    using System.Windows;

    /// <summary>
    /// Interaction logic for MainWindow view.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// MainWindow constructor.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Gets or sets CurrentGC.
        /// </summary>
        public GameControl CurrentGC { get; set; }

        /// <summary>
        /// MenuButtonClick event.
        /// </summary>
        /// <param name="sender">sender object.</param>
        /// <param name="e">RoutedEventArgs event arguments.</param>
        private void MenuButtonClick(object sender, RoutedEventArgs e)
        {
            this.GameControlElement.Stopwatch.Stop();
        }
    }
}
