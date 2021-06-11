using System.Collections.Generic;

namespace Clases

{
    public class Persona
    {
        public string Nombre { get; set; }

        public string RUT { get; set; }

        public string Clave { get; set; }

        public string Correo { get; set; }

        public string Telefono { get; set; }

        public List<Mensaje> Mensajes { get; set; } //se creo la lista de mensajes 


        public void EnviarMensaje()
        {



        }

        public void MostrarMensaje()
        {



        }


    }
}
