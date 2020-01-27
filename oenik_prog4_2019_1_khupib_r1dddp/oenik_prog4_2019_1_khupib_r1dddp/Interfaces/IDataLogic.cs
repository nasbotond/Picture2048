// <copyright file="IDataLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Game
{
    /// <summary>
    /// IDataLogic implements IRepository.
    /// </summary>
    /// <typeparam name="T">Generic type T.</typeparam>
    public interface IDataLogic<T> : IRepository<T>
        where T : class
    {
    }
}
