using System.Collections.Generic;
using System;

namespace Clases
{
    public class Alumno : Persona
    {

        public List<Plan_De_Estudio> ListaPlan_De_Estudio { get; set; }


        public Alumno()
        {

            this.Nombre = "";
            this.ListaPlan_De_Estudio = new List<Plan_De_Estudio>();
            this.Correo = "";
            this.RUT = "";

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
