using System;
using Biblioteca.Entities;
using Biblioteca.Repositories;

namespace Biblioteca
{
    class Program
    {
        static Biblioteca biblioteca = new Biblioteca();

        static void Main(string[] args)
        {
            // Demonstração:
            Console.WriteLine("Bem-vindo à Biblioteca!");

            // Criando itens
            ItemBiblioteca livro = new Livro { Titulo = "O Senhor dos Anéis", Autor = "J.R.R. Tolkien", AnoPublicacao = 1954, QtdPaginas = 1200 };
            ItemBiblioteca revista = new Revista { Titulo = "Ciência Hoje", AnoPublicacao = 2022, QtdPaginas = 40 };
            ItemBiblioteca eBook = new MidiaDigital { Titulo = "Guia do Python", Autor = "J. Doe", AnoPublicacao = 2021 };

            // Adicionando itens à biblioteca
            biblioteca.AdicionarItem(livro, 5);  // 5 cópias do livro
            biblioteca.AdicionarItem(revista, 10);  // 10 cópias da revista
            biblioteca.AdicionarItem(eBook, 100);  // 100 licenças do eBook

            // Emprestando itens
            biblioteca.EmprestarItem("O Senhor dos Anéis");

            biblioteca.EmprestarItem("Ciência Hoje");

            // Devolvendo itens
            string devolver = biblioteca.DevolverItem("O Senhor dos Anéis");
            Console.WriteLine(devolver);

            Console.WriteLine("Demonstração concluída!");

            //ToDo: fazer um menu de interação com o usuário;
        }
    }
}
