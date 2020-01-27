// <copyright file="ScoreboardItemLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Game
{
    using System.Collections.Generic;
    using System.Linq;
    using Game.Data;

    /// <summary>
    /// ScoreboardItemLogic implements DataLogic.
    /// </summary>
    public class ScoreboardItemLogic : DataLogic<scoreboard_items>
    {
        /// <summary>
        /// repository of scoreboard_items.
        /// </summary>
        private readonly IRepository<scoreboard_items> scoreboardRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScoreboardItemLogic"/> class.
        /// ScoreboardItemLogic.
        /// </summary>
        /// <param name="repository">IRepository scoreboard_items.</param>
        public ScoreboardItemLogic(IRepository<scoreboard_items> repository)
            : base(repository)
        {
            this.scoreboardRepository = repository;
        }

        /// <summary>
        /// CreateRealLogic function.
        /// </summary>
        /// <returns>ScoreboardItemLogic instance.</returns>
        public static ScoreboardItemLogic CreateRealLogic()
        {
            GameDatabaseEntities ge = new GameDatabaseEntities();
            ScoreboardItemRepository sir = new ScoreboardItemRepository(ge);
            return new ScoreboardItemLogic(sir);
        }

        /// <summary>
        /// GetOrderedScoreboard function.
        /// </summary>
        /// <returns>List of scoreboard_items.</returns>
        public IEnumerable<scoreboard_items> GetOrderedScoreboard()
        {
            var ordered = from list in this.scoreboardRepository.GetAll()
                           orderby list.sbItem_score descending
                           select list;
            return ordered;
        }

        /// <summary>
        /// GetTopScore function.
        /// </summary>
        /// <returns>The top score.</returns>
        public int GetTopScore()
        {
            int topScore = 0;
            if (this.scoreboardRepository.GetAll().Count() > 0)
            {
                var maxScore = this.scoreboardRepository.GetAll().Max(x => x.sbItem_score);
                topScore = (int)maxScore;
            }

            return topScore;
        }
    }
}
