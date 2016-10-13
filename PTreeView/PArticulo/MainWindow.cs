using System;
using Gtk;
using Org.InstitutoSerpis.Ad;
using System.Collections.Generic;
using System.Collections;


public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();

		IList list = new List<Articulo> ();
		list.Add (new Articulo(1L, "Articulo1", 1.5m));
		list.Add (new Articulo(2L, "Articulo2", 2.5m));
		list.Add (new Articulo(3L, "Articulo3", 3.5m));
		list.Add (new Articulo(4L, "Articulo4", 4.5m));

//		IList list = new List<Categoria> ();
//		list.Add (new Categoria(1L, "Categoria1"));
//		list.Add (new Categoria(2L, "Categoria2"));
//		list.Add (new Categoria(3L, "Categoria3"));
//		list.Add (new Categoria(4L, "Categoria4"));

		TreeViewHelper.Fill (treeView, list);
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}

public class Categoria{
	public Categoria(long id, string nom){
		Id = id;
		Nombre = nom;
	}
	public long Id { get; set;}
	public string Nombre { get; set;}
}

public class Articulo{
	public Articulo(long id, string nom, decimal precio){
		Id = id;
		Nombre = nom;
		Precio = precio;
	}
	public long Id { get; set;}
	public string Nombre { get; set;}
	public decimal Precio { get; set;}
}