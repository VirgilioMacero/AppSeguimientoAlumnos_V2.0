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
        //En este apartado se cargan todos los valores de fabrica de cada apartado
        public Alumno AlumnoAux = new Alumno(); 
        public VistaAlumno_v2(Alumno Alumnito)
        {
            InitializeComponent();
            

            this.lblBienvenido.Content = "Bienvenido " + Alumnito.Nombre;
            this.txtbInicio.Text = "";
            this.LblRUTAlumno.Content = Alumnito.RUT;
            this.LblNombreAlumno.Content = Alumnito.Nombre;
            LstNotificacionesEntrantes.ItemsSource = Alumnito.Mensajes;
            LstRamosActuales.ItemsSource = Alumnito.ListaRamos;
            LstRamosActuales_Mensaje.ItemsSource = Alumnito.ListaRamos;
            LstRamosActuales_Ayudantias.ItemsSource = Alumnito.ListaRamos;
            LstAyudantiasDisponibles_Escogidas.ItemsSource = Alumnito.DescargarAyudantias(Alumnito.RUT);

            AlumnoAux = Alumnito;

        }

        //Este boton Muestra las notas de el  alumnos en LstMostrarNotas
        private void BtnMostrarNotasAlumn_Click(object sender, RoutedEventArgs e)
        {

            if (LstRamosActuales.SelectedItem != null)
            {

                var RamoSeleccionado = (Ramo)LstRamosActuales.SelectedItem;

                LstMostarNotas.ItemsSource = AlumnoAux.CargarNotas(RamoSeleccionado.ID);

            
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Ramo");
            }
        
        }

       


        
        //En este boton al ser presionado se agrega la ayudantia seleccioanada a la base de datos
        private void btnAyudInscEnviar_Click(object sender, RoutedEventArgs e)
        {


            if (LstAyudantiasDisponibles.SelectedItem != null)
            {

                var RamoAux = (Ramo)LstRamosActuales_Ayudantias.SelectedItem;
                var AyudantAux = (Ayudantia)LstAyudantiasDisponibles.SelectedItem;

                AlumnoAux.RegistrarAyudantia(AyudantAux.ID,AlumnoAux.CargarAlumno(RamoAux.ID,AlumnoAux.RUT));
                MessageBox.Show("Se ha registrado exitosamente a la ayudantia");


            }
            else
            {
                MessageBox.Show("Debe seleccionar alguna ayudantia y tomar mejores deciciones en la vida ");
            }





        }
        //En este apartado se cargan los mensajes entrantes en El List view LstNotificacionesEntrantes
        private void LstNotificacionesEntrantes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (LstNotificacionesEntrantes.SelectedItem != null)
            {

                var NotificacionAux = (Mensaje)LstNotificacionesEntrantes.SelectedItem;

                foreach (var Mensaj in AlumnoAux.Mensajes)
                {

                    if (NotificacionAux.ID == Mensaj.ID)
                    {
                        LblFechaNotificacion.Content = Mensaj.Fecha.ToString("MMMM dd, yyyy");
                        LblRemitente.Content = Mensaj.Remitente;
                        LblTituloNotificacion.Content = Mensaj.Titulo;
                        TxtBNotificacion.Text = Mensaj.Cuerpo;
                        Mensaj.SeLeyo(Mensaj.ID);

                    }

                }


            }



        }
        //En este apartado se carga el label Lbldestinatario con el correo del docente
        private void LstRamosActuales_Mensaje_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (LstRamosActuales_Mensaje.SelectedItem != null)
            {

                var Seleccionado = (Ramo)LstRamosActuales_Mensaje.SelectedItem;

                foreach (var RamoAux in AlumnoAux.ListaRamos)
                {

                    if (RamoAux.ID == Seleccionado.ID)
                    {

                       LblDestinatario.Content = RamoAux.CargarCorreoProfe(RamoAux.ID);


                    }
                }

            }

        }
        //En este apartado se Sube a la base de Datos el Mensaje escrito 
        private void BtnEnviarMensaje_Click(object sender, RoutedEventArgs e)
        {
            if (LstRamosActuales_Mensaje.SelectedItem != null)
            {

                if (LblDestinatario.Content != string.Empty && TxtAsuntoMensaje.Text != string.Empty && TxtMensaje.Text != string.Empty)
                {

                    AlumnoAux.EnviarMensaje(AlumnoAux.Correo, LblDestinatario.Content.ToString(), TxtAsuntoMensaje.Text,TxtMensaje.Text, DateTime.Now, false);

                    MessageBox.Show("Se ha enviado el mensaje Exitosamente");

                    LblDestinatario.Content = string.Empty;
                    TxtAsuntoMensaje.Text = string.Empty;
                    TxtMensaje.Text = string.Empty;

                }
                else
                {
                    MessageBox.Show("Debe Ingresar Todos lo valores");
                }



            }
            else
            {
                MessageBox.Show("Debe seleccionar un Ramo");
            }



        }
        //En este apartado se Cargan Las Ayudantias disponibles para el alumno
        private void LstRamosActuales_Ayudantias_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (LstRamosActuales_Ayudantias.SelectedItem != null)
            {
                var SeleccionRamo = (Ramo)LstRamosActuales_Ayudantias.SelectedItem;

               LstAyudantiasDisponibles.ItemsSource =  AlumnoAux.CargarAyudantias(SeleccionRamo.ID);

            }
            else
            {
                MessageBox.Show("Debe Seleccionar un ramo");
            }


        }

        private void BtnLimpiarControlesMensaje_Click(object sender, RoutedEventArgs e)
        {
            LblDestinatario.Content = string.Empty;
            TxtAsuntoMensaje.Text = string.Empty;
            TxtMensaje.Text = string.Empty;

        }
    }
}
