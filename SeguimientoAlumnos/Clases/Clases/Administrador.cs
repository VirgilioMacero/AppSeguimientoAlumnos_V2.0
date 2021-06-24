using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Clases
{
    public class Administrador : Persona
    {

        MySqlConnection ConexionDataBase = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=sistema_seguimiento");

        public List<Alumno> ListaAlumnos { get; set; }

        public List<Profesor> ListaProfesores { get; set; }

        public List<Plan_De_Estudio> ListaPlanes_De_Estudio { get; set; }


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
                CargarMensajes(AdministradorAux.Correo);
                AdministradorAux.Mensajes = this.Mensajes;
                ConexionDataBase.Close();
                Cargar_Planes_De_Estudio();
                AdministradorAux.ListaPlanes_De_Estudio = this.ListaPlanes_De_Estudio;
                ConexionDataBase.Close();
                Cargar_Alumnos();
                AdministradorAux.ListaAlumnos = this.ListaAlumnos;
                ConexionDataBase.Close();
                Cargar_Profesores();
                AdministradorAux.ListaProfesores = this.ListaProfesores;



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
        
        public void Cargar_Alumnos()
        {
            string sql = "SELECT * FROM alumno";
            var Lista_AlumnosAux = new List<Alumno>();
            MySqlDataReader Leer_Alumnos = LeerBaseDeDatos(sql).ExecuteReader();

            while (Leer_Alumnos.Read())
            {

                var AlumnoAux = new Alumno();

                AlumnoAux.RUT = Leer_Alumnos.GetString(0);
                AlumnoAux.Correo = Leer_Alumnos.GetString(1);
                AlumnoAux.Nombre = Leer_Alumnos.GetString(2);
                AlumnoAux.Telefono = Leer_Alumnos.GetString(4);
                AlumnoAux.CargarListaRamos(AlumnoAux.RUT);

                Lista_AlumnosAux.Add(AlumnoAux);

            }

            this.ListaAlumnos = Lista_AlumnosAux;

        }
        public void Cargar_Profesores()
        {
            string sql = "SELECT * FROM profesor";
            var Lista_ProfesoresAux = new List<Profesor>();
            MySqlDataReader Leer_Profesores = LeerBaseDeDatos(sql).ExecuteReader();

            while (Leer_Profesores.Read())
            {

                var ProfesorAux = new Profesor();
                ProfesorAux.RUT = Leer_Profesores.GetString(0);
                ProfesorAux.Nombre = Leer_Profesores.GetString(2);
                ProfesorAux.Correo = Leer_Profesores.GetString(3);
                ProfesorAux.Telefono = Leer_Profesores.GetString(5);
                ProfesorAux.Cargar_Ramos_Profesor(ProfesorAux.RUT);

                Lista_ProfesoresAux.Add(ProfesorAux);

            }

            this.ListaProfesores = Lista_ProfesoresAux;


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
