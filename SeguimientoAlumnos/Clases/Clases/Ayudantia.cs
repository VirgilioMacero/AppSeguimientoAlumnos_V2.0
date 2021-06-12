using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Ayudantia
    {
        MySqlConnection ConexionDataBase = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=sistema_seguimiento");
        public int ID { get; set; }

        public DateTime Fecha { get; set; }

        public string NombreRamo { get; set;}

        public List<Alumno_Por_Ayudantia> ListaAlumnoPorAyudantia { get; set; }

        public MySqlCommand LeerBaseDeDatos(string sql)
        {
            ConexionDataBase.Open();
            MySqlCommand Consulta = new MySqlCommand();
            Consulta.Connection = ConexionDataBase;
            Consulta.CommandText = (sql);

            return Consulta;

        }

        public List<Alumno_Por_Ayudantia> Cargar_Alumnos_Por_Ayudantia(int IdAyudantia)
        {
            ConexionDataBase.Close();
            var ListaAlumnosAyudantia = new List<Alumno_Por_Ayudantia>();
            string query = "SELECT * FROM alumno_por_ayudantia,ayudantia WHERE alumno_por_ayudantia.id_ayudantia = ayudantia.id AND ayudantia.id = "+IdAyudantia+"";
            MySqlDataReader LeerAlumnosPorAyudantias = LeerBaseDeDatos(query).ExecuteReader();

            if (LeerAlumnosPorAyudantias.HasRows)
            {
            while (LeerAlumnosPorAyudantias.Read())
            {
                var AlumnoPorAyudantia = new Alumno_Por_Ayudantia();

                AlumnoPorAyudantia.ID = LeerAlumnosPorAyudantias.GetInt32(0);
                
                int IdAlumno = LeerAlumnosPorAyudantias.GetInt32(2);
                AlumnoPorAyudantia.AlumnoInscritoAyudantia = AlumnoPorAyudantia.Cargar_Alumno_Por_Ayudantia(IdAlumno);
                

                ListaAlumnosAyudantia.Add(AlumnoPorAyudantia);

            }
            }

            return ListaAlumnosAyudantia;


        }


    }
}
