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
			//Cerramos
			mySqlConnection.Close ();
			Console.WriteLine ();
			Console.WriteLine ("Developed by FerPerez13");
		}
	}
}
