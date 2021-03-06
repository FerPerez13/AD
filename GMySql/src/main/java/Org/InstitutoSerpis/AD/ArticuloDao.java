package Org.InstitutoSerpis.AD;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

public class ArticuloDao {

	public static void main(String[] args) throws SQLException {
		Connection connection = DriverManager.getConnection("jdbc:mysql://localhost/dbprueba", "root", "sistemas");
		
		// ESTO ES SI QUEREMOS SACAR TODOS LOS ELEMENTOS //  
		//Statement statement = connection.createStatement();
		//ResultSet resultSet = statement.executeQuery("select * from articulo");
		
		// CON ESTO VAMOS A PODER PASAR PARAMETROS AL STATEMENT PARA LAS QUERYS //
		PreparedStatement preparedStatement = connection.prepareStatement("select * from articulo where id > ?");
		preparedStatement.setObject(1, Long.parseLong(args[0]));
		ResultSet resultSet = preparedStatement.executeQuery();
		
		
		System.out.printf("%5s %-30s %10s %9s\n", "id", "nombre", "precio", "categoria");
		while (resultSet.next()) {
			System.out.printf("%5s %-30s %10s %9s\n", 
					resultSet.getObject("id"), 
					resultSet.getObject("nombre"),
					resultSet.getObject("precio"),
					resultSet.getObject("categoria")
			);
		}
		//statement.close();
		preparedStatement.close();
		connection.close();
		System.out.println("fin");
	}

}

