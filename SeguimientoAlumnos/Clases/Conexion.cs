using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using MySql.Data.MySqlClient;

namespace Clases
{
    public class Conexion
    {
        MySqlConnection ConexionDataBase = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=sistema_seguimiento");

        public string NombreConexion { get; set; }


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

               // string query = "SELECT * FROM ramo,profesor WHERE ramo.RUT_Profesor=profesor.RUT and ramo.RUT_Profesor ='" + Profesor1.RUT + "'";

               // MySqlDataReader LeerRamosProfe = LeerBaseDeDatos(query).ExecuteReader();



                return Profesor1;

            }


            ConexionDataBase.Close();

            return null;


        }
        //#######################################Inicio de Sesion Alumno########################################

        //En este metodo se usa el codigo retornado por el metodo LeerBaseDeDatos y se crea un objeto del tipo 
        //Alumno el cual se retorna a la vista de Alumno
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

                return Alumnito2;

            }

            ConexionDataBase.Close();


            return null;

        }

        //###################################Inicio de Sesion Administrador#########################################












    }
}
