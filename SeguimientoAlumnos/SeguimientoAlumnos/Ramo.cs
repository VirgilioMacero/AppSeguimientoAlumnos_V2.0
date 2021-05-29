using System.Collections.Generic;

namespace SeguimientoAlumnos
{
    public class Ramo
    {
        public int ID { get; set; } //agregue int ID  
        

        public string Nombre { get; set; }

        public string RUTProfesor { get; set; }


        public string Codigo { get; set; }

        public int Seccion { get; set; }


        public List<Alumno_Por_Ramo> ListaAlumnos { get; set; }

        public List<Ayudantia> ListaAyudantias { get; set;}

        public int SacarPromedio(Alumno_Por_Ramo Ramo) //se agrego SacarPromedio Alumno Por Ramo
        {
            int numero = 0;


            return numero;
        }




    }
}
