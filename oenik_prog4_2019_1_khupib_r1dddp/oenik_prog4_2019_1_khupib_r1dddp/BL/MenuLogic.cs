// <copyright file="MenuLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Game
{
    using System;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Windows;
    using Game.Data;

    /// <summary>
    /// MenuLogic implements IMenuLogic.
    /// </summary>
    public class MenuLogic : IMenuLogic
    {
        /// <summary>
        /// Stream instance used in serialization.
        /// </summary>
        private Stream modelStream;

        /// <summary>
        /// Formatter used for serialization.
        /// </summary>
        private IFormatter f;

        /// <summary>
        /// ExitGame function.
        /// </summary>
        public void ExitGame()
        {
            App.Current.Shutdown();
        }

        /// <summary>
        /// LoadGame function.
        /// </summary>
        /// <param name="fileName">string parameter.</param>
        public void LoadGame(string fileName)
        {
            Application current = Application.Current;
            foreach (Window win in current.Windows)
            {
                if (win.GetType() == typeof(MainWindow))
                {
                    this.modelStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                    this.f = new BinaryFormatter();
                    GameModel loadedModel = (GameModel)this.f.Deserialize(this.modelStream);
                    TimeSpan loadedTimeSpan = new TimeSpan(loadedModel.Hours, loadedModel.Minutes, loadedModel.Seconds);
                    (win as MainWindow).GameControlElement.SwTimeSpan = loadedTimeSpan;
                    (win as MainWindow).GameControlElement.Stopwatch.Reset();
                    GameDisplay loadedDisplay = new GameDisplay(loadedModel);
                    GameLogic loadedLogic = new GameLogic(loadedModel);
                    (win as MainWindow).GameControlElement.Model = loadedModel;
                    (win as MainWindow).GameControlElement.Display = loadedDisplay;
                    (win as MainWindow).GameControlElement.Logic = loadedLogic;
                    this.modelStream.Close();
                    (win as MainWindow).GameControlElement.InvalidateVisual();
                    (win as MainWindow).GameControlElement.Stopwatch.Start();
                }
            }
        }

        /// <summary>
        /// SaveGame function.
        /// </summary>
        /// <param name="fileName">string fileName.</param>
        public void SaveGame(string fileName)
        {
            GameControl currentGC;
            GameModel currentGM;
            Application current = Application.Current;
            foreach (Window win in current.Windows)
            {
                if (win.GetType() == typeof(MainWindow))
                {
                    currentGC = (win as MainWindow).GameControlElement;
                    currentGM = currentGC.Model;
                    this.f = new BinaryFormatter();
                    this.modelStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                    this.f.Serialize(this.modelStream, currentGM);
                    this.modelStream.Close();
                    (win as MainWindow).GameControlElement.Stopwatch.Start();
                }
            }
        }

        /// <summary>
        /// CloseMenu function.
        /// </summary>
        public void CloseMenu()
        {
            Application current = Application.Current;
            foreach (Window win in current.Windows)
            {
                if (win.GetType() == typeof(MainWindow))
                {
                    (win as MainWindow).GameControlElement.Stopwatch.Start();
                }
            }
        }

        /// <summary>
        /// StartNewGame function.
        /// </summary>
        public void StartNewGame()
        {
            System.Diagnostics.Process.Start(App.ResourceAssembly.Location);
            App.Current.Shutdown();
        }

        /// <summary>
        /// ViewScoreBoard function.
        /// </summary>
        /// <returns>The string of the scoreboard.</returns>
        public string ViewScoreBoard()
        {
            string scoreboard = string.Empty;
            int ranking = 1;
            ScoreboardItemLogic logic = ScoreboardItemLogic.CreateRealLogic();
            foreach (scoreboard_items item in logic.GetOrderedScoreboard())
            {
                scoreboard += $"{ranking} {item.sbItem_playerName} {item.sbItem_score} {item.sbItem_time} \n";
                ranking++;
            }

            return scoreboard;
        }

        /// <summary>
        /// ViewRules function.
        /// </summary>
        /// <returns>The string of the rules.</returns>
        public string ViewRules()
        {
            string ruleText = "Move the tiles with the arrow keys. You can merge two identical tiles. After the merge you get the next tile. You can see the order of the tiles here at the right side. Each tile has a value which are added to the score when you merge the tiles. The goal is to reach the highest score as soon as possible.\nHave fun!";
            return ruleText;
        }
    }
}
