using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;

namespace PCategoria
{
	class MainClass
	{
		public enum Option {SALIR, NUEVO, EDITAR, BORRAR, LISTAR}

		public static IDbConnection dbConection;

		public static void Main (string[] args)
		{
			dbConection = new MySqlConnection ("Database=dbprueba;User Id=root;Password=sistemas");

			while (true) {
				Option option = getOption ();
				switch (option) {
				case Option.SALIR:
					dbConection.Close ();
					return;
				case Option.NUEVO:
					nuevo ();
					break;
				case Option.EDITAR:
					editar ();
					break;
				case Option.BORRAR:
					borrar ();
					break;
				case Option.LISTAR:
					listar ();
					break;
				}
			}

		}

		private static Option getOption(){
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

		private static string INSERT_SQL = "insert into categoria (nombre) values (@nombre)";
		private static void nuevo(){
			string nombre = leerString ("Nombre: ");
			IDbCommand dbCommand = dbConection.CreateCommand ();
			dbCommand.CommandText = INSERT_SQL;
			addParameter(dbCommand, "nombre", nombre);
			dbCommand.ExecuteNonQuery ();
		}

		private static void editar(){

		}

		private static string DELETE_SQL = "delete from categoría where id = @id";
		private static void borrar(){
			long id = readLong ("Id: ");
			IDbCommand dbCommand = dbConection.CreateCommand ();
			dbCommand.CommandText = DELETE_SQL;
			addParameter (dbCommand, "id", id);
		}

		private static void listar(){

		}

		private static void addParameter (IDbCommand dbCommand, string name, Object value){
			IDbDataAdapter dbDataParameter = dbCommand.CreateParameter ();
			dbDataParameter.ParameterName = name;
			dbDataParameter.Value = value;
			dbCommand.Parameters.Add (dbDataParameter);
		}

		private static string leerString (string label){
			Console.Write (label);
			string data = Console.ReadLine ();
			data = data.Trim;
			if (!data.Equals (""))
				return data;
			Console.WriteLine("No puede quedar vacío. Vuelve a introducir")
		}

		private static long readLong(string label){
			while (true){
				Console.WriteLine (label);
				string dara = Console.ReadLine ();
				try{

				}catch{

				}
}
