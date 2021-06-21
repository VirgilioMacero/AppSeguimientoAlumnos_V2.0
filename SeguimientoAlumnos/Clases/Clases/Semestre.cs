using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Clases
{
    public class Semestre
    {
        MySqlConnection ConexionDataBase = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=sistema_seguimiento");
        public int ID { get; set; } //Se agrego int ID

        public int Numero { get; set; }

        public List<Ramo> ListaRamos { get; set; }

        public MySqlCommand LeerBaseDeDatos(string sql)
        {
            ConexionDataBase.Open();
            MySqlCommand Consulta = new MySqlCommand();
            Consulta.Connection = ConexionDataBase;
            Consulta.CommandText = (sql);

            return Consulta;

        }

        public void Cargar_Ramos_Alumno(string Rut)
        {
            ConexionDataBase.Close();
            var ListaRamos = new List<Ramo>();

            string query = "SELECT * FROM ramo,semestre,alumno_por_ramo WHERE ramo.id_Semestre = semestre.id AND alumno_por_ramo.id_Ramo = ramo.id AND alumno_por_ramo.RUT_Alumno = '" + Rut + "'";
            MySqlDataReader LeerRamosPorSemestre = LeerBaseDeDatos(query).ExecuteReader();

            while (LeerRamosPorSemestre.Read())
            {

                var RamoAux = new Ramo();
                RamoAux.ID = LeerRamosPorSemestre.GetInt32(0);
                RamoAux.CargarRutProfesor(RamoAux.ID);
                RamoAux.Nombre = LeerRamosPorSemestre.GetString(3);
                RamoAux.Codigo = LeerRamosPorSemestre.GetString(4);
                RamoAux.Seccion = LeerRamosPorSemestre.GetInt32(5);

                ListaRamos.Add(RamoAux);

            }

            this.ListaRamos = ListaRamos;


        }
        public void Cargar_Ramos_Administrador(int IdSemestre)
        {

            ConexionDataBase.Close();
            var ListaRamos = new List<Ramo>();

            string query = "SELECT * FROM ramo,semestre WHERE ramo.id_Semestre = semestre.id AND semestre.id = "+IdSemestre+"";
            MySqlDataReader LeerRamosPorSemestre = LeerBaseDeDatos(query).ExecuteReader();

            while (LeerRamosPorSemestre.Read())
            {

                var RamoAux = new Ramo();
                RamoAux.ID = LeerRamosPorSemestre.GetInt32(0);
                RamoAux.CargarRutProfesor(RamoAux.ID);
                RamoAux.Nombre = LeerRamosPorSemestre.GetString(2);
                RamoAux.Codigo = LeerRamosPorSemestre.GetString(3);
                RamoAux.Seccion = LeerRamosPorSemestre.GetInt32(4);
                RamoAux.Cargar_Alumnos_Por_Ramo(RamoAux.ID);
                RamoAux.Cargar_Ayudantias_Por_Ramo(RamoAux.ID);

                ListaRamos.Add(RamoAux);

            }

            this.ListaRamos = ListaRamos;



        }



    }
}
