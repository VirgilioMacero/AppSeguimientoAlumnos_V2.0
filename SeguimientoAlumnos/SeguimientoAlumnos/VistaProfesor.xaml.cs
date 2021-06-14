﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows;
using Clases;

namespace SeguimientoAlumnos
{
    /// <summary>
    /// Lógica de interacción para VistaProfesor.xaml
    /// </summary>
    public partial class VistaProfesor : Window
    {
        private List<Ramo> ListaRamos = new List<Ramo>();

        private List<Alumno_Por_Ramo> ListaAlumnos = new List<Alumno_Por_Ramo>();

        public Profesor ProfeAux = new Profesor();
        public VistaProfesor(Profesor Profe)
        {
            InitializeComponent();
            LblNombreProfesor.Content = Profe.Nombre;
            LblRutProfesor.Content = Profe.RUT;
           

            var ListaRamosAyudantias = new List<Ayudantia>();

           
                
            var ListaAyudantias = new List<Ayudantia>();

            foreach (var Ramo in Profe.ListaRamosDados)
            {
                ListaRamos.Add(Ramo); 

                foreach (var Ayudantia in Ramo.ListaAyudantias)
                {

                    ListaAyudantias.Add(Ayudantia);

                }


            }

            LstRamosDados.ItemsSource = Profe.ListaRamosDados;
            LstRamosDados_Seguimiento.ItemsSource = Profe.ListaRamosDados;
            LstRamosDadosAyudantias.ItemsSource = Profe.ListaRamosDados;
            LstRamosAyudantias.ItemsSource = ListaAyudantias;
            LstRamosAyudantias.ItemsSource = ListaAyudantias;
            LstRamosDadosEscogidos_Seguimiento.ItemsSource = ListaRamos;
            LstNotificaciones.ItemsSource = Profe.Mensajes;
            LstRamosDados_Mensaje.ItemsSource = ListaRamos;
            ProfeAux = Profe;



        }



        private void BtnMostrarAlumnos_Click(object sender, RoutedEventArgs e)
        {

            var Profe2 = ProfeAux;
            LstAlumnosInscritos.ItemsSource = null;
            ListaAlumnos.Clear();

            if (LstRamosDados.SelectedItem != null)
            {

            var RamoLsv = (Ramo)LstRamosDados.SelectedItem;

            foreach (var Ramo1 in Profe2.ListaRamosDados)
            {
                if (Ramo1.ID == RamoLsv.ID)
                {
                foreach (var Alumno1 in Ramo1.ListaAlumnos)
                {

                    ListaAlumnos.Add(Alumno1);

                }
                }

            }

            LstAlumnosInscritos.ItemsSource = ListaAlumnos;

            }


        }
        private void BtnMostrarAlumnos_Seguimientos_Click(object sender, RoutedEventArgs e)
        {

            var Profe2 = ProfeAux;
            LstAlumnosInscritos_Seguimiento.ItemsSource = null;
            ListaAlumnos.Clear();

            if (LstRamosDados_Seguimiento.SelectedItem != null)
            {

                var RamoLsv = (Ramo)LstRamosDados_Seguimiento.SelectedItem;

                foreach (var Ramo1 in Profe2.ListaRamosDados)
                {
                    if (Ramo1.ID == RamoLsv.ID)
                    {
                        foreach (var Alumno1 in Ramo1.ListaAlumnos)
                        {
                            Alumno1.Cargar_Nombre_Alumno(Alumno1.RUTAlumno);
                            ListaAlumnos.Add(Alumno1);

                        }
                    }

                }

                LstAlumnosInscritos_Seguimiento.ItemsSource = ListaAlumnos;

            }
            else
            {
                MessageBox.Show("Debe Seleccionar un Ramo");
            }

        }

