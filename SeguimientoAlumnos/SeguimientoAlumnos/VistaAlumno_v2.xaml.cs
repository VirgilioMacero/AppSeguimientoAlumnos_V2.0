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
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using Clases;

namespace SeguimientoAlumnos
{

    public partial class VistaAlumno_v2 : Window
    {
        //List<Notificacion> notificacionesAtencion = new List<Notificacion>();

        public VistaAlumno_v2(Alumno Alumnito2)
        {
            InitializeComponent();
            var Alumnito = new Alumno(Alumnito2);
           // this.cboxFiltroAsisEstado.SelectedIndex = 0;
            //Ventana Seguimiento/Inicio
            this.lblBienvenido.Content = "Bienvenido " + Alumnito2.Nombre;
            this.txtbInicio.Text = "";
            //this.cargarNotificacionesAtencion();
            //Ventana Universidad/Profesor
            this.cboxUniProfOrigen.SelectedIndex = 0;
            this.cboxUniProfRamo.SelectedIndex = 0;
            this.cboxUniProfEscuela.SelectedItem = 0;
            this.LblRUTAlumno.Content = Alumnito.RUT;
            this.LblNombreAlumno.Content = Alumnito.Nombre;

            MySqlConnection ConexionDataBase = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=sistema_seguimiento");
            ConexionDataBase.Open();
            MySqlCommand Consulta = new MySqlCommand();
            Consulta.Connection = ConexionDataBase;
            Consulta.CommandText = ("SELECT * FROM ramo, alumno_por_ramo,alumno WHERE ramo.id=alumno_por_ramo.id_Ramo AND alumno_por_ramo.RUT_Alumno = alumno.RUT AND alumno.RUT='"+Alumnito2.RUT+"'");

            MySqlDataReader Leer = Consulta.ExecuteReader();

            var ListaRamos = new List<Ramo>();

            if (Leer.HasRows)
            {
                while (Leer.Read())
                {
                    var Ramo1 = new Ramo();

                    Ramo1.Nombre = Leer.GetValue(3).ToString();
                    Ramo1.Codigo = Leer.GetValue(4).ToString();
                    Ramo1.Seccion = Convert.ToInt32(Leer.GetValue(5));

                    ListaRamos.Add(Ramo1);

                    string ContenidoCmb = Leer.GetValue(0).ToString() + "_ "+Ramo1.Nombre+" _ "+Ramo1.Codigo+" _ "+Ramo1.Seccion;

                    CmbRamosRegistroAyudantias.Items.Add(ContenidoCmb);

                }
                LstRamosActuales.ItemsSource = ListaRamos;
                
            }
            else
            {

            }

            ConexionDataBase.Close();
            


        }


        private void btnSoporteEnviar_Click(object sender, RoutedEventArgs e)
        {
            if (this.txtSoporteDesc.Text == "" || this.txtSoporteTItulo.Text == "")
            {
                MessageBox.Show("Revisar texto ingresado");
            }
            else
            {
                //codigo
            }
        }

       
 
        

        private void BtnMostrarNotasAlumn_Click(object sender, RoutedEventArgs e)
        {

            MySqlConnection ConexionDataBase = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=sistema_seguimiento");
            ConexionDataBase.Open();
            MySqlCommand Consulta = new MySqlCommand();
            Consulta.Connection = ConexionDataBase;



            if (LstRamosActuales.SelectedItem != null)
            {

                var Ramo1 = new Ramo();
                Ramo1 = (Ramo)LstRamosActuales.SelectedItem;


                Consulta.CommandText = ("SELECT * FROM nota,ramo,alumno_por_ramo WHERE nota.Id_Alumno_Por_Ramo=alumno_por_ramo.id AND alumno_por_ramo.id_Ramo = ramo.id AND ramo.Codigo='"+Ramo1.Codigo+"' AND ramo.Seccion = "+Ramo1.Seccion+" AND alumno_por_ramo.RUT_Alumno='"+LblRUTAlumno.Content+"'");

                MySqlDataReader Leer = Consulta.ExecuteReader();

                var ListaNotas = new List<Nota>();


                if (Leer.HasRows)
                {


                    while (Leer.Read())
                    {

                        var Nota1 = new Nota();
                        Nota1.NumeroNota = Leer.GetValue(2).ToString();
                        Nota1.Puntacion = Convert.ToDouble(Leer.GetValue(3));

                        ListaNotas.Add(Nota1);

                    }

                    LstMostarNotas.ItemsSource = ListaNotas;

                }
                else
                {

                }

                ConexionDataBase.Close();

        }   }

