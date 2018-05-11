using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListasEnlazadasDoblesAgenda
{
    class Persona

    { 
        public Int32 codigo { get; set; }

    public string nombre { get; set; }

    public string Telefono { get; set; }

    public string Correo { get; set; }

    public string Fecha { get; set; }

    public Persona siguiente { get; set; }

    public Persona anteriror { get; set; }

    public Persona(Int32 codigo, string nombre, string Telefono, string Correo, string Fecha)
    {
        this.codigo = codigo;
        this.nombre = nombre;
        this.Telefono = Telefono;
        this.Correo = Correo;
        this.Fecha = Fecha;
        siguiente = null;
    }

    public override string ToString()
    {
        string per = "Código: " + codigo.ToString() + Environment.NewLine
                   + "Nombre: " + nombre.ToString() + Environment.NewLine
                   + "Telefono: " + Telefono.ToString() + Environment.NewLine
                   + "Correo: " + Correo.ToString() + Environment.NewLine
                   + "Fecha: " + Fecha.ToString() + Environment.NewLine;
        return per;
    }
}
    
}
