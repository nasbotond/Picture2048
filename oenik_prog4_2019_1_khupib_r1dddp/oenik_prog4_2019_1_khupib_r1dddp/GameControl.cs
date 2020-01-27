// <copyright file="GameControl.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Game
{
    using System;
    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Threading;
    using GalaSoft.MvvmLight.Ioc;
    using Microsoft.Practices.ServiceLocation;

    /// <summary>
    /// GameControl class which responsible for the control elements of the game.
    /// </summary>
    public class GameControl : FrameworkElement
    {
        /// <summary>
        /// Stopwatch timer.
        /// </summary>
        private Stopwatch stopwatch;

        /// <summary>
        /// ScoreboardItemLogic instance.
        /// </summary>
        private ScoreboardItemLogic scoreboardLogic = ScoreboardItemLogic.CreateRealLogic();

        /// <summary>
        /// dispatcherTimer for the stopwatch animation.
        /// </summary>
        private DispatcherTimer timer;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameControl"/> class.
        /// Constructor for GameControl.
        /// </summary>
        public GameControl()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<IGameLogic, GameLogic>();
            this.Loaded += this.GameControl_Loaded;
        }

        /// <summary>
        /// Gets or sets Model.
        /// </summary>
        public GameModel Model { get; set; }

        /// <summary>
        /// Gets or sets Display.
        /// </summary>
        public GameDisplay Display { get; set; }

        /// <summary>
        /// Gets or sets Logic.
        /// </summary>
        public GameLogic Logic { get; set; }

        /// <summary>
        /// Gets or sets TimeSpan.
        /// </summary>
        public TimeSpan SwTimeSpan { get; set; }

        /// <summary>
        /// Gets or sets Timer.
        /// </summary>
        public Stopwatch Stopwatch { get => this.stopwatch; set => this.stopwatch = value; }

        /// <summary>
        /// OnRender function.
        /// </summary>
        /// <param name="drawingContext">visual content DrawingContext.</param>
        protected override void OnRender(DrawingContext drawingContext)
        {
            if (this.Display != null)
            {
                this.Display.BuildDisplay(drawingContext);
            }
        }

        /// <summary>
        /// GameControl_Loaded event.
        /// </summary>
        /// <param name="sender">sender object.</param>
        /// <param name="e">RoutedEventArgs event arguments.</param>
        private void GameControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.Model = new GameModel();
            this.Display = new GameDisplay(this.Model);
            this.Logic = new GameLogic(this.Model);

            Window win = Window.GetWindow(this);
            if (win != null)
            {
                this.Model.TopScore = this.scoreboardLogic.GetTopScore();
                win.KeyDown += this.Win_KeyDown;
                this.Logic.PlaceNewTile(this.Model.Grid);
                this.timer = new DispatcherTimer();
                this.Stopwatch = new Stopwatch();
                this.timer.Interval = TimeSpan.FromMilliseconds(10);
                this.timer.Tick += this.Timer_Tick;
                this.timer.Start();
                this.Stopwatch.Start();
            }

            this.InvalidateVisual();
        }

        /// <summary>
        /// Timer_Tick event.
        /// </summary>
        /// <param name="sender">sender object.</param>
        /// <param name="e">EventArgs event arguments.</param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            this.Model.Hours = this.Stopwatch.Elapsed.Add(this.SwTimeSpan).Hours;
            this.Model.Minutes = this.Stopwatch.Elapsed.Add(this.SwTimeSpan).Minutes;
            this.Model.Seconds = this.Stopwatch.Elapsed.Add(this.SwTimeSpan).Seconds;
            if (this.Model.CurrentScore >= this.Model.TopScore)
            {
                this.Model.TopScore = this.Model.CurrentScore;
            }

            this.InvalidateVisual();
        }

        /// <summary>
        /// Win_KeyDown event.
        /// </summary>
        /// <param name="sender">sender object.</param>
        /// <param name="e">KeyEventArgs event arguments.</param>
        private void Win_KeyDown(object sender, KeyEventArgs e)
        {
            if (!this.Logic.CheckGameOver(this.Model.Grid))
            {
                switch (e.Key)
                {
                    case Key.Up:
                        this.Logic.MoveUp(this.Model.Grid);
                        break;
                    case Key.Down:
                        this.Logic.MoveDown(this.Model.Grid);
                        break;
                    case Key.Left:
                        this.Logic.MoveLeft(this.Model.Grid);
                        break;
                    case Key.Right:
                        this.Logic.MoveRight(this.Model.Grid);
                        break;
                    case Key.Escape:
                        this.Logic.OpenMenu();
                        break;
                }
            }

            this.InvalidateVisual();
        }
    }
}
