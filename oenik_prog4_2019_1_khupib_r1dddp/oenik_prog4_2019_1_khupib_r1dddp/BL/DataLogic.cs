// <copyright file="DataLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Game
{
    using System.Linq;

    /// <summary>
    /// DataLogic class.
    /// </summary>
    /// <typeparam name="T">Type T.</typeparam>
    public class DataLogic<T> : IDataLogic<T>
        where T : class
    {
        /// <summary>
        /// IRepository instance.
        /// </summary>
        private readonly IRepository<T> repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLogic{T}"/> class.
        /// Constructor for DataLogic.
        /// </summary>
        /// <param name="repository">IRepository T.</param>
        public DataLogic(IRepository<T> repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Delete function.
        /// </summary>
        /// <param name="element">Type T.</param>
        public void Delete(T element)
        {
            this.repository.Delete(element);
        }

        /// <summary>
        /// GetAll function.
        /// </summary>
        /// <returns>Returns with a list of the elements.</returns>
        public IQueryable<T> GetAll()
        {
            return this.repository.GetAll();
        }

        /// <summary>
        /// GetById function.
        /// </summary>
        /// <param name="id">An id as an int.</param>
        /// <returns>Element T by id.</returns>
        public T GetById(int id)
        {
            return this.repository.GetById(id);
        }

        /// <summary>
        /// Insert function.
        /// </summary>
        /// <param name="element">T element.</param>
        public void Insert(T element)
        {
            this.repository.Insert(element);
        }

        /// <summary>
        /// Update function.
        /// </summary>
        /// <param name="element">T element.</param>
        public void Update(T element)
        {
            this.repository.Update(element);
        }
    }
}
