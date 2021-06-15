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
                Alumnito2.ListaRamos = CargarListaRamos(Alumnito2.RUT);
                Alumnito2.CargarMensajes(Alumnito2.Correo);

                return Alumnito2;

            }

            ConexionDataBase.Close();


            return null;

        }

        public void Cargar_Plan_De_Estudio_Alumno(string Rut)
        {

            ConexionDataBase.Close();

            var ListaDePlanes = new List<Plan_De_Estudio>();

            string query = "SELECT * FROM plan_de_estudio,alumno_por_plan_de_estudio,alumno WHERE alumno.RUT=alumno_por_plan_de_estudio.RUT_Alumno AND plan_de_estudio.id = alumno_por_plan_de_estudio.Id_Plan_Estudio AND alumno.RUT='"+Rut+"'";
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
        public List<Ramo> CargarListaRamos(string RUTAux)
        {
            ConexionDataBase.Close();
            var ListaDeRamos = new List<Ramo>();
            string query = "SELECT * FROM ramo,alumno_por_ramo,alumno WHERE ramo.id=alumno_por_ramo.id_Ramo AND alumno_por_ramo.RUT_Alumno = alumno.RUT AND alumno_por_ramo.RUT_Alumno='" + RUTAux + "'";
            MySqlDataReader LeerRamosPorAlumno = LeerBaseDeDatos(query).ExecuteReader();
            while (LeerRamosPorAlumno.Read())
            {
                var RamoAux = new Ramo();

                RamoAux.ID = LeerRamosPorAlumno.GetInt32(0);
                RamoAux.Nombre = LeerRamosPorAlumno.GetString(2);
                RamoAux.Codigo = LeerRamosPorAlumno.GetString(3);
                RamoAux.Seccion = LeerRamosPorAlumno.GetInt32(4);


                ListaDeRamos.Add(RamoAux);
            }

            return ListaDeRamos;

        }
        public List<Nota> CargarNotas(int IdRamo)
        {
            ConexionDataBase.Close();
            var ListaDeNotas = new List<Nota>();
            string query = "SELECT * FROM nota,ramo,alumno_por_ramo WHERE alumno_por_ramo.id_Ramo = ramo.id AND alumno_por_ramo.id = nota.Id_Alumno_Por_Ramo AND alumno_por_ramo.RUT_Alumno ='"+this.RUT+"' AND ramo.id = "+IdRamo+"";
            MySqlDataReader LeerNotasDeAlumno = LeerBaseDeDatos(query).ExecuteReader();

            while (LeerNotasDeAlumno.Read())
            {

                var NotaAux = new Nota();
                NotaAux.ID = LeerNotasDeAlumno.GetInt32(0);
                NotaAux.NumeroNota = LeerNotasDeAlumno.GetString(2);
                NotaAux.Puntacion = LeerNotasDeAlumno.GetDouble(3);
                NotaAux.Fecha = LeerNotasDeAlumno.GetDateTime(4);

                ListaDeNotas.Add(NotaAux);

            }

            return ListaDeNotas;

        }


    }
}
