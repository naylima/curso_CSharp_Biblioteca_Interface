using System;
using System.Collections.Generic;
namespace Biblioteca.Repositories
{
	public interface IRepository<T>
	{
        void Add(T entity);
        void Remove(T entity);
        IEnumerable<T> GetAll();
    }
}

