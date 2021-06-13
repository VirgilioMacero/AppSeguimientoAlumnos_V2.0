using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace Clases
{
    public class Alumno_Por_Ramo
    {

        MySqlConnection ConexionDataBase = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=sistema_seguimiento");

        public int ID { get; set; } //agregue int ID


        public string Nombre { get; set; }
        public string RUTAlumno { get; set; }

        public List<Nota> ListaNotas { get; set; }

        public List<Ayudantia> ListaAyudantiasInscritas {get; set;}

        public List<Seguimiento> Seguimientos { get; set; } //se agrego List Seguimiento

        public MySqlCommand LeerBaseDeDatos(string sql)
        {
            ConexionDataBase.Open();
            MySqlCommand Consulta = new MySqlCommand();
            Consulta.Connection = ConexionDataBase;
            Consulta.CommandText = (sql);

            return Consulta;

        }

        public void Cargar_Notas_Por_Alumno(int IdRamo,int IdAlumno)
        {
            ConexionDataBase.Close();
            var ListaDeNotas = new List<Nota>();
            string query = "SELECT * FROM nota,alumno_por_ramo,ramo WHERE nota.Id_Alumno_Por_Ramo = alumno_por_ramo.id AND ramo.id=alumno_por_ramo.id_Ramo AND ramo.id ="+IdRamo+" and alumno_por_ramo.id="+IdAlumno+"";
            MySqlDataReader LeerNotasPorAlumno = LeerBaseDeDatos(query).ExecuteReader();

            while (LeerNotasPorAlumno.Read())
            {

                var NotaAux = new Nota();
                NotaAux.ID = LeerNotasPorAlumno.GetInt32(0);
                NotaAux.NumeroNota = LeerNotasPorAlumno.GetString(2);
                NotaAux.Puntacion = LeerNotasPorAlumno.GetDouble(3);
                NotaAux.Fecha = LeerNotasPorAlumno.GetDateTime(4);

                ListaDeNotas.Add(NotaAux);

            }

            this.ListaNotas = ListaDeNotas;

        }
        public void Cargar_Seguimientos_Por_Alumno(int IdRamo ,int IdAlumno)
        {
            ConexionDataBase.Close();
            var ListaSeguimientos = new List<Seguimiento>();
            string query = "SELECT * FROM seguimiento,alumno_por_ramo,ramo WHERE seguimiento.Id_Alumno_Por_Ramo=alumno_por_ramo.id AND ramo.id=alumno_por_ramo.id_Ramo AND ramo.id="+IdRamo+" AND alumno_por_ramo.id ="+IdAlumno+" ";
            MySqlDataReader LeerSeguimientosPorAlumno = LeerBaseDeDatos(query).ExecuteReader();

            while (LeerSeguimientosPorAlumno.Read())
            {
                var SeguimientoAux = new Seguimiento();
                SeguimientoAux.ID = LeerSeguimientosPorAlumno.GetInt32(0);
                SeguimientoAux.Causa = LeerSeguimientosPorAlumno.GetString(2);
                SeguimientoAux.Mensaje = LeerSeguimientosPorAlumno.GetString(3);
                SeguimientoAux.Fecha = LeerSeguimientosPorAlumno.GetDateTime(4);

                ListaSeguimientos.Add(SeguimientoAux);

            }
            ConexionDataBase.Close();
            this.Seguimientos=ListaSeguimientos;

        }
        public void Cargar_Nombre_Alumno(string Rut)
        {
            ConexionDataBase.Close();
            var ListaSeguimientos = new List<Seguimiento>();
            string query = "SELECT * FROM alumno WHERE alumno.RUT='" + Rut + "'";
            MySqlDataReader LeerNombreAlumno = LeerBaseDeDatos(query).ExecuteReader();

            if (LeerNombreAlumno.Read()) {

                string NombreAlum = LeerNombreAlumno.GetString(2);

                this.Nombre = NombreAlum;

            }
            else
            {
            this.Nombre = null;
            }


        }
        public void CargarAyudantiasInscritas(int IdRamo,int IdAlumno)
        {
            ConexionDataBase.Close();
            var ListaSeguimientos = new List<Seguimiento>();
            string query = "SELECT * FROM ayudantia,ramo,alumno_por_ayudantia WHERE ayudantia.id_Ramo=ramo.id AND alumno_por_ayudantia.id_ayudantia = ayudantia.id AND ramo.id = "+IdRamo+" AND alumno_por_ayudantia.id_Alumno_Por_Ramo ="+IdAlumno+"";
            MySqlDataReader LeerAyudantiasPorAlumno = LeerBaseDeDatos(query).ExecuteReader();

            var ListaAyudantiaAux = new List<Ayudantia>();

            while (LeerAyudantiasPorAlumno.Read())
            {

                var AyudantiaAux = new Ayudantia();

                AyudantiaAux.ID = LeerAyudantiasPorAlumno.GetInt32(0);
                AyudantiaAux.NombreRamo = LeerAyudantiasPorAlumno.GetString(2);
                AyudantiaAux.Fecha = LeerAyudantiasPorAlumno.GetDateTime(3);

                ListaAyudantiaAux.Add(AyudantiaAux);

            }

            this.ListaAyudantiasInscritas = ListaAyudantiaAux;

        }






        public List<string> MostrarSeguimiento(List<Seguimiento> Seg,List<Nota> Not)
        {

            var Lista = new List<string>();


            return Lista;

        }


    }
}
