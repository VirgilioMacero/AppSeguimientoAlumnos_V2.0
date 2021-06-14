using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Mensaje //Se creo la clase Mensaje

    {

        //Se agrego estos atributos 
        MySqlConnection ConexionDataBase = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=sistema_seguimiento");
        public int ID { get; set; } 

        public string Remitente { get; set; }

        public string Destinatario { get; set; }

        public string Titulo { get; set; }

        public string Cuerpo { get; set; }

        public DateTime Fecha { get; set; }

        public bool Leido { get; set; }

        public MySqlCommand LeerBaseDeDatos(string sql)
        {
            ConexionDataBase.Open();
            MySqlCommand Consulta = new MySqlCommand();
            Consulta.Connection = ConexionDataBase;
            Consulta.CommandText = (sql);

            return Consulta;

        }

        public void SeLeyo(int Id)
        {
            ConexionDataBase.Close();
            ConexionDataBase.Open();
            string query = "UPDATE mensaje SET Leido = 1 WHERE mensaje.id ="+Id+"";
            MySqlCommand CargarSeLeyo = new MySqlCommand(query, ConexionDataBase);

            CargarSeLeyo.ExecuteNonQuery();


        }

    }

    



}
