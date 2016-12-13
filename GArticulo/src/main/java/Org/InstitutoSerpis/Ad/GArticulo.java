package Org.InstitutoSerpis.Ad;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.Scanner;

public class GArticulo {
	
	private static Scanner scanner = new Scanner(System.in);
	private static Connection connection;
				
	public static void main(String args[]) throws SQLException{
		System.out.println("Bienvenido a GArticulo con JDBC");
		
		connection = DriverManager.getConnection("jdbc:mysql://localhost/dbprueba", "root", "sistemas");

		int sel = menu();
		while(sel!=0){
			switch (sel) {
			case 0:
				connection.close();
				break;
			case 1:
				nuevo();
				break;
			case 2:
				modificar();
				break;
			case 3:
				eliminar();
				break;
			case 4:
				consultar();				
				break;
			case 5:
				listar();				
				break;
			}
			sel = menu();
		}
	}
	
	private static int menu(){
		System.out.println("");
		System.out.println("	0 - Salir");
		System.out.println("	1 - Nuevo");
		System.out.println("	2 - Modificar");
		System.out.println("	3 - Eliminar");
		System.out.println("	4 - Consultar");
		System.out.println("	5 - Listar todos");
		System.out.println("");
		System.out.print("¿Que desea hacer?...");
		int sel = scanner.nextInt();
		return sel;
	}
	
	private static void nuevo() {
		//TODO: INSERT
		System.out.println("Ha seleccionado: Nuevo");
		System.out.println("");
	}
	
	private static void modificar() {
		//TODO: UPDATE 
		System.out.println("Ha seleccionado: Modificar");
		System.out.println("");
	}
	
	private static void eliminar() {
		//TODO: DELETE .... FROM ... 
		System.out.println("Ha seleccionado: Eliminar");
		System.out.println("");

	}
	
	private static void consultar() throws SQLException{
		System.out.println("Ha seleccionado: Consultar");
		System.out.println("");
		System.out.print("¿Que ID quieres consultar?: ");
		int id = scanner.nextInt();
		PreparedStatement preparedStatement = connection.prepareStatement("SELECT * FROM articulo WHERE id=?");
		preparedStatement.setObject(1, id);
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
		System.out.println(""); //LINEA EN BLANCO POR ESTETICA
		preparedStatement.close();
	}
	
	private static void listar() throws SQLException {
		System.out.println("Ha seleccionado: Listar todos");
		System.out.println("");
		PreparedStatement preparedStatement = connection.prepareStatement("SELECT * FROM articulo");
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
		System.out.println(""); //LINEA EN BLANCO POR ESTETICA
		preparedStatement.close();
	}
}