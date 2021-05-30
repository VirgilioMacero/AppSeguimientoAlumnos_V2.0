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

namespace SeguimientoAlumnos
{

    public partial class VistaAlumno_v2 : Window
    {
        //List<Notificacion> notificacionesAtencion = new List<Notificacion>();

        public VistaAlumno_v2(Alumno Alumnito2)
        {
            InitializeComponent();
            var Alumnito = new Alumno(Alumnito2);
            this.cboxFiltroAsisEstado.SelectedIndex = 0;
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
                }
                LstRamosActuales.ItemsSource = ListaRamos;
            }
            else
            {

            }

            ConexionDataBase.Close();
        }
        //public void cargarNotificacionesAtencion()//Código para mostrar el prototipo, las verdaderas notificaciones se cargarán desde la base de datos
        //{
        //    Notificacion n1 = new Notificacion();
        //    n1.setContenido(1);
        //    Notificacion n2 = new Notificacion();
        //    n2.setContenido(2);
        //    this.notificacionesAtencion.Add(n1);
        //    this.notificacionesAtencion.Add(n2);
        //    foreach(Notificacion n in notificacionesAtencion)
        //    {
        //        this.lboxAtencion.Items.Add(n.getTitulo());
        //    }
        //}

        private void btnFiltroAsisFiltrar_Click(object sender, RoutedEventArgs e)
        {
            if (this.txtFiltroAsisFecha.Text == "" || this.txtFiltroAsisRamo.Text == "")
            {
                MessageBox.Show("Ingrese datos válidos");
            }
            else
            {
                //codigo
            }
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
    }
}
