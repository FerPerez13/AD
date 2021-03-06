using Gtk;
using System;

namespace Org.InstitutoSerpis.Ad
{
	public class TreeViewHelper
	{
		public static void AppendColumns (TreeView treeView, string[] columnNames)
		{
			for (int index=0; index < columnNames.Length; index++) {
				treeView.AppendColumn (columnNames [index], new CellRendererText (),
				                       delegate(TreeViewColumn tree_column, CellRenderer cell, TreeModel tree_model, TreeIter iter) {
					int column = Array.IndexOf (treeView.Columns, tree_column);
					CellRendererText cellRendererText = (CellRendererText)cell;
					object value = tree_model.GetValue (iter, column);
					cellRendererText.Text = value.ToString ();

				});

			}

		}
	}
}

