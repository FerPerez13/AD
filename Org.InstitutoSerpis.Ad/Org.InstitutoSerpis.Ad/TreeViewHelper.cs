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

		public static void appendColumns(TreeView treeView, IList list){
			if (treeView.Columns.Length != 0)
				return;
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
		}
		private static void appendValues(TreeView treeView, IList list){
			ListStore listStore = new ListStore (typeof(object));		
			treeView.Model = listStore;
			foreach (object item in list)
				listStore.AppendValues (item);
		}

		public static object GetId(TreeView treeView){
			TreeIter treeIter;
			bool selected = treeView.Selection.GetSelected (out treeIter);
			if (!selected)
				return null;
			object item = treeView.Model.GetValue (treeIter, 0);
			return item == item.GetType ().GetProperty ("Id").GetValue (item, null);
		}

		public static object GetItem(TreeView treeView){
			TreeIter treeIter;
			bool selected = treeView.Selection.GetSelected (out treeIter);
			if (!selected)
				return null;
			return treeView.Model.GetValue (treeIter, 0);
		}
	
		public static void Fill (TreeView treeView, IList list){
			appendColumns (treeView, list);	//Añadimos columnas
			appendValues (treeView, list); //Añado datos
		}
			
	}
}

