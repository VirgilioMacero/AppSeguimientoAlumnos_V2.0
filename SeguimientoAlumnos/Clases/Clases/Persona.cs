using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Clases

{
    public class Persona
    {

        MySqlConnection ConexionDataBase = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=sistema_seguimiento");

        public string Nombre { get; set; }

        public string RUT { get; set; }

        public string Clave { get; set; }

        public string Correo { get; set; }

        public string Telefono { get; set; }

        public List<Mensaje> Mensajes { get; set; } //se creo la lista de mensajes 

        public MySqlCommand LeerBaseDeDatos(string sql)
        {
            ConexionDataBase.Open();
            MySqlCommand Consulta = new MySqlCommand();
            Consulta.Connection = ConexionDataBase;
            Consulta.CommandText = (sql);

            return Consulta;

        }

        public void EnviarMensaje(string Remitente,string Destinatario,string Titulo,string Cuerpo,DateTime Fecha,bool Leido)
        {

            ConexionDataBase.Close();
            ConexionDataBase.Open();
            
            string query = "INSERT INTO `mensaje` (`id`, `Remitente`, `Destinatario`, `Titulo`, `Cuerpo`, `Fecha`, `Leido`) VALUES (NULL, '"+Remitente+"', '"+Destinatario+"', '"+Titulo+"', '"+Cuerpo+"', '"+Fecha.ToString("u")+"', "+Leido+");";
            MySqlCommand CargarMensaje = new MySqlCommand(query, ConexionDataBase);

            CargarMensaje.ExecuteNonQuery();




        }

        public void CargarMensajes(string Destinatario)
        {
            ConexionDataBase.Close();
            var ListaMensajes = new List<Mensaje>();
            string query = "SELECT * FROM mensaje WHERE mensaje.Destinatario = '"+Destinatario+"'";
            MySqlDataReader LeerMensajes = LeerBaseDeDatos(query).ExecuteReader();

            while (LeerMensajes.Read())
            {
                var MensajeAux = new Mensaje();
                MensajeAux.ID = LeerMensajes.GetInt32(0);
                MensajeAux.Remitente = LeerMensajes.GetString(1);
                MensajeAux.Destinatario = LeerMensajes.GetString(2);
                MensajeAux.Titulo = LeerMensajes.GetString(3);
                MensajeAux.Cuerpo = LeerMensajes.GetString(4);
                MensajeAux.Fecha = LeerMensajes.GetDateTime(5);
                MensajeAux.Leido = LeerMensajes.GetBoolean(6);

                ListaMensajes.Add(MensajeAux);


            }

            this.Mensajes = ListaMensajes;

        }


    }
}
