using System;
using Biblioteca.Services;
namespace Biblioteca.Entities
{
	public class Revista : ItemBiblioteca, IPodeSerEmprestado
	{
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }
        public DateTime DataLimiteDevolucao { get; set; }
        public decimal Multa { get; set; }

        public void Emprestar()
        {
            DataEmprestimo = DateTime.Now;
            DataLimiteDevolucao = DateTime.Now.AddDays(7);
        }

        public void Devolver()
        {
            DataDevolucao = DateTime.Now;
            CalcularMulta();
        }

        public void CalcularMulta()
        {
            if (DataDevolucao > DataLimiteDevolucao)
            {
                TimeSpan diasDeAtraso = DataDevolucao - DataLimiteDevolucao;
                Multa = diasDeAtraso.Days * 0.50m;
            }
            else
            {
                Multa = 0;
            }
        }
    }
}

