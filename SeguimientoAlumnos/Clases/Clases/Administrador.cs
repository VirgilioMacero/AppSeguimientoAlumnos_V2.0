using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Clases
{
    public class Administrador : Persona
    {

        MySqlConnection ConexionDataBase = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=sistema_seguimiento");

        public List<Alumno_Por_Ramo> ListaAlumnos { get; set; }


        public List<Plan_De_Estudio> ListaPlanes_De_Estudio { get; set; }

        public List<Ramo> ListaRamos { get; set;}

        public List<Profesor> ListaProfesores { get; set; }

        public MySqlCommand LeerBaseDeDatos(string sql)
        {

            ConexionDataBase.Open();
            MySqlCommand Consulta = new MySqlCommand();
            Consulta.Connection = ConexionDataBase;
            Consulta.CommandText = (sql);

            return Consulta;

        }

        public Administrador Inicio_SesionAdministrador(string Usuario,string Contrasenia)
        {
            string sql = "SELECT * FROM administrador WHERE administrador.RUT = '"+Usuario+"' and administrador.Contrasenia = '"+Contrasenia+"'";

            MySqlDataReader Leer = LeerBaseDeDatos(sql).ExecuteReader();

            if (Leer.Read())
            {
                var AdministradorAux = new Administrador();
                AdministradorAux.RUT = Leer.GetString(0);
                AdministradorAux.Nombre = Leer.GetString(2);
                AdministradorAux.Correo = Leer.GetString(4);
                AdministradorAux.Telefono = Leer.GetString(5);
                ConexionDataBase.Close();
                Cargar_Planes_De_Estudio();
                AdministradorAux.ListaPlanes_De_Estudio = this.ListaPlanes_De_Estudio;



                return AdministradorAux;

            }
            else
            {
                return null;
            }




        }
        public void Cargar_Planes_De_Estudio()
        {
            string sql = "SELECT * FROM plan_de_estudio";
            var Lista_Planes_De_Estudios = new List<Plan_De_Estudio>();
            MySqlDataReader Leer_Planes_De_Estudio = LeerBaseDeDatos(sql).ExecuteReader();

            while (Leer_Planes_De_Estudio.Read())
            {

                var Plan_EstudioAux = new Plan_De_Estudio();
                Plan_EstudioAux.ID = Leer_Planes_De_Estudio.GetInt32(0);
                Plan_EstudioAux.anio = Leer_Planes_De_Estudio.GetInt32(1);
                Plan_EstudioAux.Cargar_Semestres_Administrador(Plan_EstudioAux.ID);

                Lista_Planes_De_Estudios.Add(Plan_EstudioAux);

            }

            this.ListaPlanes_De_Estudio = Lista_Planes_De_Estudios;

        }
        
        public List<Ramo> CambiarAlumnoDeRamo()
        {
            var ListaRamos = new List<Ramo>();
            var Ramito = new Ramo();

            ListaRamos.Add(Ramito);

            return ListaRamos;

        }

    }
}
