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


            MySqlConnection ConexionDataBase = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=sistema_seguimiento");
            ConexionDataBase.Open();
            MySqlCommand Consulta = new MySqlCommand();
            Consulta.Connection = ConexionDataBase;
            Consulta.CommandText = ("SELECT * FROM ramo , alumno,lista_alumnos WHERE alumno.RUT ='" + Alumnito.RUT + "' and lista_alumnos.Alumno_Id=alumno.id and lista_alumnos.Ramo_Id = ramo.id");

            MySqlDataReader Leer = Consulta.ExecuteReader();

            var ListaRamos = new List<Ramo>();

            if (Leer.HasRows)
            {
                while (Leer.Read())
                {
                    var Ramo1 = new Ramo();

                    Ramo1.Nombre = Leer.GetValue(1).ToString();
                    Ramo1.Codigo = Leer.GetValue(5).ToString();
                    Ramo1.Seccion = Convert.ToInt32(Leer.GetValue(6));

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MySqlConnection ConexionDataBase = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=sistema_seguimiento");
            ConexionDataBase.Open();
            MySqlCommand Consulta = new MySqlCommand();
            Consulta.Connection = ConexionDataBase;



            if (LstRamosActuales.SelectedItem != null)
            {

                var Ramo1 = new Ramo();
                Ramo1 = (Ramo)LstRamosActuales.SelectedItem;

                Consulta.CommandText = ("SELECT * FROM nota,ramo,lista_alumnos,alumno WHERE nota.Lista_Alumnos_Id = lista_alumnos.id and ramo.id= lista_alumnos.Ramo_Id and alumno.id=lista_alumnos.Alumno_Id and ramo.Codigo='" + Ramo1.Codigo + "' and ramo.Seccion=" + Ramo1.Seccion + "");

                MySqlDataReader Leer = Consulta.ExecuteReader();

                var ListaNotas = new List<Nota>();


                if (Leer.HasRows)
                {


                    while (Leer.Read())
                    {

                        var Nota1 = new Nota();
                        Nota1.NumeroNota = Leer.GetValue(1).ToString();
                        Nota1.Puntacion = Convert.ToDouble(Leer.GetValue(2));

                        ListaNotas.Add(Nota1);

                    }

                    LstMostarNotas.ItemsSource = ListaNotas;

                }
                else
                {

                }

                ConexionDataBase.Close();
            }

            //private void lboxAtencion_SelectionChanged(object sender, SelectionChangedEventArgs e)
            //{
            //    foreach(Notificacion n in notificacionesAtencion)
            //    {
            //        if(n.getTitulo().Equals(this.lboxAtencion.SelectedItem))
            //        {
            //            this.txtbAtencionHora.Text = n.getHora();
            //            this.txtbAtencionTitulo.Text = n.getTitulo();
            //            this.txtbAtencionContenido.Text = n.getContenido();
            //        }
            //    }
            //}
        }
    }
}
