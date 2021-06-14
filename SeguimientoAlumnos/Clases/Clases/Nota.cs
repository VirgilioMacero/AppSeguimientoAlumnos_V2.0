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

        public void SubirNota(int AlumnoId , string NumeroNota,string PuntuacionAux,DateTime Fecha2)
        {
            ConexionDataBase.Close();
            ConexionDataBase.Open();
            string query = "INSERT INTO nota (id, Id_Alumno_Por_Ramo, NumeroNota, Puntuacion, Fecha) VALUES (NULL, " + AlumnoId + ", '" + NumeroNota + "', '" + PuntuacionAux + "', '" + Fecha2.ToString("u") + "')";
            MySqlCommand SubirNota = new MySqlCommand(query, ConexionDataBase);

            SubirNota.ExecuteNonQuery();

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
