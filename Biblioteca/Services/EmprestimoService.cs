using System;
using System.Linq;
using Biblioteca.Entities;
using Biblioteca.Repositories;
namespace Biblioteca.Services
{
	public class EmprestimoService
	{
        private readonly IRepository<ItemEstoque> _estoqueRepository;

        public EmprestimoService(IRepository<ItemEstoque> repository)
        {
            _estoqueRepository = repository;
        }

        private ItemEstoque EncontrarItemEmEstoque(string titulo)
        {
            ItemEstoque itemEmEstoque = _estoqueRepository.GetAll().FirstOrDefault(i => i.Item.Titulo == titulo);
            return itemEmEstoque == null
                ? throw new InvalidOperationException($"O item '{titulo}' não está cadastrado no estoque.")
                : itemEmEstoque;
        }

        private IPodeSerEmprestado ValidarEObterEmprestavel(ItemBiblioteca item)
        {
            if (item is not IPodeSerEmprestado emprestavel)
            {
                throw new InvalidOperationException("Este item não disponível para empréstimo.");
            }
            return emprestavel;
        }

        public IPodeSerEmprestado Emprestar(string titulo)
        {
            ItemEstoque itemEmEstoque = EncontrarItemEmEstoque(titulo);
            IPodeSerEmprestado emprestavel = ValidarEObterEmprestavel(itemEmEstoque.Item);

            if (itemEmEstoque.Quantidade <= 0)
            {
                throw new InvalidOperationException("Estoque indisponível!");
            }

            emprestavel.Emprestar();
            itemEmEstoque.Quantidade--;

            return emprestavel;
        }

        public IPodeSerEmprestado Devolver(string titulo)
        {
            ItemEstoque itemEmEstoque = EncontrarItemEmEstoque(titulo);
            IPodeSerEmprestado emprestavel = ValidarEObterEmprestavel(itemEmEstoque.Item);

            emprestavel.Devolver();
            itemEmEstoque.Quantidade++;

            return emprestavel;
        }
    }
}

