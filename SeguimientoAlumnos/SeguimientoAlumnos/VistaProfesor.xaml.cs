using MySql.Data.MySqlClient;
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
        public List<Ramo> ListaRamos { get; set; }

        public List<Alumno_Por_Ramo> ListaAlumnos = new List<Alumno_Por_Ramo>();

        public Profesor ProfeAux = new Profesor();
        public VistaProfesor(Profesor Profe)
        {
            InitializeComponent();
            LblNombreProfesor.Content = Profe.Nombre;
            LblRutProfesor.Content = Profe.RUT;
           

            var ListaRamosAyudantias = new List<Ayudantia>();

           
                LstRamosDados.ItemsSource = Profe.ListaRamosDados;
                LstRamosDados_Seguimiento.ItemsSource = Profe.ListaRamosDados;
                LstRamosDadosAyudantias.ItemsSource = Profe.ListaRamosDados;
                
            var ListaAyudantias = new List<Ayudantia>();

            foreach (var Ramo in Profe.ListaRamosDados)
            {

                foreach (var Ayudantia in Ramo.ListaAyudantias)
                {

                    ListaAyudantias.Add(Ayudantia);

                }


            }

            LstRamosAyudantias.ItemsSource = ListaAyudantias;
           

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
            
            var ListaDeNotas = new List<Nota>();
            var Profe1 = ProfeAux;

            if (LstAlumnosInscritos.SelectedItem != null)
            {
            var Seleccion = (Alumno_Por_Ramo)LstAlumnosInscritos.SelectedItem;


            foreach (var Alumno1 in ListaAlumnos)
            {
                if (Alumno1.RUTAlumno == Seleccion.RUTAlumno)
                {
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
            var ListaModificacionesNota = new List<string>();
            var ListaNotas = new List<Nota>();
            MySqlConnection ConexionDataBase = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=sistema_seguimiento");
            ConexionDataBase.Open();
            MySqlCommand ConsultaNotas = new MySqlCommand();
            ConsultaNotas.Connection = ConexionDataBase;

            if (CmbSeleccionarNota.SelectedItem != null)
            {
                var Ramo1 = new Ramo();
                Ramo1 = (Ramo)LstRamosDados.SelectedItem;

                var Persona1 = new Alumno_Por_Ramo();
                Persona1 = (Alumno_Por_Ramo)LstAlumnosInscritos.SelectedItem;

                var Nota1 = CmbSeleccionarNota.SelectedItem.ToString();
                string Nota = TxtNotaNueva.Text;

                ConsultaNotas.CommandText = $"UPDATE nota,lista_alumnos,ramo,alumno SET nota.Puntuacion ={Nota} WHERE nota.Lista_Alumnos_Id= lista_alumnos.id and ramo.Codigo ='{Ramo1.Codigo}' and ramo.Seccion ={Ramo1.Seccion} and alumno.RUT ='{Persona1.RUTAlumno}' and nota.NumeroNota='{Nota1}'";
                MySqlDataReader LeerNotas = ConsultaNotas.ExecuteReader();

                LeerNotas.Read();

            }


            ConexionDataBase.Close();


        }

        private void BtnSubirPuntuacion_Click(object sender, RoutedEventArgs e)
        {

            MySqlConnection ConexionDataBase = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=sistema_seguimiento");
            ConexionDataBase.Open();
            

            if (LstAlumnosInscritos.SelectedItem != null)
            {

                var Ramo1 = (Ramo)LstRamosDados.SelectedItem;

                var Alumno1 = (Alumno_Por_Ramo)LstAlumnosInscritos.SelectedItem;

                string Nota1 = "Nota "+(LsvNotasAlumno.Items.Count + 1);



                string Query = "INSERT INTO nota (id, Id_Alumno_Por_Ramo, NumeroNota, Puntuacion, Fecha) VALUES (NULL, " + Alumno1.ID + ", '"+Nota1+"', " + TxtNuevaNota.Text + ", '"+DtpFechaNota.SelectedDate.Value+"')";

                MySqlCommand CargarNota = new MySqlCommand(Query,ConexionDataBase);

                CargarNota.ExecuteNonQuery();

                ConexionDataBase.Close();

            }
            else
            {

                MessageBox.Show("Debe seleccionar un alumno");

            }






        }

        private void BtnCrearAyudantia_Click(object sender, RoutedEventArgs e)
        {

            MySqlConnection ConexionDataBase = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=sistema_seguimiento");
            ConexionDataBase.Open();

            if (LstRamosDadosAyudantias.SelectedItem != null)
            {

                var Ramo1 = (Ramo)LstRamosDadosAyudantias.SelectedItem;


                string Query = "INSERT INTO ayudantia (id,id_Ramo,NombreRamo,Fecha) VALUES (NULL, "+Ramo1.ID+",'"+Ramo1.Nombre+"','"+SeleccioneFechaAyuda.SelectedDate.Value.ToString("u")+"')";

                MySqlCommand CargarNota = new MySqlCommand(Query, ConexionDataBase);

                CargarNota.ExecuteNonQuery();

                ConexionDataBase.Close();





            }
            else
            {

                MessageBox.Show("Debe seleccionar algun ramo y tomar mejores deciciones en la vida ");

            }




        }



        private void BtnActualizarAyudantias_Click(object sender, RoutedEventArgs e)
        {


            MySqlConnection ConexionDataBase = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=sistema_seguimiento");
            ConexionDataBase.Open();
            MySqlCommand Consulta2 = new MySqlCommand();
            Consulta2.Connection = ConexionDataBase;
            Consulta2.CommandText = "SELECT * FROM ayudantia,ramo WHERE ayudantia.id_Ramo=ramo.id AND ramo.RUT_Profesor='" + LblRutProfesor.Content + "'";


            MySqlDataReader Leer2 = Consulta2.ExecuteReader();

            var ListaRamosAyudantias = new List<Ayudantia>();


            while (Leer2.Read())
            {

                if (Convert.ToDateTime(Leer2.GetValue(3)) >= DateTime.Now)
                {

                    var Ayudantia1 = new Ayudantia();
                    Ayudantia1.ID = Convert.ToInt32(Leer2.GetValue(0));
                    Ayudantia1.NombreRamo = Leer2.GetValue(2).ToString();
                    Ayudantia1.Fecha = Convert.ToDateTime(Leer2.GetValue(3));

                    ListaRamosAyudantias.Add(Ayudantia1);


                }


            }

            LstRamosAyudantias.ItemsSource = ListaRamosAyudantias;



            ConexionDataBase.Close();



        }

        private void BtnEliminarAyudantia_Click(object sender, RoutedEventArgs e)
        {
            MySqlConnection ConexionDataBase = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=sistema_seguimiento");
            ConexionDataBase.Open();

            if (LstRamosAyudantias.SelectedItem != null)
            {

                var Ramo1 = (Ayudantia)LstRamosAyudantias.SelectedItem;


                string Query = "DELETE FROM ayudantia WHERE ayudantia.id = " + Ramo1.ID + "";

                MySqlCommand CargarNota = new MySqlCommand(Query, ConexionDataBase);

                CargarNota.ExecuteNonQuery();

                ConexionDataBase.Close();





            }
            else
            {

                MessageBox.Show("Debe seleccionar algun ramo y tomar mejores deciciones en la vida ");

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
    }
}
