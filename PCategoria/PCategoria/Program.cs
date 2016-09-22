using System;
using System.Text.RegularExpressions;

namespace PCategoria
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Hello World!");
			getOption ();

			while (true) {
				int option = getOption ();
				switch (option) {
				case 0:
					return;
				case 1:
					nuevo ();
					break;
				case 2:
					editar ();
					break;
				case 3:
					borrar ();
					break;
				case 4:
					listar ();
					break;
				}
			}

		}

		private static int getOption(){
			string options = "01234";
			while (true) {
				Console.WriteLine ("0. Salir");
				Console.WriteLine ("1. Nuevo");
				Console.WriteLine ("2. Editar");
				Console.WriteLine ("3. Borrar");
				Console.WriteLine ("4. Listar");
				string option = Console.ReadLine ();
				if (Regex.IsMatch (option, "^[01234]$"))
					return int.Parse (option);
				Console.WriteLine ("Opción inválida. Vuelve a introducir.");
			}
		}

		private static void nuevo(){
			
		}

		private static void editar(){

		}

		private static void borrar(){

		}

		private static void listar(){

		}

	}
}
