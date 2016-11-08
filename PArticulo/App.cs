using System;
using System.Data;

namespace Org.InstitutoSerpis.Ad{

	public class App{

		public App (){

		}

		public static App instance = new App ();

		public static App Instance{
			get{ return instance; }
		}

		private IDbConnection dbConneection;

		public IDbConnection DbConnection{
			get{return dbConneection;}
			set{dbConneection = value;}
		}
	}
}

