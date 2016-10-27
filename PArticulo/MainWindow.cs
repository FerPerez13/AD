using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using Gtk;

using Org.InstitutoSerpis.Ad;
using PArticulo; //Necesario para utilizar clases externas, en este caso PArticulo



public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		App.Instance.DbConnection = new MySqlConnection ("Database=dbprueba;User Id=root;Password=sistemas");

		App.Instance.DbConnection.Open ();
		fill ();



		TreeViewHelper.Fill (treeView, list);
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		dbConnection.Close ();
		Application.Quit ();
		a.RetVal = true;
	}

	private void fill (){

		List<Articulo> list = new List<Articulo> ();

		//TODO Hay que pasar estas líneas para que sea todo mucho más simple y sencillo
		string selectSql = "select * from articulo";
		IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand ();
		dbCommand.CommandText = selectSql;
		IDataReader dataReader = dbCommand.ExecuteReader ();
		while (dataReader.Read()) {
			long id = (long)dataReader ["id"];
			string nombre = (string)dataReader ["nombre"];
			decimal? precio = dataReader ["precio"] is DBNull ? null : (decimal?)dataReader ["precio"];
			long? categoria = dataReader ["categoria"] is DBNull ? null : (long?)dataReader ["categoria"];

			Articulo articulo = new Articulo (id, nombre, precio, categoria);
			list.Add (articulo);
		}

		dataReader.Close ();	
		editAction.Sensitive = false;

		treeView.Selection.Changed += delegate {
			bool selected = treeView.Selection.CountSelectedRows()>0;
			editAction.Sensitive=selected;
			deleteAction.Sensitive=selected;
		}
	}
}
