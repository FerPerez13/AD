using System;
using Gtk;
using Org.InstitutoSerpis.Ad;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		string[] columnNames = { "id", "nombre", "precio" };
		TreeViewHelper.AppendColumns(treeView, columnNames);
			
		ListStore listStore = new ListStore (typeof(long), typeof(string), typeof(decimal));
		treeView.Model = listStore;
		listStore.AppendValues (1L, "categoría 1", 1.5m);
		listStore.AppendValues (2L, "categoría 2", 2.5m);


	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}
/* ALTERNATIVA ANTERIOR
		treeView.AppendColumn ("id", new CellRendererText (), //"text", 0);
			delegate(TreeViewColumn tree_column, CellRenderer cell, TreeModel tree_model, TreeIter iter) {

				CellRendererText cellRendererText = (CellRendererText)cell;
				object value = tree_model.GetValue(iter, 0);
				cellRendererText.Text = value.ToString();
		});

		treeView.AppendColumn ("nombre", new CellRendererText (), //"text", 1);
		  delegate(TreeViewColumn tree_column, CellRenderer cell, TreeModel tree_model, TreeIter iter) {

			CellRendererText cellRendererText = (CellRendererText)cell;
			object value = tree_model.GetValue(iter, 1);
			cellRendererText.Text = value.ToString();
		});

		treeView.AppendColumn ("precio", new CellRendererText (), 
			delegate(TreeViewColumn tree_column, CellRenderer cell, TreeModel tree_model, TreeIter iter) {

				CellRendererText cellRendererText = (CellRendererText)cell;
				object value = tree_model.GetValue(iter, 2);
				cellRendererText.Text = value.ToString();
		});
		*/