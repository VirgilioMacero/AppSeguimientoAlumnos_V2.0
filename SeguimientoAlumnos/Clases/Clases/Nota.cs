using System;
using MySql.Data.MySqlClient;

namespace Clases
{
    public class Nota
    {
        MySqlConnection ConexionDataBase = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=sistema_seguimiento");
        public int ID { get; set; } //agregue int id en nota

        public string NumeroNota { get; set; }

        public double Puntacion { get; set; }

        public DateTime Fecha { get; set; }

        public MySqlCommand LeerBaseDeDatos(string sql)
        {
            ConexionDataBase.Open();
            MySqlCommand Consulta = new MySqlCommand();
            Consulta.Connection = ConexionDataBase;
            Consulta.CommandText = (sql);

            return Consulta;

        }

        public void CambiarNota(int IdNota,string Valor)
        {
            ConexionDataBase.Close();
            ConexionDataBase.Open();
            string query = "UPDATE nota SET Puntuacion = '"+Valor+"' WHERE nota.id = "+IdNota+"";
            MySqlCommand CargarNota = new MySqlCommand(query, ConexionDataBase);

            CargarNota.ExecuteNonQuery();

        }

    }
}
