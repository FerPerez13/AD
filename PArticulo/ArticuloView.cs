using System;
using Gtk;
using System.Collections.Generic;
using System.Collections;
using System.Reflection;
using System.Data;

using Org.InstitutoSerpis.Ad;



namespace PArticulo
{
	public partial class ArticuloView : Gtk.Window
	{
		IDbCommand dbCommand;

		public ArticuloView () : base(Gtk.WindowType.Toplevel)
		{
			this.Build ();

			spinButtonPrecio.Value = 0; //stetic Bug
			saveAction.Sensitive = false;

			saveAction.Activated += delegate {
				Console.WriteLine ("saveAction.Activated");
				string nombre = entryNombre.Text;
				decimal precio = (decimal)spinButtonPrecio.Value;
				comboBoxCategoria.GetActiveIter();

				//Estas líneas tienen que estar siempre juntas
				TreeIter treeIter;
				comboBoxCategoria.GetActiveIter(out treeIter);

				object item = comboBoxCategoria.Model.GetValue(treeIter, 0);

				object value = item == Null.Value ? null : (object)(((Categoria) item).Id);

				string insertSql = "insert into articulo (nombre, precio, categoria) values (@nombre, @precio, @categoria)";
				IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand();
				dbCommand.CommandText = insertSql;
				DbCommandHelper.AddParameter(dbCommand, "nombre", nombre);
				DbCommandHelper.AddParameter(dbCommand, "precio", precio);

				dbCommand.ExecuteNonQuery();

			};
			entryNombre.Changed += delegate {
				string content = entryNombre.Text.Trim ();
				saveAction.Sensitive = content != string.Empty;
			};

			fill();

			ComboBoxHelper.Fill (comboBoxCategoria, list, "Nombre");
		
		}

		private void fill(){
			List<Categoria> list = new List<Categoria> ();
			IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand ();
			string selectSql = "select * from categoria order by nombre";
			dbCommand.CommandText = selectSql;
			IDataReader dataReader = dbCommand.ExecuteReader ();
			while (dataReader.Read()) {
				long id = (long)dataReader ["id"];
				string nombre = (string)dataReader ["nombre"];
				Categoria categoria = new Categoria (id, nombre);
				list.Add (categoria);
			}
			dataReader.Close ();
		}

	}

	public class Categoria{

		public long Id{get;set;}
		public string Nombre{ get; set;}

		public Categoria(long id, string nombre){
			Id = id;
			Nombre = nombre;
		}

	}
}

