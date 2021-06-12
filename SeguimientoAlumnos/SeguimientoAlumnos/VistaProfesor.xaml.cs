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
        public List<Alumno_Por_Ramo> ListaAlumnos { get; set; }

        public Profesor ProfeAux = new Profesor();
        public VistaProfesor(Profesor Profe)
        {
            InitializeComponent();
            LblNombreProfesor.Content = Profe.Nombre;
            LblRutProfesor.Content = Profe.RUT;
           

            var ListaRamosAyudantias = new List<Ayudantia>();

           
                LstRamosDados.ItemsSource = Profe.ListaRamosDados;
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

            var ListaAlumnosRamo = new List<Alumno_Por_Ramo>();

            var Profe2 = ProfeAux;

            if (LstRamosDados.SelectedItem != null)
            {

            var RamoLsv = (Ramo)LstRamosDados.SelectedItem;

            foreach (var Ramo1 in Profe2.ListaRamosDados)
            {
                if (Ramo1.ID == RamoLsv.ID)
                {
                foreach (var Alumno1 in Ramo1.ListaAlumnos)
                {

                    ListaAlumnosRamo.Add(Alumno1);

                }
                }

            }

            LstAlumnosInscritos.ItemsSource = ListaAlumnosRamo;

            }


        }

        private void BtnMostrarNotas_Click(object sender, RoutedEventArgs e)
        {
            var ListaModificacionesNota = new List<string>();
            var ListaNotas = new List<Nota>();
            MySqlConnection ConexionDataBase = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=sistema_seguimiento");
            ConexionDataBase.Open();
            MySqlCommand ConsultaNotas = new MySqlCommand();
            ConsultaNotas.Connection = ConexionDataBase;

            if (LstAlumnosInscritos.SelectedItem != null)
            {

                var Persona1 = new Alumno_Por_Ramo();

                Persona1 = (Alumno_Por_Ramo)LstAlumnosInscritos.SelectedItem;

                var Ramo1 = new Ramo();
                Ramo1 = (Ramo)LstRamosDados.SelectedItem;

                ConsultaNotas.CommandText = ("SELECT * FROM nota,alumno_por_ramo,ramo WHERE nota.Id_Alumno_Por_Ramo = alumno_por_ramo.id AND ramo.id = alumno_por_ramo.id_Ramo AND ramo.Codigo = '"+ Ramo1.Codigo +"' AND ramo.Seccion = "+ Ramo1.Seccion +" AND alumno_por_ramo.RUT_Alumno ='"+Persona1.RUTAlumno+"'");
                MySqlDataReader LeerNotas = ConsultaNotas.ExecuteReader();

               
                while (LeerNotas.Read())
                {

                    var Nota2 = new Nota();
                    
                    Nota2.NumeroNota = LeerNotas.GetValue(2).ToString();
                    Nota2.Puntacion = Convert.ToDouble(LeerNotas.GetValue(3));

                    ListaNotas.Add(Nota2);
                    ListaModificacionesNota.Add(Nota2.NumeroNota);

                }

                LsvNotasAlumno.ItemsSource = ListaNotas;
                CmbSeleccionarNota.ItemsSource = ListaModificacionesNota;

            }

            ConexionDataBase.Close();




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
    }
}
