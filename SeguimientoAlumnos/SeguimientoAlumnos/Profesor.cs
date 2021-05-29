using System.Collections.Generic;

namespace SeguimientoAlumnos
{
    public class Profesor : Persona
    {

        public List<Ramo> ListaRamosDados { get; set; }


        public Profesor()
        {

            var ListaRamos = new List<Ramo>();

            this.Nombre = "";
            this.RUT = "";
            this.Correo = "";
            this.ListaRamosDados = ListaRamos;


        }
        public Profesor(Profesor Profe)
        {

            this.ListaRamosDados = Profe.ListaRamosDados;
            this.Nombre = Profe.Nombre;
            this.RUT = Profe.RUT;
            this.Correo = Profe.Correo;
            this.Clave = Profe.Clave;

            


        }


        public Nota IngresarNotaAlumno()
        {


            var Notita = new Nota();

            return Notita;
        }


    }
}
