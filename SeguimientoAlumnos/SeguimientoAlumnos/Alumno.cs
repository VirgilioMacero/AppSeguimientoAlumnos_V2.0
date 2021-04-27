using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguimientoAlumnos
{
    public class Alumno : Persona
    {

        public List<Plan_De_Estudio> ListaPlan_De_Estudio { get; set; }


        public Alumno()
        {

             new Alumno();

           
        }

        public Alumno(Alumno alumnito)
        {

            this.Nombre = alumnito.Nombre;
            this.Correo = alumnito.Correo;
            this.RUT = alumnito.RUT;
            this.ListaPlan_De_Estudio = alumnito.ListaPlan_De_Estudio;
            

        }


    }
}