        private void BtnMostrarNotas_Click(object sender, RoutedEventArgs e)
        {
            MostrarNotas();
        }
        public void MostrarNotas()
        {

            var ListaDeNotas = new List<Nota>();
            var Profe1 = ProfeAux;

            if (LstAlumnosInscritos.SelectedItem != null)
            {
            var Seleccion = (Alumno_Por_Ramo)LstAlumnosInscritos.SelectedItem;
            var RamoEscogido = (Ramo)LstRamosDados.SelectedItem;

            foreach (var Alumno1 in ListaAlumnos)
            {
                if (Alumno1.RUTAlumno == Seleccion.RUTAlumno)
                {
                    Alumno1.Cargar_Notas_Por_Alumno(RamoEscogido.ID,Alumno1.ID);
                foreach (var Nota in Alumno1.ListaNotas)
                {
                    ListaDeNotas.Add(Nota);

                }

                }
            }

                LsvNotasAlumno.ItemsSource = ListaDeNotas;

            }
            else
            {
                MessageBox.Show("Debe seleccionar un valor");
            }

        }

        private void BtnModificarNota_Click(object sender, RoutedEventArgs e)
        {

            if (LsvNotasAlumno.SelectedItem != null)
            {
                if (TxtNotaNueva.Text != null)
                {

                var Nota1 = (Nota)LsvNotasAlumno.SelectedItem;

                Nota1.CambiarNota(Nota1.ID,TxtNotaNueva.Text);
                
                MessageBox.Show("Se modifico la nota");
                    MostrarNotas();
                    TxtNotaNueva.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show("Debe ingresar un valor en la barra de texto");
                }

            }
            else
            {
                MessageBox.Show("Debe seleccionar una nota para Cambiarla");
            }

          

        }

        private void BtnSubirPuntuacion_Click(object sender, RoutedEventArgs e)
        {
            

            if (LstAlumnosInscritos.SelectedItem != null)
            {

                if (TxtNuevaNota.Text != string.Empty && DtpFechaNota.SelectedDate != null)
                {
                var Alumno1 = (Alumno_Por_Ramo)LstAlumnosInscritos.SelectedItem;

                string Nota1 = "Nota "+(LsvNotasAlumno.Items.Count + 1);

                var NotaAux = new Nota();
                NotaAux.SubirNota(Alumno1.ID,Nota1,TxtNuevaNota.Text,DtpFechaNota.SelectedDate.Value);
                    MessageBox.Show("Se ha subido la nota satisfactoriamente");
                    TxtNuevaNota.Text = string.Empty;
                    DtpFechaNota.SelectedDate = null;
                    MostrarNotas();

                }
                else
                {
                    MessageBox.Show("Debe ingresar Todos Los Valores");
                }

            }
            else
            {

                MessageBox.Show("Debe seleccionar un alumno");

            }






        }

        private void BtnCrearAyudantia_Click(object sender, RoutedEventArgs e)
        {


            if (LstRamosDadosAyudantias.SelectedItem != null)
            {

                if (DtpFechaAyuda.SelectedDate != null)
                {

                    var RamoSeleccionado = (Ramo)LstRamosDadosAyudantias.SelectedItem;

                    var AyudantiaAux = new Ayudantia();

                    AyudantiaAux.SubirAyudantia(RamoSeleccionado.ID,DtpFechaAyuda.SelectedDate.Value);

                    MessageBox.Show("Se agrego la ayudantia exitosamente");
                    DtpFechaAyuda.SelectedDate = null;
                    ActualizarAyudantias();
                }
                else
                {
                    MessageBox.Show("Debe Seleccionar una Fecha");
                }

            }
            else
            {

                MessageBox.Show("Debe seleccionar algun ramo");

            }




        }

        public void ActualizarAyudantias()
        {

            
            var ListaAyudantias = new List<Ayudantia>();
            foreach (var Ramo1 in ProfeAux.ListaRamosDados)
            {
                Ramo1.Cargar_Ayudantias_Por_Ramo(Ramo1.ID);
                foreach (var Ayudantia1 in Ramo1.ListaAyudantias)
                {

                    ListaAyudantias.Add(Ayudantia1);

                }

            }

            LstRamosAyudantias.ItemsSource = ListaAyudantias;

        }

        private void BtnEliminarAyudantia_Click(object sender, RoutedEventArgs e)
        {
            if (LstRamosAyudantias.SelectedItem != null)
            {

                var AyudantiaEscogida = (Ayudantia)LstRamosAyudantias.SelectedItem;
                AyudantiaEscogida.Cargar_Alumnos_Por_Ayudantia(AyudantiaEscogida.ID);
                AyudantiaEscogida.EliminarAyudantia();

                ActualizarAyudantias();
                LstAlumnosInscritos_Ayudantia_Todos.ItemsSource = null;

            }
            else
            {
                MessageBox.Show("Debe seleccionar una Ayudantia para Eliminarla");
            }


        }

