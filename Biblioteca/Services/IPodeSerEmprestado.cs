using System;
namespace Biblioteca.Services
{
	public interface IPodeSerEmprestado
	{
        DateTime DataEmprestimo { get; }
        DateTime DataDevolucao { get; }
        DateTime DataLimiteDevolucao { get; }
        decimal Multa { get; }

        void Emprestar();
        void Devolver();
        void CalcularMulta();
    }
}

