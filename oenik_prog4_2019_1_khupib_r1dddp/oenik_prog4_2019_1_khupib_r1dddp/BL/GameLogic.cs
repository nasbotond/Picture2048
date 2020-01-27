// <copyright file="GameLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Game
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using GalaSoft.MvvmLight.Ioc;
    using Game.Data;

    /// <summary>
    /// GameLogic class implements IGameLogic interface.
    /// GameOver is an event when there is no more steps.
    /// </summary>
    public class GameLogic : IGameLogic
    {
        /// <summary>
        /// Static Random.
        /// </summary>
        private static Random rnd = new Random();

        /// <summary>
        /// bool indicating whether change happened or not.
        /// </summary>
        private bool changeHappened;

        /// <summary>
        /// GameModel instance.
        /// </summary>
        private GameModel model;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameLogic"/> class.
        /// PreferredConstructor for GameLogic.
        /// </summary>
        [PreferredConstructor]
        public GameLogic()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GameLogic"/> class.
        /// Constructor for GameLogic.
        /// </summary>
        /// <param name="model">GameModel model.</param>
        public GameLogic(GameModel model)
        {
            this.model = model;
            this.GameOver += this.GameLogic_GameOver;
        }

        /// <summary>
        /// GameOver Event Handler.
        /// </summary>
        public event EventHandler<GameOverEventArgs> GameOver;

        /// <summary>
        /// IncreaseScore method.
        /// </summary>
        /// <param name="tile">Tile whose value is used to increase score.</param>
        public void IncreaseScore(Tile tile)
        {
            this.model.CurrentScore += 2 * tile.Value;
        }

        /// <summary>
        /// MoveLeft function.
        /// </summary>
        /// <param name="grid">Tile 2D array.</param>
        /// <returns>bool whether change happened or not.</returns>
        public bool MoveLeft(Tile[,] grid)
        {
            this.changeHappened = false;
            int length = (int)Math.Sqrt(grid.Length);
            for (int row = 0; row < length; row++)
            {
                int col = -1;
                for (int y = 0; y < length; y++)
                {
                    if (grid[row, y].Value == 0)
                    {
                        continue;
                    }

                    if (col == -1)
                    {
                        col = y; // remember current col
                        continue;
                    }

                    if (grid[row, col].Value != grid[row, y].Value)
                    {
                        col = y; // update
                        continue;
                    }

                    if (grid[row, col].Value == grid[row, y].Value)
                    {
                        this.IncreaseScore(grid[row, col]);
                        grid[row, col].Value += grid[row, y].Value; // merge same numbers
                        grid[row, y].Value = 0;
                        this.changeHappened = true;
                        col = -1; // reset
                    }
                }

                int moveCol = 0;
                int x = 0;
                while (x < length)
                {
                    if (grid[row, x].Value == 0)
                    {
                        x++;
                    }

                    if (x < length)
                    {
                        if (grid[row, x].Value != 0)
                        {
                            if (moveCol == x)
                            {
                                moveCol++;
                                x++;
                            }
                            else
                            {
                                /*
                                int nextPos = x - 1;
                                while(nextPos != moveCol)
                                {
                                    grid[row, nextPos].Value = grid[row, nextPos + 1].Value;
                                    grid[row, nextPos + 1].Value = 0;
                                }
                                */
                                grid[row, moveCol].Value = grid[row, x].Value;
                                grid[row, x].Value = 0;
                                this.changeHappened = true;
                                moveCol++;
                                x++;
                            }
                        }
                    }
                }
            }

            if (this.changeHappened)
            {
                this.PlaceNewTile(grid);
            }

            return this.changeHappened;
        }

        /// <summary>
        /// MoveRight function.
        /// </summary>
        /// <param name="grid">2D array of tiles.</param>
        /// <returns>bool whether change happened or not.</returns>
        public bool MoveRight(Tile[,] grid)
        {
            // CheckGameOver(grid);
            this.changeHappened = false;
            int length = (int)Math.Sqrt(grid.Length);
            for (int row = 0; row < length; row++)
            {
                int col = -1;
                for (int y = length - 1; y >= 0; y--)
                {
                    if (grid[row, y].Value == 0)
                    {
                        continue;
                    }

                    if (col == -1)
                    {
                        col = y; // remember current col
                        continue;
                    }

                    if (grid[row, col].Value != grid[row, y].Value)
                    {
                        col = y; // update
                        continue;
                    }

                    if (grid[row, col].Value == grid[row, y].Value)
                    {
                        this.IncreaseScore(grid[row, col]);
                        grid[row, col].Value += grid[row, y].Value; // merge same numbers
                        grid[row, y].Value = 0;
                        this.changeHappened = true;
                        col = -1; // reset
                    }
                }

                int moveCol = length - 1;
                int x = length - 1;
                while (x >= 0)
                {
                    if (grid[row, x].Value == 0)
                    {
                        x--;
                    }

                    if (x >= 0)
                    {
                        if (grid[row, x].Value != 0)
                        {
                            if (moveCol == x)
                            {
                                moveCol--;
                                x--;
                            }
                            else
                            {
                                grid[row, moveCol].Value = grid[row, x].Value;
                                grid[row, x].Value = 0;
                                this.changeHappened = true;
                                moveCol--;
                                x--;
                            }
                        }
                    }
                }
            }

            if (this.changeHappened)
            {
                this.PlaceNewTile(grid);
            }

            return this.changeHappened;
        }

        /// <summary>
        /// MoveUp function.
        /// </summary>
        /// <param name="grid">2D array of tiles.</param>
        /// <returns>bool whether change happened or not.</returns>
        public bool MoveUp(Tile[,] grid)
        {
            // CheckGameOver(grid);
            this.changeHappened = false;
            int length = (int)Math.Sqrt(grid.Length);
            for (int col = 0; col < length; col++)
            {
                int row = -1;
                for (int y = 0; y < length; y++)
                {
                    if (grid[y, col].Value == 0)
                    {
                        continue;
                    }

                    if (row == -1)
                    {
                        row = y; // remember current row
                        continue;
                    }

                    if (grid[row, col].Value != grid[y, col].Value)
                    {
                        row = y; // update
                        continue;
                    }

                    if (grid[row, col].Value == grid[y, col].Value)
                    {
                        this.IncreaseScore(grid[row, col]);
                        grid[row, col].Value += grid[y, col].Value; // merge same numbers
                        grid[y, col].Value = 0;
                        this.changeHappened = true;
                        row = -1; // reset
                    }
                }

                int moveRow = 0;
                int x = 0;
                while (x < length)
                {
                    if (grid[x, col].Value == 0)
                    {
                        x++;
                    }

                    if (x < length)
                    {
                        if (grid[x, col].Value != 0)
                        {
                            if (moveRow == x)
                            {
                                moveRow++;
                                x++;
                            }
                            else
                            {
                                grid[moveRow, col].Value = grid[x, col].Value;
                                grid[x, col].Value = 0;
                                this.changeHappened = true;
                                moveRow++;
                                x++;
                            }
                        }
                    }
                }
            }

            if (this.changeHappened)
            {
                this.PlaceNewTile(grid);
            }

            return this.changeHappened;
        }

        /// <summary>
        /// MoveDown function.
        /// </summary>
        /// <param name="grid">2D array of tiles.</param>
        /// <returns>bool whether change happened or not.</returns>
        public bool MoveDown(Tile[,] grid)
        {
            // CheckGameOver(grid);
            this.changeHappened = false;
            int length = (int)Math.Sqrt(grid.Length);
            for (int col = 0; col < length; col++)
            {
                int row = -1;
                for (int y = length - 1; y >= 0; y--)
                {
                    if (grid[y, col].Value == 0)
                    {
                        continue;
                    }

                    if (row == -1)
                    {
                        row = y; // remember current row
                        continue;
                    }

                    if (grid[row, col].Value != grid[y, col].Value)
                    {
                        row = y; // update
                        continue;
                    }

                    if (grid[row, col].Value == grid[y, col].Value)
                    {
                        this.IncreaseScore(grid[row, col]);
                        grid[row, col].Value += grid[y, col].Value; // merge same numbers
                        grid[y, col].Value = 0;
                        this.changeHappened = true;
                        row = -1; // reset
                    }
                }

                int moveRow = length - 1;
                int x = length - 1;
                while (x >= 0)
                {
                    if (grid[x, col].Value == 0)
                    {
                        x--;
                    }

                    if (x >= 0)
                    {
                        if (grid[x, col].Value != 0)
                        {
                            if (moveRow == x)
                            {
                                moveRow--;
                                x--;
                            }
                            else
                            {
                                grid[moveRow, col].Value = grid[x, col].Value;
                                grid[x, col].Value = 0;
                                this.changeHappened = true;
                                moveRow--;
                                x--;
                            }
                        }
                    }
                }
            }

            if (this.changeHappened)
            {
                this.PlaceNewTile(grid);
            }

            return this.changeHappened;
        }

        /// <summary>
        /// OpenMenu function.
        /// </summary>
        public void OpenMenu()
        {
            MenuWindow menuWin = new MenuWindow();
            menuWin.Owner = Application.Current.MainWindow;
            if (menuWin.ShowDialog() == true)
            {
            }
        }

        /// <summary>
        /// ListOfEmptyTiles function.
        /// </summary>
        /// <param name="grid">2D array of tiles.</param>
        /// <returns>List of empty Tiles.</returns>
        public List<Tile> ListOfEmptyTiles(Tile[,] grid)
        {
            List<Tile> emptyTiles = new List<Tile>();
            foreach (Tile tile in grid)
            {
                if (tile.Value == 0)
                {
                    emptyTiles.Add(tile);
                }
            }

            return emptyTiles;
        }

        /// <summary>
        /// PlaceNewTile function.
        /// </summary>
        /// <param name="grid">2D array of tiles.</param>
        public void PlaceNewTile(Tile[,] grid)
        {
            List<Tile> emptyTiles = this.ListOfEmptyTiles(grid);
            Tile newTile = emptyTiles.ElementAt<Tile>(rnd.Next(0, emptyTiles.Count() - 1));
            grid[newTile.PosRow, newTile.PosCol].Value = 2; // return grid;
        }

        /// <summary>
        /// CheckGameOver function.
        /// </summary>
        /// <param name="grid">2D array of tiles.</param>
        /// <returns>true or false depends on the game is over or not.</returns>
        public bool CheckGameOver(Tile[,] grid)
        {
            List<Tile> emptyTiles = this.ListOfEmptyTiles(grid);

            if (emptyTiles.Count == 0)
            {
                bool left = this.MoveLeft(grid);
                bool right = this.MoveRight(grid);
                bool up = this.MoveUp(grid);
                bool down = this.MoveDown(grid);
                if (left == false && right == false && up == false && down == false)
                {
                    Application current = Application.Current;
                    foreach (Window win in current.Windows)
                    {
                        if (win.GetType() == typeof(MainWindow))
                        {
                            (win as MainWindow).GameControlElement.Stopwatch.Stop();
                        }
                    }

                    GameOverEventArgs args = new GameOverEventArgs();
                    args.FinalScore = this.model.CurrentScore;
                    args.FinalTime = new TimeSpan(this.model.Hours, this.model.Minutes, this.model.Seconds);
                    this.OnGameOver(args);
                    return true;
                }

                return false;
            }

            return false;
        }

        /// <summary>
        /// OnGameOver event.
        /// </summary>
        /// <param name="e">GameOverEventArgs event arguments.</param>
        protected virtual void OnGameOver(GameOverEventArgs e)
        {
            EventHandler<GameOverEventArgs> handler = this.GameOver;
            this.GameOver?.Invoke(this, e);
        }

        /// <summary>
        /// GameLogic_GameOver function.
        /// </summary>
        /// <param name="sender">sender object.</param>
        /// <param name="e">GameOverEventArgs event arguments.</param>
        private void GameLogic_GameOver(object sender, GameOverEventArgs e)
        {
            GameOverWindow window = new GameOverWindow();
            window.Owner = Application.Current.MainWindow;
            if (window.ShowDialog() == true)
            {
                ScoreboardItemLogic logic = ScoreboardItemLogic.CreateRealLogic();
                scoreboard_items newScore = new scoreboard_items();
                newScore.sbItem_id = logic.GetAll().Count() + 1;
                newScore.sbItem_playerName = window.PlayerName.Text;
                newScore.sbItem_score = e.FinalScore;
                newScore.sbItem_time = e.FinalTime;
                try
                {
                    logic.Insert(newScore);
                }
                catch (ArgumentNullException)
                {
                }
            }
        }
    }
}
