package Org.InstitutoSerpis.Ad;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.Scanner;

import javax.swing.text.html.HTMLDocument.HTMLReader.ParagraphAction;

public class GArticulo {
	
	private static Scanner scanner = new Scanner(System.in);
	private static Connection connection;
				
	public static void main(String args[]) throws SQLException{
		System.out.println("Bienvenido a GArticulo con JDBC");
		
		connection = DriverManager.getConnection("jdbc:mysql://localhost/dbprueba", "root", "sistemas");
		
		try {
			int sel = menu();
			while (sel != 0) {
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
			System.out.println("¡Hasta luego!");
			connection.close();		
			
		} catch (Exception e) {
			System.err.println(e.getMessage());
			connection.close();
		}
	}
	
	private static int menu(){
		System.out.println("");
		System.out.println("**********************************************************");
		System.out.println("***                  MENÚ PRINCIPAL                    ***");
		System.out.println("**********************************************************");
		System.out.println("");
		System.out.println("	0 - Salir");
		System.out.println("	1 - Nuevo");
		System.out.println("	2 - Modificar");
		System.out.println("	3 - Eliminar");
		System.out.println("	4 - Consultar");
		System.out.println("	5 - Listar todos");
		System.out.println("");
		System.out.print("¿Que desea hacer?...");
		int sel = Integer.parseInt(scanner.nextLine());
		return sel;
	}
	
	private static void nuevo() throws SQLException {
		System.out.println("");
		System.out.println("********************* NUEVO ARTICULO *********************");
		System.out.println("");
		
		scanner.nextLine(); //LIMPIAMOS EL BUFFER
		
		System.out.print("Introduzca el nombre del articulo: ");
		String nombre = scanner.nextLine();
		System.out.print("Introduzca el precio del articulo: ");
		double precio = Double.parseDouble(scanner.nextLine());
		System.out.print("Introduzca la categoria del articulo: ");
		int categoria = Integer.parseInt(scanner.nextLine());
		
		PreparedStatement preparedStatement = connection.prepareStatement("INSERT INTO articulo (nombre,precio,categoria) VALUES (?,?,?)");
		preparedStatement.setObject(1, nombre);		
		preparedStatement.setObject(2, precio);
		preparedStatement.setObject(3, categoria);
		preparedStatement.executeUpdate();
		preparedStatement.close();
		
		System.out.println("");
		System.out.println("Articulo guardado correctamente");
		System.out.println("");
	}
	
	private static void modificar() throws SQLException {
		//TODO: UPDATE 
		System.out.println("");
		System.out.println("********************* MODIFICAR *********************");
		System.out.println("");
		
		System.out.print("¿Que ID quieres modificar?: ");
		int id = Integer.parseInt(scanner.nextLine());
		System.out.println("");
		
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
		preparedStatement.close();
		System.out.println("");
		
		//AHORA MODIFICAMOS LOS VALORES (PREGUNTAMOS QUE ES LO QUE QUIERE MODIFICAR)
		int sel2 = 9; //Lo iniciamos en un numero alto para que entre dentro del bucle. 
		while(sel2!=0){
			System.out.println("");
			System.out.println("¿Que desea modificar?");
			System.out.println("0 - Nada");
			System.out.println("1 - Nombre");
			System.out.println("2 - Precio");
			System.out.println("3 - Categoria");
			System.out.println("");
			System.out.print("Seleccione una opción: ");
			sel2 = Integer.parseInt(scanner.nextLine());
		
			switch (sel2) {
				case 0:
					break;
				case 1: 
					System.out.print("Introduzca el nuevo nombre del articulo: ");
					String nombre = scanner.nextLine();
					
					preparedStatement = connection.prepareStatement("UPDATE articulo SET nombre = ? WHERE id = ?;");
					preparedStatement.setObject(1, nombre);		
					preparedStatement.setObject(2, id);
					preparedStatement.executeUpdate();
					preparedStatement.close();
					
					System.out.println("");
					System.out.println("Articulo modificado correctamente");
					System.out.println("");
					break;
				case 2:
					System.out.print("Introduzca el nuevo precio del articulo: ");
					double precio = Double.parseDouble(scanner.nextLine());
					
					preparedStatement = connection.prepareStatement("UPDATE articulo SET precio = ? WHERE id = ?;");
					preparedStatement.setObject(1, precio);		
					preparedStatement.setObject(2, id);
					preparedStatement.executeUpdate();
					preparedStatement.close();
					
					System.out.println("");
					System.out.println("Articulo modificado correctamente");
					System.out.println("");
					
					break;
				case 3:
					System.out.print("Introduzca la nueva categoria del articulo: ");
					int categoria = Integer.parseInt(scanner.nextLine());
					
					preparedStatement = connection.prepareStatement("UPDATE articulo SET categoria = ? WHERE id = ?;");
					preparedStatement.setObject(1, categoria);		
					preparedStatement.setObject(2, id);
					preparedStatement.executeUpdate();
					preparedStatement.close();
					
					System.out.println("");
					System.out.println("Articulo modificado correctamente");
					System.out.println("");
					break;
			}
		}
	}
	
	private static void eliminar() throws SQLException {
		System.out.println("");
		System.out.println("********************* ELIMINAR *********************");
		System.out.println("");
		
		System.out.print("¿Que ID quieres eliminar?: ");
		int id = Integer.parseInt(scanner.nextLine());
		
		PreparedStatement preparedStatement = connection.prepareStatement("DELETE FROM articulo WHERE id=?");
		preparedStatement.setObject(1, id);
		preparedStatement.executeUpdate();
		preparedStatement.close();
		
		System.out.println("");
		System.out.println("Articulo eliminado correctamente");
		System.out.println("");
		
	}
	
	private static void consultar() throws SQLException{
		System.out.println("");
		System.out.println("********************* CONSULTAR *********************");
		System.out.println("");

		System.out.print("¿Que ID quieres consultar?: ");
		int id = Integer.parseInt(scanner.nextLine());
		System.out.println("");
		
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
		System.out.println("");
		System.out.println("********************* LISTAR TODOS *********************");
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