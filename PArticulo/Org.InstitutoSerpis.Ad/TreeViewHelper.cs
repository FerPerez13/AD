using Gtk;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;


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

		public static void AppendColumns(TreeView treeView, Type type){
			PropertyInfo[] propertyInfos = type.GetProperties ();
			List<string> propertyNames = new List<string> ();
			foreach (PropertyInfo propertyInfo in propertyInfos)
				propertyNames.Add (propertyInfo.Name);
			AppendColumns (treeView, propertyNames.ToArray());
		}

		public static void Fill (TreeView treeView, IList list){
			Type listType = list.GetType ();
			Type elementType = listType.GetGenericArguments () [0];
			PropertyInfo[] propertyInfos = elementType.GetProperties ();
			foreach (PropertyInfo propertyInfo in propertyInfos) {
				string columnName = propertyInfo.Name;
				treeView.AppendColumn (columnName, new CellRendererText (), delegate(TreeViewColumn tree_colum, CellRenderer cell, TreeModel tree_model, TreeIter iter) {
					object item = tree_model.GetValue(iter,0);
					object value = propertyInfo.GetValue(item,null);
					CellRendererText cellRendererText = (CellRendererText) cell;
					cellRendererText.Text = value == null ? "" : value.ToString(); //Si el valor no es null sale value.ToString
				});
			}
			ListStore listStore = new ListStore (typeof(object));		
			treeView.Model = listStore;
			foreach (object item in list)
				listStore.AppendValues (item);
		}
	}
}

