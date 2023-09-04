using System;
using System.Linq;
using Biblioteca.Entities;
using Biblioteca.Repositories;
namespace Biblioteca.Services
{
	public class BibliotecaService
	{
		private IRepository<ItemBiblioteca> bibliotecaRepository;

        public BibliotecaService(IRepository<ItemBiblioteca> repository)
        {
            bibliotecaRepository = repository;
        }

        private bool ItemCadastrado(string titulo)
        {
            return bibliotecaRepository
                .GetAll()
                .Any(i => string.Equals(i.Titulo, titulo, StringComparison.OrdinalIgnoreCase));
        }

        public void CadastrarItem(ItemBiblioteca item)
        {
            if(ItemCadastrado(item.Titulo))
            {
                throw new InvalidOperationException($"O item '{item.Titulo}' já existe na biblioteca.");
            }

            bibliotecaRepository.Add(item);
        }

        public void RemoverItem(string titulo)
        {
            if (!ItemCadastrado(titulo))
            {
                throw new InvalidOperationException($"O item '{titulo}' não existe na biblioteca.");
            }

            ItemBiblioteca item = bibliotecaRepository.GetAll().FirstOrDefault(i => i.Titulo == titulo);

            bibliotecaRepository.Remove(item);
        }
    }
}

