using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Windows;
using System;

namespace SeguimientoAlumnos
{
    /// <summary>
    /// Lógica de interacción para VistaAlumno.xaml
    /// </summary>
    public partial class VistaAlumno : Window
    {
        public VistaAlumno(Alumno Alumnito2)
        {
            InitializeComponent();


            var Alumnito = new Alumno(Alumnito2);

            LblNombreAlumno.Content = "Bienvenido "+Alumnito.Nombre;


            MySqlConnection ConexionDataBase = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=sistema_seguimiento");
            ConexionDataBase.Open();
            MySqlCommand Consulta = new MySqlCommand();
            Consulta.Connection = ConexionDataBase;
            Consulta.CommandText = ("SELECT * FROM ramo , alumno,lista_alumnos WHERE alumno.RUT ='"+Alumnito.RUT+"' and lista_alumnos.Alumno_Id=alumno.id and lista_alumnos.Ramo_Id = ramo.id");

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

        private void BtnMostrarNotas_Click(object sender, RoutedEventArgs e)
        {

            MySqlConnection ConexionDataBase = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=sistema_seguimiento");
            ConexionDataBase.Open();
            MySqlCommand Consulta = new MySqlCommand();
            Consulta.Connection = ConexionDataBase;



            if (LstRamosActuales.SelectedItem != null)
            {

                var Ramo1 = new Ramo();
                Ramo1 = (Ramo)LstRamosActuales.SelectedItem;

            Consulta.CommandText = ("SELECT * FROM nota,ramo,lista_alumnos,alumno WHERE nota.Lista_Alumnos_Id = lista_alumnos.id and ramo.id= lista_alumnos.Ramo_Id and alumno.id=lista_alumnos.Alumno_Id and ramo.Codigo='"+Ramo1.Codigo+"' and ramo.Seccion="+Ramo1.Seccion+"");

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




        }

        private void LstRamosActuales_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}
