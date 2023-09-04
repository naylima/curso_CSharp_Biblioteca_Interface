using System;
namespace Biblioteca.Entities
{
	public abstract class ItemBiblioteca
	{
		public string Titulo { get; set; }
		public string Autor { get; set; }
		public int AnoPublicacao { get; set; }
		public int QtdPaginas { get; set; }
	}
}

