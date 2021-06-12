using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace Clases
{
    public class Alumno : Persona
    {
        MySqlConnection ConexionDataBase = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=sistema_seguimiento");
        public List<Plan_De_Estudio> ListaPlan_De_Estudio { get; set; }
        public List<Ramo> ListaRamos {get; set;}


        public Alumno()
        {

            this.Nombre = "";
            this.ListaPlan_De_Estudio = new List<Plan_De_Estudio>();
            this.Correo = "";
            this.RUT = "";
            this.ListaRamos = new List<Ramo>();
        }

        public Alumno(Alumno alumnito)
        {

            this.Nombre = alumnito.Nombre;
            this.Correo = alumnito.Correo;
            this.RUT = alumnito.RUT;
            this.ListaPlan_De_Estudio = alumnito.ListaPlan_De_Estudio;
            this.ListaRamos = alumnito.ListaRamos;


        }
        public MySqlCommand LeerBaseDeDatos(string sql)
        {
            ConexionDataBase.Open();
            MySqlCommand Consulta = new MySqlCommand();
            Consulta.Connection = ConexionDataBase;
            Consulta.CommandText = (sql);

            return Consulta;

        }

        public Alumno Inicio_Sesion_Alumno(string sql)
        {


            MySqlDataReader Leer = LeerBaseDeDatos(sql).ExecuteReader();

            if (Leer.Read())
            {

                var Alumnito2 = new Alumno();

                Alumnito2.Nombre = Leer.GetString(2);
                Alumnito2.Correo = Leer.GetString(1);
                Alumnito2.RUT = Leer.GetString(0);
                Alumnito2.Clave = Leer.GetString(3);
                Alumnito2.Telefono = Leer.GetString(4);
                Cargar_Plan_De_Estudio_Alumno(Alumnito2.RUT);
                return Alumnito2;

            }

            ConexionDataBase.Close();


            return null;

        }

        public void Cargar_Plan_De_Estudio_Alumno(string Rut)
        {

            ConexionDataBase.Close();

            var ListaDePlanes = new List<Plan_De_Estudio>();

            string query = "SELECT * FROM plan_de_estudio,alumno WHERE plan_de_estudio.RUT_Alumno = alumno.RUT AND plan_de_estudio.RUT_Alumno = '"+Rut+"'";
            MySqlDataReader LeerPlanesDeEstudio = LeerBaseDeDatos(query).ExecuteReader();

            while (LeerPlanesDeEstudio.Read())
            {
                var PlanAux = new Plan_De_Estudio();
                PlanAux.ID = LeerPlanesDeEstudio.GetInt32(0);
                PlanAux.anio = LeerPlanesDeEstudio.GetInt32(1);
                PlanAux.Cargar_Semestres(PlanAux.ID,Rut);

                ListaDePlanes.Add(PlanAux);

            }

            this.ListaPlan_De_Estudio = ListaDePlanes;

        }
    }
}
