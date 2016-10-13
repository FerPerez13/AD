using System;
using MySql.Data.MySqlClient;
using Gtk;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		MySqlConnection mySqlConnection = new MySqlConnection ("Database=dbprueba;User Id=root;Password=sistemas");
		Build ();
		mySqlConnection.Open ();
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}
