using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguimientoAlumnos
{
    public class Mensaje //Se creo la clase Mensaje

    {

        //Se agrego estos atributos 

        public int ID { get; set; } 

        public string Remitente { get; set; }

        public string Destinatario { get; set; }

        public string Titulo { get; set; }

        public string Cuerpo { get; set; }

        public bool Leido { get; set; }

    }
}
