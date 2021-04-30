using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace SeguimientoAlumnos
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();




            

        }

        private void BtnIniciarProfesor_Click(object sender, RoutedEventArgs e)
        {

            MySqlConnection ConexionDataBase = new  MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=sistema_seguimiento");
            ConexionDataBase.Open();
            MySqlCommand Consulta = new MySqlCommand();
            Consulta.Connection = ConexionDataBase;
            Consulta.CommandText = ("select * FROM profesor where RUT ='"+this.TxtUsuarioProfesor.Text +"' and Contrasenia ='" + this.TxtContraseniaProfesor.Text +" ' ");

            MySqlDataReader Leer = Consulta.ExecuteReader();


            if (Leer.Read())
            {

                VistaProfesor VistaProfe = new VistaProfesor();

                VistaProfe.LblNombreProfesor.Content = Leer.GetValue(2);

                VistaProfe.Show();


            }
            else
            {

                MessageBox.Show("Algun dato esta mal introducido");

            }

            ConexionDataBase.Close();



        }

        private void BtnIniciarAlumno_Click(object sender, RoutedEventArgs e)
        {


            MySqlConnection ConexionDataBase = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=sistema_seguimiento");
            ConexionDataBase.Open();
            MySqlCommand Consulta = new MySqlCommand();
            Consulta.Connection = ConexionDataBase;
            Consulta.CommandText = ("select * FROM alumno where RUT ='" + this.TxtUsuarioAlumno.Text + "' and Contrasenia ='" + this.TxtContraseniaAlumno.Text + " ' ");

            MySqlDataReader Leer = Consulta.ExecuteReader();

            if (Leer.Read())
            {

                var Alumnito2 = new Alumno();

                Alumnito2.Nombre = Leer.GetString(5);
                Alumnito2.Correo = Leer.GetString(4);
                Alumnito2.RUT = Leer.GetString(6);
                Alumnito2.Clave = Leer.GetString(7);



                VistaAlumno VistaAlumno1 = new VistaAlumno(Alumnito2);

                VistaAlumno1.Show();


            }
            else
            {

                MessageBox.Show("Hay algun dato mal ingresado");

            }



            //string conexion = "datasource=127.0.0.1;port=3306;username=root;password=;database=sistema_seguimiento";

            //string query = "SELECT * FROM alumno";


            //MySqlConnection ConexionDataBase = new MySqlConnection(conexion);

            //MySqlCommand ConsultaProfesor = new MySqlCommand(query, ConexionDataBase);
            //MySqlDataReader leer;


            //try
            //{
            //    ConexionDataBase.Open();

            //    leer = ConsultaProfesor.ExecuteReader();

            //    if (leer.HasRows)
            //    {

            //        while (leer.Read())
            //        {

            //            string Usuario = leer.GetString(6);

            //            string Clave = leer.GetString(7);

            //            if (Usuario == TxtUsuarioAlumno.Text && Clave == TxtContraseniaAlumno.Text)
            //            {


            //                var Alumnito2 = new Alumno();

            //                Alumnito2.Nombre = leer.GetString(5);
            //                Alumnito2.Correo = leer.GetString(4);
            //                Alumnito2.RUT = leer.GetString(6);
            //                Alumnito2.Clave = leer.GetString(7);



            //                VistaAlumno VistaAlumno1 = new VistaAlumno(Alumnito2);

            //                VistaAlumno1.Show();



            //                break;

            //            }
            //            else
            //            {
            //                MessageBox.Show("El usuario o la contraseña son incorrectos");
            //            }

            //        }


            //    }
            //    else
            //    {

            //        MessageBox.Show("No se encontraron datos");

            //    }

            //}
            //catch
            //{

            //}



        }
    }
}
