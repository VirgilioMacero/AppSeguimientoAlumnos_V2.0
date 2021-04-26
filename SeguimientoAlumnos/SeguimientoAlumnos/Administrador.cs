using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguimientoAlumnos
{
    public class Administrador : Persona
    {

        public List<Alumno> ListaAlumnos { get; set; }

        public List<Plan_De_Estudio> ListaPlanes_De_Estudio { get; set; }


        public List<Ramo> CambiarAlumnoDeRamo()
        {
            var ListaRamos = new List<Ramo>();
            var Ramito = new Ramo();

            ListaRamos.Add(Ramito);

            return ListaRamos;

        }

    }
}
