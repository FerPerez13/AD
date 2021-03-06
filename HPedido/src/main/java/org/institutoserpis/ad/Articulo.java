package org.institutoserpis.ad;

import javax.persistence.GeneratedValue;
import javax.persistence.Entity;
import javax.persistence.GenerationType;
import javax.persistence.Id;



@Entity
public class Articulo {
	private long id;
	private String nombre;
	private double precio;
	private long categoria;
	
	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	
	public long getId() {return id;}
	public String getNombre() {return nombre;}
	public double getPrecio() {return precio;}
	public long getCategoria() {return categoria;}
	
	public void setId(long id) { this.id=id;}
	public void setNombre(String nombre) {this.nombre=nombre;}
	public void setPrecio(double precio) {this.precio=precio;}
	public void setCategoria(long categoria) {this.categoria=categoria;}
	
}
