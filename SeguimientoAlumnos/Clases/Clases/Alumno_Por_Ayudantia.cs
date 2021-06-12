using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Clases
{
    public class Alumno_Por_Ayudantia
    {
        MySqlConnection ConexionDataBase = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=sistema_seguimiento");
        public int ID { get; set; }

        public Alumno_Por_Ramo AlumnoInscritoAyudantia { get; set; }

        public MySqlCommand LeerBaseDeDatos(string sql)
        {
            ConexionDataBase.Open();
            MySqlCommand Consulta = new MySqlCommand();
            Consulta.Connection = ConexionDataBase;
            Consulta.CommandText = (sql);

            return Consulta;

        }

        public void Cargar_Alumno_Por_Ayudantia(int IdAlumno)
        {
            ConexionDataBase.Close();
            string query = "SELECT * FROM alumno_por_ramo WHERE alumno_por_ramo.id = "+IdAlumno+"";
            MySqlDataReader LeerAlumnosPorRamo = LeerBaseDeDatos(query).ExecuteReader();

            while (LeerAlumnosPorRamo.Read())
            {
            var AlumnoAux = new Alumno_Por_Ramo();

            AlumnoAux.ID = IdAlumno;
            AlumnoAux.RUTAlumno = LeerAlumnosPorRamo.GetString(1);
            AlumnoAux.Cargar_Nombre_Alumno(AlumnoAux.RUTAlumno);

            this.AlumnoInscritoAyudantia = AlumnoAux;

            }

            this.AlumnoInscritoAyudantia = null;


        }



    }
}
