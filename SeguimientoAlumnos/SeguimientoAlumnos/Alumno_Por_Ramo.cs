using System.Collections.Generic;

namespace SeguimientoAlumnos
{
    public class Alumno_Por_Ramo
    {

        public int ID { get; set; } //agregue int ID


        public string Nombre { get; set; }
        public string RUTAlumno { get; set; }

        public List<Nota> ListaNotas { get; set; }


        public List<Seguimiento> Seguimientos { get; set; } //se agrego List Seguimiento

    }
}
