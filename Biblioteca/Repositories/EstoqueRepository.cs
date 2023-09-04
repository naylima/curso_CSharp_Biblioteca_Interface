using System;
using System.Collections.Generic;
using System.Linq;
using Biblioteca.Entities;
namespace Biblioteca.Repositories
{
	public class EstoqueRepository : IRepository<ItemEstoque>
	{
		private List<ItemEstoque> estoque = new List<ItemEstoque>();

		public void Add(ItemEstoque entity)
		{
			estoque.Add(entity);
		}

		public void Remove(ItemEstoque entity)
		{
			estoque.Remove(entity);
		}

		public IEnumerable<ItemEstoque> GetAll()
		{
			return estoque;
		}

		public ItemEstoque GetByEntity(ItemBiblioteca item)
		{
			return estoque.FirstOrDefault(e => e.Item == item);
		}
	}
}

