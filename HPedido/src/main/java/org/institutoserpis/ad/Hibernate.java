package org.institutoserpis.ad;

import java.awt.Menu;
import java.util.Scanner;

public class Hibernate {
	
	static Scanner scanner = new Scanner(System.in);
	
	public static void main(String[] args){
		
		int sel = menu();

		do {
			System.out.println(sel);
			sel = menu();
		} while (sel!=0);


	}
	
	public static int menu(){
		
		System.out.println();
		System.out.println("*** Menu Hibernate ***");
		System.out.println();
		System.out.println("1. Nuevo");
		System.out.println("2. Editar");
		System.out.println("3. Eliminar");
		System.out.println("4. Mostrar datos");
		System.out.println("0. Salir");
		System.out.println();
		System.out.print("Seleccione una opción: ");
		
		int select = scanner.nextInt();	
		scanner.nextLine();
		
		return select;
	}

}
