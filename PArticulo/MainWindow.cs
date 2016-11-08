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

		deleteAction.Activated += delegate {
			MessageDialog messageDialog = new MessageDialog(this, DialogFlags.Modal, MessageType.Question, ButtonsType.YesNo, "¿Quieres eliminar este registro?");
			ResponseType response = (ResponseType)messageDialog.Run();
			if (response != ResponseType.Yes)
				return;
			//TODO Eliminar
			
		};
		treeView.Selection.Changed += delegate {
			bool selected = treeView.Selection.CountSelectedRows() > 0;
			editAction.Sensitive = selected;
			deleteAction.Sensitive = selected;
		};
		newAction.Activated += delegate {
			new ArticuloView();
		};
		refreshAction.Activated += delegate {
			fill();
		};
		new ArticuloView ();

	}

	private void fill (){
		IList list = ArticuloDao.GetList ();
		editAction.Sensitive = false;
		deleteAction.Sensitive = false;
		TreeViewHelper.Fill (treeView, list);
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		App.Instance.DbConnection.Close ();
		Application.Quit ();
		a.RetVal = true;
	}
}

