// <copyright file="GameDisplay.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Game
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

    /// <summary>
    /// GameDisplay class.
    /// </summary>
    public class GameDisplay
    {
        /// <summary>
        /// GameModel instance.
        /// </summary>
        private GameModel model;

        /// <summary>
        /// Black pen.
        /// </summary>
        private Pen black = new Pen(Brushes.Black, 2);

        /// <summary>
        /// Gold pen.
        /// </summary>
        private Pen gold = new Pen(Brushes.Gold, 1);

        /// <summary>
        /// background rectangle.
        /// </summary>
        private Rect backGroundRect;

        /// <summary>
        /// Grid rectangle.
        /// </summary>
        private Rect gridRect;

        /// <summary>
        /// Point location of the current score.
        /// </summary>
        private Point currentScoreLocation = new Point(90, (Config.Width / 2) - 82);

        /// <summary>
        /// Point location of the top score.
        /// </summary>
        private Point topScoreLocation = new Point(320, (Config.Width / 2) - 40);

        /// <summary>
        /// Point location of the timer.
        /// </summary>
        private Point timerTextLocation = new Point(83, (Config.Width / 2) - 40);

        /// <summary>
        /// Font of the text.
        /// </summary>
        private Typeface font = new Typeface("Arial");

        /// <summary>
        /// Initializes a new instance of the <see cref="GameDisplay"/> class.
        /// Constructor for GameDisplay.
        /// </summary>
        /// <param name="model">GameModel instance.</param>
        public GameDisplay(GameModel model)
        {
            this.model = model;
            this.backGroundRect = new Rect(0, 0, Config.Width, Config.Height);
            this.gridRect = new Rect(0, Config.Height - Config.Width, Config.Width, Config.Width);
        }

        /// <summary>
        /// BuildDisplay function.
        /// </summary>
        /// <param name="ctx">DrawingContext instance.</param>
        public void BuildDisplay(DrawingContext ctx)
        {
            this.BuildBackground(ctx);
            this.BuildGrid(ctx);
            this.BuildTiles(ctx);
            this.BuildCurrentScoreText(ctx);
            this.BuildTimerText(ctx);
            this.BuildTopScoreText(ctx);
        }

        /// <summary>
        /// BuildTimerText function.
        /// </summary>
        /// <param name="ctx">DrawingContext instance.</param>
        private void BuildTimerText(DrawingContext ctx)
        {
            string currentTime = string.Format("{0:00}:{1:00}:{2:00}", this.model.Hours, this.model.Minutes, this.model.Seconds);
            FormattedText currentTimeText = new FormattedText(currentTime, CultureInfo.CurrentCulture, FlowDirection.LeftToRight, this.font, 24, Brushes.Gold);
            ctx.DrawText(currentTimeText, this.timerTextLocation);
        }

        /// <summary>
        /// BuildTiles function.
        /// </summary>
        /// <param name="ctx">DrawingContext instance.</param>
        private void BuildTiles(DrawingContext ctx)
        {
            foreach (Tile t in this.model.Grid)
            {
                if (t.Value == 0)
                {
                    ctx.DrawRectangle(Brushes.Black, this.gold, t.TileArea);
                }
                else if (t.Value == 2)
                {
                    ImageSource img = new BitmapImage(new Uri("tilesInProject/mandala_1.jpg", UriKind.Relative));
                    ctx.DrawImage(img, new Rect(t.PosCol * t.Size, (t.PosRow * t.Size) + (t.Size * 2), t.Size, t.Size));
                }
                else if (t.Value == 4)
                {
                    ImageSource img = new BitmapImage(new Uri("tilesInProject/mandala_2.jpg", UriKind.Relative));
                    ctx.DrawImage(img, new Rect(t.PosCol * t.Size, (t.PosRow * t.Size) + (t.Size * 2), t.Size, t.Size));
                }
                else if (t.Value == 8)
                {
                    ImageSource img = new BitmapImage(new Uri("tilesInProject/mandala_3.jpg", UriKind.Relative));
                    ctx.DrawImage(img, new Rect(t.PosCol * t.Size, (t.PosRow * t.Size) + (t.Size * 2), t.Size, t.Size));
                }
                else if (t.Value == 16)
                {
                    ImageSource img = new BitmapImage(new Uri("tilesInProject/mandala_4.jpg", UriKind.Relative));
                    ctx.DrawImage(img, new Rect(t.PosCol * t.Size, (t.PosRow * t.Size) + (t.Size * 2), t.Size, t.Size));
                }
                else if (t.Value == 32)
                {
                    ImageSource img = new BitmapImage(new Uri("tilesInProject/mandala_5.jpg", UriKind.Relative));
                    ctx.DrawImage(img, new Rect(t.PosCol * t.Size, (t.PosRow * t.Size) + (t.Size * 2), t.Size, t.Size));
                }
                else if (t.Value == 64)
                {
                    ImageSource img = new BitmapImage(new Uri("tilesInProject/mandala_6.jpg", UriKind.Relative));
                    ctx.DrawImage(img, new Rect(t.PosCol * t.Size, (t.PosRow * t.Size) + (t.Size * 2), t.Size, t.Size));
                }
                else if (t.Value == 128)
                {
                    ImageSource img = new BitmapImage(new Uri("tilesInProject/mandala_7.jpg", UriKind.Relative));
                    ctx.DrawImage(img, new Rect(t.PosCol * t.Size, (t.PosRow * t.Size) + (t.Size * 2), t.Size, t.Size));
                }
                else if (t.Value == 256)
                {
                    ImageSource img = new BitmapImage(new Uri("tilesInProject/mandala_8.jpg", UriKind.Relative));
                    ctx.DrawImage(img, new Rect(t.PosCol * t.Size, (t.PosRow * t.Size) + (t.Size * 2), t.Size, t.Size));
                }
                else if (t.Value == 512)
                {
                    ImageSource img = new BitmapImage(new Uri("tilesInProject/mandala_9.jpg", UriKind.Relative));
                    ctx.DrawImage(img, new Rect(t.PosCol * t.Size, (t.PosRow * t.Size) + (t.Size * 2), t.Size, t.Size));
                }
                else if (t.Value == 1024)
                {
                    ImageSource img = new BitmapImage(new Uri("tilesInProject/mandala_10.jpg", UriKind.Relative));
                    ctx.DrawImage(img, new Rect(t.PosCol * t.Size, (t.PosRow * t.Size) + (t.Size * 2), t.Size, t.Size));
                }
                else if (t.Value == 2048)
                {
                    ImageSource img = new BitmapImage(new Uri("tilesInProject/mandala_11.jpg", UriKind.Relative));
                    ctx.DrawImage(img, new Rect(t.PosCol * t.Size, (t.PosRow * t.Size) + (t.Size * 2), t.Size, t.Size));
                }
                else if (t.Value == 4096)
                {
                    ImageSource img = new BitmapImage(new Uri("tilesInProject/mandala_12.jpg", UriKind.Relative));
                    ctx.DrawImage(img, new Rect(t.PosCol * t.Size, (t.PosRow * t.Size) + (t.Size * 2), t.Size, t.Size));
                }
                else if (t.Value == 8192)
                {
                    ImageSource img = new BitmapImage(new Uri("tilesInProject/mandala_13.jpg", UriKind.Relative));
                    ctx.DrawImage(img, new Rect(t.PosCol * t.Size, (t.PosRow * t.Size) + (t.Size * 2), t.Size, t.Size));
                }
                else if (t.Value == 16384)
                {
                    ImageSource img = new BitmapImage(new Uri("tilesInProject/mandala_14.jpg", UriKind.Relative));
                    ctx.DrawImage(img, new Rect(t.PosCol * t.Size, (t.PosRow * t.Size) + (t.Size * 2), t.Size, t.Size));
                }
                else if (t.Value == 32768)
                {
                    ImageSource img = new BitmapImage(new Uri("tilesInProject/mandala_15.jpg", UriKind.Relative));
                    ctx.DrawImage(img, new Rect(t.PosCol * t.Size, (t.PosRow * t.Size) + (t.Size * 2), t.Size, t.Size));
                }
            }
        }

        /// <summary>
        /// BuildGrid function.
        /// </summary>
        /// <param name="ctx">DrawingContext instance.</param>
        private void BuildGrid(DrawingContext ctx)
        {
            ctx.DrawRectangle(Brushes.Beige, this.black, this.gridRect);
        }

        /// <summary>
        /// BuildBackground function.
        /// </summary>
        /// <param name="ctx">DrawingContext instance.</param>
        private void BuildBackground(DrawingContext ctx)
        {
            ctx.DrawRectangle(Brushes.Black, null, this.backGroundRect);
        }

        /// <summary>
        /// BuildCurrentScoreText function.
        /// </summary>
        /// <param name="ctx">DrawingContext instance.</param>
        private void BuildCurrentScoreText(DrawingContext ctx)
        {
            FormattedText currentScore = new FormattedText(this.model.CurrentScore.ToString(), CultureInfo.CurrentCulture, FlowDirection.LeftToRight, this.font, 24, Brushes.Gold);
            ctx.DrawText(currentScore, this.currentScoreLocation);
        }

        /// <summary>
        /// BuildTopScoreText function.
        /// </summary>
        /// <param name="ctx">DrawingContext instance.</param>
        private void BuildTopScoreText(DrawingContext ctx)
        {
            FormattedText topScore = new FormattedText(this.model.TopScore.ToString(), CultureInfo.CurrentCulture, FlowDirection.LeftToRight, this.font, 24, Brushes.Gold);
            ctx.DrawText(topScore, this.topScoreLocation);
        }
    }
}
