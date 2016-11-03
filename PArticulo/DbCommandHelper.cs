using System;
using System.Data;

namespace Org.InsitutoSerpis.Ad
{
	public class DbCommandHelper
	{
		public static void AddParameter(IDbCommand dbCommand, string name, object value){
			//Esto es para añadir el parametro 
			IDbDataParameter dbDataParameter = dbCommand.CreateParameter();
			dbDataParameter.ParameterName=name;
			dbDataParameter.Value = value;
			dbCommand.Parameters.Add(dbDataParameter);
		}
	}
}

