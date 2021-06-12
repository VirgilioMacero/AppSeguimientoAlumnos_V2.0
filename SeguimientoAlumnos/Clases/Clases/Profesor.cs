using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System;

namespace Clases
{
    public class Profesor : Persona
    {

        MySqlConnection ConexionDataBase = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=sistema_seguimiento");

        public List<Ramo> ListaRamosDados { get; set; }


        public Profesor()
        {

            var ListaRamos = new List<Ramo>();

            this.Nombre = "";
            this.RUT = "";
            this.Correo = "";
            this.ListaRamosDados = ListaRamos;


        }
        public Profesor(Profesor Profe)
        {

            this.ListaRamosDados = Profe.ListaRamosDados;
            this.Nombre = Profe.Nombre;
            this.RUT = Profe.RUT;
            this.Correo = Profe.Correo;
            this.Clave = Profe.Clave;

            


        }



        public MySqlCommand LeerBaseDeDatos(string sql)
        {
            ConexionDataBase.Open();
            MySqlCommand Consulta = new MySqlCommand();
            Consulta.Connection = ConexionDataBase;
            Consulta.CommandText = (sql);

            return Consulta;

        }


        //--------------------------Metodos Inicio de Sesion--------------------------------------------------

        //###################################Inicio Sesion Profesor################################################

        //En el siguiente codigo se toman los valores de el metodo LeerBaseDeDatos y se toman los valores retornados
        //para convertirlo en un objeto de la clase Profesor
        public Profesor Inicio_Sesion_Profesor(string sql)
        {

            MySqlDataReader Leer = LeerBaseDeDatos(sql).ExecuteReader();

            if (Leer.Read())
            {

                var Profesor1 = new Profesor();

                Profesor1.Correo = (Leer.GetValue(3)).ToString();
                Profesor1.Nombre = (Leer.GetValue(2)).ToString();
                Profesor1.RUT = (Leer.GetValue(0).ToString());
                Profesor1.Telefono = Leer.GetValue(5).ToString();
                ConexionDataBase.Close();
                Profesor1.ListaRamosDados = Cargar_Ramos_Profesor(Profesor1.RUT);
                ConexionDataBase.Close();
                



                return Profesor1;

            }




            return null;


        }
        //###################################Metodo para cargar Ramos Profesor###################################### 
        public List<Ramo> Cargar_Ramos_Profesor(string Rut)
        {
            var ListaDeRamos = new List<Ramo>();
            string query = "SELECT * FROM ramo,profesor WHERE ramo.RUT_Profesor=profesor.RUT and ramo.RUT_Profesor ='" + Rut + "'";
            MySqlDataReader LeerRamosProfe = LeerBaseDeDatos(query).ExecuteReader();

            while (LeerRamosProfe.Read())
            {
                var RamoAux = new Ramo();
                RamoAux.ID = Convert.ToInt32(LeerRamosProfe.GetValue(0));
                RamoAux.Codigo = LeerRamosProfe.GetString(4);
                RamoAux.Nombre = LeerRamosProfe.GetString(3);
                RamoAux.RUTProfesor = LeerRamosProfe.GetString(2);
                RamoAux.Seccion = LeerRamosProfe.GetInt32(5);
                
                RamoAux.ListaAlumnos = RamoAux.Cargar_Alumnos_Por_Ramo(RamoAux.ID);
                
                RamoAux.ListaAyudantias = RamoAux.Cargar_Ayudantias_Por_Ramo(RamoAux.ID);
                
                ListaDeRamos.Add(RamoAux);

            }

            return ListaDeRamos;
        }



            public Nota IngresarNotaAlumno()
             {


            var Notita = new Nota();

            return Notita;
             }

    }
}
