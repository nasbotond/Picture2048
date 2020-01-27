// <copyright file="Repository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Game
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    /// <summary>
    /// Repository implements IRepository.
    /// </summary>
    /// <typeparam name="T">Generic type T.</typeparam>
    public abstract class Repository<T> : IRepository<T>
        where T : class
    {
        /// <summary>
        /// Read only context.
        /// </summary>
        private readonly DbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{T}"/> class.
        /// Constructor for Repository.
        /// </summary>
        /// <param name="context">DbContext instance.</param>
        public Repository(DbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Gets Context.
        /// </summary>
        public DbContext Context
        {
            get
            {
                return this.context;
            }
        }

        /// <summary>
        /// Delete function.
        /// </summary>
        /// <param name="element">T element.</param>
        public void Delete(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("No element found");
            }

            this.context.Set<T>().Remove(element);
            this.context.SaveChanges();
        }

        /// <summary>
        /// GetAll function.
        /// </summary>
        /// <returns>All the elements.</returns>
        public IQueryable<T> GetAll()
        {
            return this.context.Set<T>();
        }

        /// <summary>
        /// GetById function.
        /// </summary>
        /// <param name="id">id as an integer.</param>
        /// <returns>an element by id.</returns>
        public abstract T GetById(int id);

        /// <summary>
        /// Insert function.
        /// </summary>
        /// <param name="element">element to insert.</param>
        public void Insert(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("No element found");
            }

            this.context.Set<T>().Add(element);
            this.context.SaveChanges();
        }

        /// <summary>
        /// Update function.
        /// </summary>
        /// <param name="element">element to update.</param>
        public void Update(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("No element found");
            }

            this.context.Set<T>().Attach(element);
            this.context.Entry(element).State = EntityState.Modified;
            this.context.SaveChanges();
        }
    }
}
