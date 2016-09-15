using System;
using MySql.Data.MySqlClient;

namespace PDbPrueba
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Programa para probar la conexión a la base de datos dbprueba!");
			//Declaración de la conexión a la BBDD
			MySqlConnection mySqlConnection = new MySqlConnection ("Database=dbprueba;User Id=root;Password=sistemas");
			//Abrimos
			mySqlConnection.Open ();
			//Menú
			Console.WriteLine ("");
			Console.WriteLine ("Que desea hacer:");
			Console.WriteLine ("1. Nuevo");
			Console.WriteLine ("2. Editar");
			Console.WriteLine ("3. Eliminar");
			Console.WriteLine ("4. Listar todos");
			Console.WriteLine ("0. Salir");
			Console.WriteLine ("");
			//Leemos desde el terminal
			string s = Console.ReadLine ();
			//Pasamos el String a Int
			int sel = int.Parse (s);
			//Comprobamos la selección
			if(sel!=0){
				switch(sel){
				case 1:
					Console.WriteLine ("Opción 1");
					break;
				case 2:
					break;
				case 3:
					break;
				case 4:
					break;
				case 0:
					break;
				}
			}
			Console.WriteLine (sel);

			//Cerramos
			mySqlConnection.Close ();
			Console.WriteLine ("");
			Console.WriteLine ("Developed by FerPerez13");
		}
	}
}
