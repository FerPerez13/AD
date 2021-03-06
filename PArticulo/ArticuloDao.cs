using System;
using System.Data;
using System.Reflection;
using System.Collections.Generic;

using Org.InstitutoSerpis.Ad;

namespace PArticulo
{
	public class ArticuloDao
	{
		private const string SELECT_SQL = "select * from articulo";
		private const string INSERT_SQL = "insert into articulo (nombre, precio, categoria) values (@nombre, @precio, @categoria)";
		private const string DELETE_SQL = "delete from articulo where id = @id";
		private const string SELECT_ID_SQL = "select * from articulo where id = @id";
		private const string UPDATE_SQL = "update articulo set nombre = @nombre, precio = @precio, categoria = @categoria here id = @id");

		public static List<Articulo> GetList(){
			List<Articulo> list = new List<Articulo> ();
			IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand ();
			dbCommand.CommandText = SELECT_SQL;
			IDataReader dataReader = dbCommand.ExecuteReader ();
			while (dataReader.Read()) {
				long id = (long)dataReader ["id"];
				string nombre = (string)dataReader ["nombre"];
				decimal? precio = dataReader ["precio"] is DBNull ? null : (decimal?)dataReader ["precio"];
				long? categoria = dataReader ["categoria"] is DBNull ? null : (long?)dataReader ["categoria"];

				Articulo articulo = new Articulo ((long)id, nombre, precio, categoria);
				list.Add (articulo);
			}
			dataReader.Close ();
			return list;
		}

		//TODO: Hay que separar el Save para tener los casos de salvar uno nuevo o modiicar uno que ya está guardado
		//TODO: Además hay que poner en los métodos los try-catch
		//TODO: Reparar todos los problemas que se tenga en el código para que funcione correctamente

		public static void Save(Articulo articulo){
			IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand();
			DbCommandHelper.AddParameter(dbCommand, "nombre", articulo.Nombre);
			DbCommandHelper.AddParameter(dbCommand, "precio", articulo.Precio);
			DbCommandHelper.AddParameter(dbCommand, "categoria", articulo.Categoria);
			if (articulo.Id == 0) {
				dbCommand.CommandText = INSERT_SQL;
			} else{ 
				DbCommandHelper.AddParameter(dbCommand,"id", articulo.Id;
				dbCommand.CommandText = UPDATE_SQL;

			}
			dbCommand.ExecuteNonQuery();
		}
		public static void Load(long id){
			IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand();
			dbCommand.CommandText = SELECT_ID_SQL;
			DbCommandHelper.AddParameter (dbCommand, "id", id);
			dbCommand.ExecuteNonQuery();
		}
		public static void Delete(object id){
			IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand ();
			dbCommand.CommandText = DELETE_SQL;
			DbCommandHelper.AddParameter (dbCommand, "id", id);
			dbCommand.ExecuteNonQuery ();
			//TODO: Lanzar Excepciones
		}
	}




}