        private void BtnsubirSeguimiento_Click(object sender, RoutedEventArgs e)
        {

            if (LstAlumnosInscritos_Seguimiento.SelectedItem != null)
            {

                if (TxtCausaSeguimiento.Text != string.Empty && TxtMensajeSeguimiento.Text != string.Empty && DtpFechaSeguimiento.SelectedDate != null )
                {
                    var Seguimiento1 = new Seguimiento();

                    Seguimiento1.Causa = TxtCausaSeguimiento.Text;
                    Seguimiento1.Mensaje = TxtMensajeSeguimiento.Text;
                    Seguimiento1.Fecha = DtpFechaSeguimiento.SelectedDate.Value;
                    var AlumnoSelec = (Alumno_Por_Ramo)LstAlumnosInscritos_Seguimiento.SelectedItem;
                    Seguimiento1.SubirSeguimiento(AlumnoSelec.ID);

                    MessageBox.Show("Se Envio de Manera Correcta");

                    TxtCausaSeguimiento.Text = string.Empty;
                    TxtMensajeSeguimiento.Text = string.Empty;
                    DtpFechaSeguimiento.SelectedDate = null;


                }
                else
                {
                    MessageBox.Show("Debe Ingresar todos los campos del Seguimiento");
                }

            }
            else
            {
                MessageBox.Show("Debe seleccionar a un alumnos");
            }


        }

        private void BtnLimpiarSeguimiento_Click(object sender, RoutedEventArgs e)
        {

            TxtCausaSeguimiento.Text = string.Empty;
            TxtMensajeSeguimiento.Text = string.Empty;
            DtpFechaSeguimiento.SelectedDate = null;


        }


        private void BtnMostrarGrafico_Seguimiento_Click(object sender, RoutedEventArgs e)
        {
            if (LstRamosDadosEscogidos_Seguimiento.SelectedItem != null)
            {
                if (LstAlumnosEscogidos_Seguimiento.SelectedItem !=null)
                {
            var Alumno1 = (Alumno_Por_Ramo)LstAlumnosEscogidos_Seguimiento.SelectedItem;
            var Ramo1 = (Ramo)LstRamosDadosEscogidos_Seguimiento.SelectedItem;
            Alumno1.Cargar_Notas_Por_Alumno(Ramo1.ID,Alumno1.ID);
            Alumno1.Cargar_Seguimientos_Por_Alumno(Ramo1.ID,Alumno1.ID);
            Alumno1.CargarAyudantiasInscritas(Ramo1.ID,Alumno1.ID);

            var ventana = new VistaGrafico(Alumno1);

            ventana.Show();

                }
                else
                {
                    MessageBox.Show("Debe seleccionar el alumno al cual se mostrara el grafico");
                }

            }
            else
            {
                MessageBox.Show("Debe Seleccionar un Ramo para Mostrar el grafico");
            }
        }

        private void BtnMostrarAlumnosEscogidos_Seguimientos_Click(object sender, RoutedEventArgs e)
        {


            var Profe2 = ProfeAux;
            LstAlumnosEscogidos_Seguimiento.ItemsSource = null;
            ListaAlumnos.Clear();

            if (LstRamosDadosEscogidos_Seguimiento.SelectedItem != null)
            {

                var RamoLsv = (Ramo)LstRamosDadosEscogidos_Seguimiento.SelectedItem;

                foreach (var Ramo1 in Profe2.ListaRamosDados)
                {
                    if (Ramo1.ID == RamoLsv.ID)
                    {
                        foreach (var Alumno1 in Ramo1.ListaAlumnos)
                        {

                            ListaAlumnos.Add(Alumno1);

                        }
                    }

                }

                LstAlumnosEscogidos_Seguimiento.ItemsSource = ListaAlumnos;

            }
            else
            {
                MessageBox.Show("Debe Seleccionar un Ramo");
            }


        }

        private void LstNotificaciones_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

