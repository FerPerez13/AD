using System;
using MySql.Data.MySqlClient;
using System.Data;

namespace PDbPrueba
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Programa para probar la conexión a la base de datos dbprueba!");
			//Declaración de la conexión a la BBDD
			//Abrimos
			IDbConnection dbConnection = new MySqlConnection ("Database=dbprueba;User Id=root; Password=sistemas");
			IDbCommand dbCommand = dbConnection.CreateCommand ();
			IDbDataParameter dbDataParameter = dbCommand.CreateParameter();
			IDbDataParameter dbDataParameter2 = dbCommand.CreateParameter();
			dbConnection.Open ();


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
						Console.WriteLine("Introduce una categoria");
						String nombre = Console.ReadLine ();
						dbCommand.CommandText="insert into categoria (nombre) values ('"+nombre+"');";
						dbCommand.ExecuteNonQuery();
						break;
				case 2:
						Console.WriteLine("Introduce una categoria");
						String catmod = Console.ReadLine();
						Console.WriteLine("Introduce una ID");
						String idmod = Console.ReadLine();
						int idint = int.Parse(idmod);
						dbCommand.CommandText="update categoria set nombre = ('"+catmod+"') where id = ('"+idint+"')";
						dbCommand.ExecuteNonQuery();
						dbCommand.Dispose();
						break;
				case 3:

					break;
				case 4:
						dbCommand.CommandText = "select * from categoria";
						IDataReader dataReader = dbCommand.ExecuteReader ();
						while(dataReader.Read()){
							//Procesar
							int id = dataReader.GetInt32(0);
							string nom = dataReader.GetString(1);
							Console.WriteLine("ID "+id+" "+"Nombre "+nom);
						}
						dataReader.Close();
						break;
				case 0:
						dbConnection.Close();
						Console.WriteLine("Hasta pronto!!");
						break;
				}
			}

			//Cerramos
			dbConnection.Close ();
			Console.WriteLine ("");
			Console.WriteLine ("Developed by FerPerez13");
		}
	}
}
