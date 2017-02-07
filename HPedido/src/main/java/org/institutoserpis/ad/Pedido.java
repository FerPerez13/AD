package org.institutoserpis.ad;

import java.util.Date;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;

@Entity
public class Pedido {

	private long id;
	private long id_cliente;
	private String fecha;
	private double importe;
	
	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	
	public long getId() {return id;}
	public void setId(long id) {this.id = id;}
	
	public long getId_cliente() {return id_cliente;	}
	public void setId_cliente(long id_cliente) {this.id_cliente = id_cliente;}
	
	public String getFecha() {return fecha;}
	public void setFecha(String fecha) {this.fecha = fecha;}
	
	public double getImporte() {return importe;}
	public void setImporte(double importe) {this.importe = importe;} 
	
	
	
}
