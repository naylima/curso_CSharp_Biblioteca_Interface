using System;
using System.Text;
using System.Globalization;
using Biblioteca.Entities;
using Biblioteca.Repositories;
using Biblioteca.Services;
namespace Biblioteca
{
    public class Biblioteca
    {
        private static readonly IRepository<ItemEstoque> estoqueRepository = new EstoqueRepository();
        private static readonly IRepository<ItemBiblioteca> bibliotecaRepository = new BibliotecaRepository();

        private readonly EstoqueService estoqueService = new EstoqueService(estoqueRepository);
        private readonly BibliotecaService bibliotecaService = new BibliotecaService(bibliotecaRepository);
        private readonly EmprestimoService emprestimoService = new EmprestimoService(estoqueRepository);

        public void AdicionarItem(ItemBiblioteca item, int quantidade)
        {
            try
            {
                estoqueService.AdicionarItem(new ItemEstoque { Item = item, Quantidade = quantidade });
                bibliotecaService.CadastrarItem(item);
                Console.WriteLine($"Item {item.Titulo} cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex.Message);
                throw ex;
            }
        }

        public void RemoverItem(string titulo)
        {
            try
            {
                estoqueService.RemoverItem(titulo);
                bibliotecaService.RemoverItem(titulo);
                Console.WriteLine($"O item {titulo} não faz mais parte da biblioteca!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex.Message);
                throw ex;
            }
        }

        public void EmprestarItem(string titulo)
        {
            try
            {
                IPodeSerEmprestado emprestavel = emprestimoService.Emprestar(titulo);
                Console.WriteLine($"Emprestado: {titulo} - Data para devolução: {emprestavel.DataLimiteDevolucao:dd/MM/yyyy}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex.Message);
                throw ex;
            }
        }

        public string DevolverItem(string titulo)
        {
            try
            {
                IPodeSerEmprestado emprestavel = emprestimoService.Devolver(titulo);

                StringBuilder builder = new StringBuilder();
                builder.AppendLine($"Devolvido: {titulo} - Data de devolução: {emprestavel.DataDevolucao:dd/MM/yyyy}");
                builder.AppendLine($"Data do empréstimo: {emprestavel.DataEmprestimo:dd/MM/yyyy}");
                builder.AppendLine($"Multa por atraso: {emprestavel.Multa.ToString("C", CultureInfo.CreateSpecificCulture("pt-BR"))}");

                return builder.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex.Message);
                throw ex;
            }
        }
    }
}

