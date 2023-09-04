using System;
using System.Linq;
using Biblioteca.Entities;
using Biblioteca.Repositories;
namespace Biblioteca.Services
{
	public class BibliotecaService
	{
		private readonly IRepository<ItemBiblioteca> _bibliotecaRepository;

        public BibliotecaService(IRepository<ItemBiblioteca> repository)
        {
            _bibliotecaRepository = repository;
        }

        private bool ItemCadastrado(string titulo)
        {
            return _bibliotecaRepository
                .GetAll()
                .Any(i => string.Equals(i.Titulo, titulo, StringComparison.OrdinalIgnoreCase));
        }

        public void CadastrarItem(ItemBiblioteca item)
        {
            if(ItemCadastrado(item.Titulo))
            {
                throw new InvalidOperationException($"O item '{item.Titulo}' já existe na biblioteca.");
            }

            _bibliotecaRepository.Add(item);
        }

        public void RemoverItem(string titulo)
        {
            if (!ItemCadastrado(titulo))
            {
                throw new InvalidOperationException($"O item '{titulo}' não existe na biblioteca.");
            }

            ItemBiblioteca item = _bibliotecaRepository.GetAll().FirstOrDefault(i => i.Titulo == titulo);

            _bibliotecaRepository.Remove(item);
        }
    }
}

