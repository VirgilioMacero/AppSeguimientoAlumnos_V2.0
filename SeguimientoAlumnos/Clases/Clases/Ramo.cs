using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Clases
{
    public class Ramo
    {
        MySqlConnection ConexionDataBase = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=sistema_seguimiento");

        public int ID { get; set; } //agregue int ID  
        

        public string Nombre { get; set; }

        public string RUTProfesor { get; set; }


        public string Codigo { get; set; }

        public int Seccion { get; set; }


        public List<Alumno_Por_Ramo> ListaAlumnos { get; set; }

        public List<Ayudantia> ListaAyudantias { get; set;}

        public MySqlCommand LeerBaseDeDatos(string sql)
        {
            ConexionDataBase.Open();
            MySqlCommand Consulta = new MySqlCommand();
            Consulta.Connection = ConexionDataBase;
            Consulta.CommandText = (sql);

            return Consulta;

        }

        //#####################Metodo para cargar los Alumnos por Ramo del Profesor o Administrador#############################

        public void Cargar_Alumnos_Por_Ramo(int id)
        {
            ConexionDataBase.Close();
            var ListaAlumnos2 = new List<Alumno_Por_Ramo>();
            string query = "SELECT * FROM alumno_por_ramo, ramo WHERE alumno_por_ramo.id_Ramo = ramo.id and ramo.id = "+id+"";
            MySqlDataReader LeerAlumnosPorRamo = LeerBaseDeDatos(query).ExecuteReader();

            while (LeerAlumnosPorRamo.Read())
            {
                var Alumno1 = new Alumno_Por_Ramo();
                Alumno1.ID = LeerAlumnosPorRamo.GetInt32(0);
                Alumno1.RUTAlumno = LeerAlumnosPorRamo.GetString(1);
                
                 Alumno1.Cargar_Nombre_Alumno(Alumno1.RUTAlumno);
                
                 Alumno1.Cargar_Notas_Por_Alumno(id,Alumno1.ID);
                
                 Alumno1.Cargar_Seguimientos_Por_Alumno(id,Alumno1.ID);

                Alumno1.CargarAyudantiasInscritas(id,Alumno1.ID);

                ListaAlumnos2.Add(Alumno1);

            }

            this.ListaAlumnos = ListaAlumnos2;

        }
        public void Cargar_Ayudantias_Por_Ramo(int IdRamo)
        {
            ConexionDataBase.Close();
            var ListaAyudantias = new List<Ayudantia>();
            string query = "SELECT * FROM ayudantia,ramo WHERE ayudantia.id_Ramo=ramo.id AND ramo.id ="+IdRamo+"";
            MySqlDataReader LeerAyudantiasPorRamo = LeerBaseDeDatos(query).ExecuteReader();

            while (LeerAyudantiasPorRamo.Read())
            {
                if (LeerAyudantiasPorRamo.GetDateTime(3) >= DateTime.Now)
                {

                var AyudantiaAux = new Ayudantia();
                AyudantiaAux.ID = LeerAyudantiasPorRamo.GetInt32(0);
                AyudantiaAux.NombreRamo = LeerAyudantiasPorRamo.GetString(2);
                AyudantiaAux.Fecha = LeerAyudantiasPorRamo.GetDateTime(3);
                
                 AyudantiaAux.Cargar_Alumnos_Por_Ayudantia(AyudantiaAux.ID);
                

                ListaAyudantias.Add(AyudantiaAux);

                }

            }

            this.ListaAyudantias = ListaAyudantias;

        }



    }
}
