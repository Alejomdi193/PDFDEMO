using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class Producto : BaseEntity
    {
    public  string NombreProducto {get; set;}
    public double Precio {get; set;}
    public int Cantidad {get; set;}
    public string Codigo {get; set;}
    public int CantidadMin {get; set;}
    public int CantidadMax {get; set;}
    public int IdMarcaFk {get; set;}
    public Marca Marca{get; set;}
    public string Descripcion {get; set;}
    }
}