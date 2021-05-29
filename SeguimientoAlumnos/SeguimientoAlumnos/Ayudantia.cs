using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguimientoAlumnos
{
    public class Ayudantia
    {

        public int ID { get; set; }

        public DateTime Fecha { get; set; }

        public List<Alumno_Por_Ayudantia> ListaAlumnoPorAyudantia { get; set; }


    }
}
