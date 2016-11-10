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
			win.Show ();

			//ArticuloView art = new ArticuloView ();
			//art.Show ();

			Application.Run ();
		}
	}
}
