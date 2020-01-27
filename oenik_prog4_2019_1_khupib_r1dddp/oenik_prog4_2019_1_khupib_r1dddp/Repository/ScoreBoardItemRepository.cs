// <copyright file="ScoreboardItemRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Game
{
    using System.Data.Entity;
    using System.Linq;
    using Game.Data;

    /// <summary>
    /// ScoreboardItemRepository class.
    /// </summary>
    public class ScoreboardItemRepository : Repository<scoreboard_items>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScoreboardItemRepository"/> class.
        /// ScoreboardItemRepository constructor.
        /// </summary>
        /// <param name="context">DbContext instance.</param>
        public ScoreboardItemRepository(DbContext context)
            : base(context)
        {
        }

        /// <summary>
        /// GetById function.
        /// </summary>
        /// <param name="id">id as an integer.</param>
        /// <returns>scoreboard_items of that id.</returns>
        public override scoreboard_items GetById(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.sbItem_id == id);
        }
    }
}
