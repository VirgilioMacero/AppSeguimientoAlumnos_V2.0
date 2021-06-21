using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Clases
{
    public class Plan_De_Estudio
    {
        MySqlConnection ConexionDataBase = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=sistema_seguimiento");
        public int ID { get; set; } //se arreglo ID en int 

        public int anio { get; set; }

        public List<Semestre> ListaSemestre { get; set; }

        public MySqlCommand LeerBaseDeDatos(string sql)
        {
            ConexionDataBase.Open();
            MySqlCommand Consulta = new MySqlCommand();
            Consulta.Connection = ConexionDataBase;
            Consulta.CommandText = (sql);

            return Consulta;

        }

        public void Cargar_Semestres_Alumno(int id , string Rut)
        {

            ConexionDataBase.Close();
            var ListaSemestres = new List<Semestre>();
            string query = "SELECT * FROM semestre,plan_de_estudio WHERE semestre.Id_Plan_De_Estudio = plan_de_estudio.id and plan_de_estudio.id = "+ id +"";
            MySqlDataReader LeerSemestres = LeerBaseDeDatos(query).ExecuteReader();

            while (LeerSemestres.Read())
            {

                var SemestreAux = new Semestre();

                SemestreAux.ID = LeerSemestres.GetInt32(0);
                SemestreAux.Numero = LeerSemestres.GetInt32(2);

                SemestreAux.Cargar_Ramos_Alumno(Rut);

                ListaSemestres.Add(SemestreAux);
                
            }

            this.ListaSemestre = ListaSemestres;


        }
        public void Cargar_Semestres_Administrador(int idPlan_Estudio)
        {
            ConexionDataBase.Close();
            var ListaSemestres = new List<Semestre>();
            string query = "SELECT * FROM semestre,plan_de_estudio WHERE semestre.Id_Plan_De_Estudio = plan_de_estudio.id AND plan_de_estudio.id ="+idPlan_Estudio+"";
            MySqlDataReader LeerSemestres_Administrador = LeerBaseDeDatos(query).ExecuteReader();

            while (LeerSemestres_Administrador.Read())
            {
                var SemestreAux = new Semestre();

                SemestreAux.ID = LeerSemestres_Administrador.GetInt32(0);
                SemestreAux.Numero = LeerSemestres_Administrador.GetInt32(2);
                SemestreAux.Cargar_Ramos_Administrador(SemestreAux.ID);

                ListaSemestres.Add(SemestreAux);

            }

            this.ListaSemestre = ListaSemestres;

        }

    }
}
