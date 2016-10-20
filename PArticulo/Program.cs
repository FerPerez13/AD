using System;
using Gtk;

namespace PArticulo
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.Init ();
			MainWindow win = new MainWindow ();
			ArticuloView art = new ArticuloView ();

			win.Show ();
			art.Show ();
			Application.Run ();
		}
	}
}
