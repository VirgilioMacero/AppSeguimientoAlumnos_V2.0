using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Seguimiento  //agregue la clase seguimiento
    {
        MySqlConnection ConexionDataBase = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=sistema_seguimiento");
        public string Causa { get; set; }   //agregue string causa

        public int ID { get; set; } //agregue int ID

        public string Mensaje { get; set; } //agregue string Mensaje

        public DateTime Fecha { get; set; }

        public MySqlCommand LeerBaseDeDatos(string sql)
        {
            ConexionDataBase.Open();
            MySqlCommand Consulta = new MySqlCommand();
            Consulta.Connection = ConexionDataBase;
            Consulta.CommandText = (sql);

            return Consulta;

        }

        public void SubirSeguimiento(int Id)
        {
            ConexionDataBase.Close();
            ConexionDataBase.Open();
            try
            {
            string query = "INSERT INTO seguimiento (id, Id_Alumno_Por_Ramo, Causa, Mensaje, Fecha) VALUES (NULL, "+Id+", '"+this.Causa+"', '"+this.Mensaje+"','"+this.Fecha.ToString("u")+"');";

            MySqlCommand CargarSeguimiento = new MySqlCommand(query,ConexionDataBase);

            CargarSeguimiento.ExecuteNonQuery();

                

            }
            catch (Exception)
            {

                throw;
            }

            ConexionDataBase.Close();

        }



    }
}
