using System;

namespace PArticulo
{
	public class Categoria{

		public long Id{get;set;}
		public string Nombre{ get; set;}

		public Categoria(long id, string nombre){
			Id = id;
			Nombre = nombre;
		}
	}
}

