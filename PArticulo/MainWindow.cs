using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Collections;
using Gtk;

using PArticulo; 
using Org.InstitutoSerpis.Ad;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		App.Instance.DbConnection = new MySqlConnection ("Database=dbprueba;User Id=root;Password=sistemas");
		App.Instance.DbConnection.Open ();
		fill ();

		IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand ();
		dbCommand.CommandText = "update articulo set precio=0 where precio is null";
		dbCommand.ExecuteNonQuery ();
	
		//Acciones de los Botones de la ventana

		newAction.Activated += delegate {
			Articulo articulo = new Articulo();
			new ArticuloView(articulo);
		};
		editAction.Activated += delegate {
			Articulo articulo = new ArticuloDao.Load(TreeViewHelper.GetId(treeView));
			new ArticuloView(articulo);
		};
		refreshAction.Activated += delegate {
			fill();
		};
		treeView.Selection.Changed += delegate {
			bool selected = treeView.Selection.CountSelectedRows() > 0;
			editAction.Sensitive = selected;
			deleteAction.Sensitive = selected;
		};
		deleteAction.Activated += delegate {
			if(WindowHelper.Confirm(this, "Quieres eliminar el registro")){
				ArticuloDao.Delete(TreeViewHelper.GetId(treeView));
				Console.WriteLine("Borrado: "+TreeViewHelper.GetId(treeView));
			}
			Console.WriteLine("Borrado: "+TreeViewHelper.GetId(treeView));
		};
	}

	private void fill (){
		editAction.Sensitive = false;
		deleteAction.Sensitive = false;
		IList list = EntityDao.GetList<Articulo> ();
		TreeViewHelper.Fill (treeView, list);
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		App.Instance.DbConnection.Close ();
		Application.Quit ();
		a.RetVal = true;
	}
}

