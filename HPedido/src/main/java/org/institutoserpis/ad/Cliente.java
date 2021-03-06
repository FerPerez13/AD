package org.institutoserpis.ad;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;

@Entity
public class Cliente {
	private long id;
	private String nombre;
	
	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	
	public long getId() {return id;}
	public String getNombre() {return nombre;}
	
	public void setId(long id) { this.id=id;}
	public void setNombre(String nombre) {this.nombre=nombre;}
}
