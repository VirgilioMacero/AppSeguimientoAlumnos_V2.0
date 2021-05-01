using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguimientoAlumnos
{
    public class Ramo
    {

        public string Nombre { get; set; }

        public string RUTProfesor { get; set; }


        public string Codigo { get; set; }

        public int Seccion { get; set; }

       
        public List<Alumno_Por_Ramo> ListaAlumnos { get; set; }

    }
}
