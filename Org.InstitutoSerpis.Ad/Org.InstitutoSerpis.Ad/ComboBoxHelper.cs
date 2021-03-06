using System;
using Gtk;
using System.Collections;
using System.Reflection;

namespace Org.InstitutoSerpis.Ad
{
	public class ComboBoxHelper
	{
		public static void Fill (ComboBox comboBox, IList list, string propertyName, object id){ //Añadimos un objeto id
			Type listType = list.GetType();
			Type elementType = listType.GetGenericArguments()[0];
			PropertyInfo namePropertyInfo = elementType.GetProperty(propertyName);
			PropertyInfo idPropertyInfo = elementType.GetProperty("Id");

			ListStore listStore = new ListStore (typeof(object));

			TreeIter initialTreeIter = listStore.AppendValues (Null.Value);
			foreach (object item in list) {
				TreeIter treeIter = listStore.AppendValues (item);
				// if item.id == id -> initialTreeIter = treeIter;
				if (idPropertyInfo.GetValue (item, null).Equals (id))
					initialTreeIter = treeIter;
			}
			comboBox.Model = listStore;

			comboBox.SetActiveIter(initialTreeIter);
			CellRendererText cellRendererText = new CellRendererText ();
			comboBox.PackStart (cellRendererText, false);
			comboBox.SetCellDataFunc(cellRendererText, delegate(CellLayout cell_layout, CellRenderer cell, TreeModel tree_model, TreeIter iter) {

				//Estas líneas son solo para Categoriá. Lo queremos para cualuier clase utilizando genericos
				//				Categoria categoria = (Categoria)tree_model.GetValue(iter,0);
				//				cellRendererText.Text = categoria.Nombre;

				//Ahora vamos a ver las lineas que son genericas para cualquier clase de objetos
				object item = tree_model.GetValue(iter,0);

				object value = item == Null.Value ? "<sin asignar>" : namePropertyInfo.GetValue(item, null);
				cellRendererText.Text=value.ToString();
			});
		}

		public static object GetId(ComboBox comboBox){
			TreeIter treeIter;
			comboBox.GetActiveIter (out treeIter);
			object item = comboBox.Model.GetValue (treeIter, 0);
//			return item == Null.Value ? null : (object)(((Categoria)item).Id); //Esto lo declaramos más claro abajo

//			if (item == Null.Value)
//				return null;
//			Type elementType = item.GetType ();
//			PropertyInfo propertyInfo = elementType.GetProperty ("Id");
//			return propertyInfo.GetValue (item, null); //Abajo traducimos todo esto en una sola línea
		
			return item == Null.Value ? null : item.GetType ().GetProperty ("Id").GetValue (item, null);
		}

	}
}