            if (LstNotificaciones.SelectedItem != null)
            {

            var NotificacionAux = (Mensaje)LstNotificaciones.SelectedItem;

                foreach (var Noti in ProfeAux.Mensajes)
                {

                    if (Noti.ID == NotificacionAux.ID)
                    {

                        TxtbNotifContenido.Text = Noti.Cuerpo;
                        LblAsuntoMensaje.Content = Noti.Titulo;
                        LblRemitenteMensaje.Content = Noti.Remitente;
                        LblFechaMensaje.Content = Noti.Fecha.ToString("MMMM dd, yyyy");
                        Noti.SeLeyo(Noti.ID);

                    }

                }

            }


            


        }

        private void BtnEnviarMensaje_Click(object sender, RoutedEventArgs e)
        {

            if (LstRamosDados_Mensaje.SelectedItem != null)
            {

                if (CmbDestinatario.SelectedItem != null && TxtAsunto.Text != string.Empty && TxtMensajeRemitente.Text != string.Empty)
                {
                    
                    ProfeAux.EnviarMensaje(ProfeAux.Correo,CmbDestinatario.SelectedItem.ToString(),TxtAsunto.Text,TxtMensajeRemitente.Text,DateTime.Now,false);

                    MessageBox.Show("El mensaje se envio con esxito");

                    CmbDestinatario.ItemsSource = null;
                    TxtAsunto.Text = string.Empty;
                    TxtMensajeRemitente.Text = string.Empty;

                }
                else
                {
                    MessageBox.Show("Debe Ingresar todos los Valores");
                }

            }
            else
            {
                MessageBox.Show("Debe Seleccionar un Ramo");
            }


        }

        private void LstRamosDados_Mensaje_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {


            if (LstRamosDados_Mensaje.SelectedItem != null)
            {

                var ListaCorreos = new List<string>();
                var Seleccionado = (Ramo)LstRamosDados_Mensaje.SelectedItem;

                foreach (var Ramo1 in ListaRamos)
                {
                    if (Seleccionado.ID == Ramo1.ID)
                    {

                        foreach (var Alumno1 in Ramo1.ListaAlumnos)
                        {

                            ListaCorreos.Add(Alumno1.MostrarCorreo(Alumno1.RUTAlumno));

                        }

                    }


                }

                CmbDestinatario.ItemsSource = ListaCorreos;

            }
            else
            {
                MessageBox.Show("Debe Seleccionar un Ramo");
            }




        }

        private void BtnLimpiarControlesMensaje_Click(object sender, RoutedEventArgs e)
        {
            CmbDestinatario.ItemsSource = null;
            TxtAsunto.Text = string.Empty;
            TxtMensajeRemitente.Text = string.Empty;
        }

        private void BtnMostrar_Ayudantias_Click(object sender, RoutedEventArgs e)
        {

            if (LstAlumnosInscritos_Seguimiento.SelectedItem != null)
            {
                var RamoSeleccionado = (Ramo)LstRamosDados_Seguimiento.SelectedItem;
                var AlumnoSeleccionado = (Alumno_Por_Ramo)LstAlumnosInscritos_Seguimiento.SelectedItem;

                AlumnoSeleccionado.CargarAyudantiasInscritas(RamoSeleccionado.ID,AlumnoSeleccionado.ID);

                LstRamosAyudantias_Para_Seguimiento.ItemsSource = AlumnoSeleccionado.ListaAyudantiasInscritas;

            }
            else
            {
                MessageBox.Show("Debe seleccionar un alumno");
            }


        }

        private void BtnMostrarAlumnosAyudantia_Click(object sender, RoutedEventArgs e)
        {

            if (LstRamosAyudantias.SelectedItem != null)
            {
                var ListaAlumnosPorRamo = new List<Alumno_Por_Ramo>();
                var Ayudantia2 = (Ayudantia)LstRamosAyudantias.SelectedItem;
                Ayudantia2.Cargar_Alumnos_Por_Ayudantia(Ayudantia2.ID);

                foreach (var AlumnoAux in Ayudantia2.ListaAlumnoPorAyudantia)
                {

                    ListaAlumnosPorRamo.Add(AlumnoAux.AlumnoInscritoAyudantia);

                }

                LstAlumnosInscritos_Ayudantia_Todos.ItemsSource = ListaAlumnosPorRamo;

            }
            else
            {
                MessageBox.Show("Debe Seleccionar una ayudantia");
            }




        }
    }
}