        private void CmbRamosRegistroAyudantias_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var Valorseleccionado = CmbRamosRegistroAyudantias.SelectedItem.ToString();

            var valorSeparado = Valorseleccionado.Split('_');

            MySqlConnection ConexionDataBase = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=sistema_seguimiento");
            ConexionDataBase.Open();
            MySqlCommand Consulta2 = new MySqlCommand();
            Consulta2.Connection = ConexionDataBase;
            Consulta2.CommandText = "SELECT * FROM ayudantia,ramo WHERE ayudantia.id_Ramo=ramo.id AND ramo.id ="+valorSeparado[0]+"";
            MySqlDataReader Leer = Consulta2.ExecuteReader();
            var ListaAyudantias = new List<Ayudantia>();

            while (Leer.Read())
            {

                if (Convert.ToDateTime(Leer.GetValue(3)) >= DateTime.Now)
                {

                    var Ayudantia1 = new Ayudantia();
                    Ayudantia1.ID = Convert.ToInt32(Leer.GetValue(0));
                    Ayudantia1.NombreRamo = Leer.GetValue(2).ToString();
                    Ayudantia1.Fecha = Convert.ToDateTime(Leer.GetValue(3));

                    ListaAyudantias.Add(Ayudantia1);


                }



            }

            LstAyudantiasDisponibles.ItemsSource = ListaAyudantias;

            ConexionDataBase.Close();


        }

        private void btnAyudInscEnviar_Click(object sender, RoutedEventArgs e)
        {


            MySqlConnection ConexionDataBase = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=sistema_seguimiento");

            ConexionDataBase.Open();
            var Valorseleccionado = CmbRamosRegistroAyudantias.SelectedItem.ToString();
            var valorSeparado = Valorseleccionado.Split('_');
            MySqlCommand Consulta2 = new MySqlCommand();
            Consulta2.Connection = ConexionDataBase;
            Consulta2.CommandText = "SELECT * FROM alumno_por_ramo,ramo WHERE ramo.id = alumno_por_ramo.id_Ramo and alumno_por_ramo.RUT_Alumno ='"+ LblRUTAlumno.Content +"' AND ramo.id = "+valorSeparado[0]+"";
            MySqlDataReader Leer = Consulta2.ExecuteReader();

            var IdAlumno_Por_Ramo =0;

            while (Leer.Read())
            {

            IdAlumno_Por_Ramo = Convert.ToInt32(Leer.GetValue(0));

            }



            ConexionDataBase.Close();

            ConexionDataBase.Open();

            if (LstAyudantiasDisponibles.SelectedItem != null)
            {

                var Ayudantia1 = (Ayudantia)LstAyudantiasDisponibles.SelectedItem;


                string Query = "INSERT INTO alumno_por_ayudantia (id,id_ayudantia,id_Alumno_Por_Ramo) VALUES (NULL, " + Ayudantia1.ID + ",'" + IdAlumno_Por_Ramo + "')";

                MySqlCommand CargarNota = new MySqlCommand(Query, ConexionDataBase);

                CargarNota.ExecuteNonQuery();

                ConexionDataBase.Close();





            }
            else
            {

                MessageBox.Show("Debe seleccionar alguna ayudantia y tomar mejores deciciones en la vida ");

            }





        }
    }
}
