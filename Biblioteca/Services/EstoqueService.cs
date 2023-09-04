using System;
using System.Linq;
using Biblioteca.Entities;
using Biblioteca.Repositories;
namespace Biblioteca.Services
{
	public class EstoqueService
	{
        private IRepository<ItemEstoque> estoqueRepository;

        public EstoqueService(IRepository<ItemEstoque> repository)
        {
            estoqueRepository = repository;
        }

        private bool ItemCadastrado(string titulo)
        {
            return estoqueRepository
                .GetAll()
                .Any(i => string.Equals(i.Item.Titulo, titulo, StringComparison.OrdinalIgnoreCase));
        }

        public void AdicionarItem(ItemEstoque item)
		{
            if(ItemCadastrado(item.Item.Titulo))
            {
                throw new InvalidOperationException($"O item '{item.Item.Titulo}' já está cadastrado no estoque.");
            }

            estoqueRepository.Add(item);
        }

        public void RemoverItem(string titulo)
        {
            if(!ItemCadastrado(titulo))
            {
                throw new InvalidOperationException($"O item '{titulo}' não está cadastrado no estoque.");
            }

            ItemEstoque item = estoqueRepository.GetAll().FirstOrDefault(i => i.Item.Titulo == titulo);

            estoqueRepository.Remove(item);
        }
    }
}

