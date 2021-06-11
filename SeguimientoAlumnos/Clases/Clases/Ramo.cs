using System.Collections.Generic;

namespace Clases
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






    }
}
