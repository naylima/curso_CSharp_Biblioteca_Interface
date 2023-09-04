using System;
using System.Collections.Generic;
using System.Linq;
using Biblioteca.Entities;
namespace Biblioteca.Repositories
{
	public class BibliotecaRepository : IRepository<ItemBiblioteca>
	{
		private List<ItemBiblioteca> itens = new List<ItemBiblioteca>();

		public void Add(ItemBiblioteca entity)
		{
			itens.Add(entity);
		}

		public void Remove(ItemBiblioteca entity)
		{
			itens.Remove(entity);
		}

		public IEnumerable<ItemBiblioteca> GetAll()
		{
			return itens;
		}

        public ItemBiblioteca GetByEntity(ItemBiblioteca entity)
        {
            return itens.FirstOrDefault(e => e.Equals(entity));
        }
    }
}

