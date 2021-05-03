using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows;

namespace SeguimientoAlumnos
{
    /// <summary>
    /// Lógica de interacción para VistaProfesor.xaml
    /// </summary>
    public partial class VistaProfesor : Window
    {
        public List<Ramo> ListaRamos { get; set; }
        public List<Alumno_Por_Ramo> ListaAlumnos { get; set; }

        public VistaProfesor(Profesor Profe)
        {

            InitializeComponent();

            MySqlConnection ConexionDataBase = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=sistema_seguimiento");
            ConexionDataBase.Open();
            MySqlCommand Consulta = new MySqlCommand();
            Consulta.Connection = ConexionDataBase;
            Consulta.CommandText = ("SELECT * FROM ramo , profesor WHERE Profesor_Id = profesor.id AND profesor.RUT ='" + Profe.RUT + "'");

            MySqlDataReader Leer = Consulta.ExecuteReader();

            ListaRamos = new List<Ramo>();


            if (Leer.HasRows)
            {


                while (Leer.Read())
                {




                    var Ramo1 = new Ramo();

                    Ramo1.Nombre = Leer.GetValue(1).ToString();
                    Ramo1.Codigo = Leer.GetValue(5).ToString();
                    Ramo1.Seccion = Convert.ToInt32(Leer.GetValue(6));





                    //MySqlCommand ConsultaLista = new MySqlCommand();
                    //ConsultaLista.Connection = ConexionDataBase;
                    //ConsultaLista.CommandText = ("SELECT * FROM alumno, lista_alumnos, ramo WHERE lista_alumnos.Ramo_Id = ramo.id and lista_alumnos.Ramo_Id = ramo.id and ramo.Codigo ='"+ CodigoRam + "' and ramo.Seccion ='"+ SeccRamo + "' AND lista_alumnos.Alumno_Id=alumno.id");

                    //MySqlDataReader LeerAlumnos = ConsultaLista.ExecuteReader();



                    //while (LeerAlumnos.Read())
                    //{

                    //    var Alumno2 = new Alumno_Por_Ramo();
                    //    Alumno2.Nombre = LeerAlumnos.GetValue(4).ToString();
                    //    Alumno2.RUTAlumno = LeerAlumnos.GetValue(5).ToString();

                    //    LeerAlumnos.Close();

                    //    MySqlCommand ConsultaNotas = new MySqlCommand();
                    //    ConsultaNotas.Connection = ConexionDataBase;
                    //    ConsultaNotas.CommandText = ("SELECT * FROM nota, lista_alumnos,ramo WHERE nota.Lista_Alumnos_Id = lista_alumnos.id and lista_alumnos.Ramo_Id = ramo.id AND ramo.Codigo ='"+ CodigoRam + "' and ramo.Seccion = '"+ SeccRamo + "'");

                    //    MySqlDataReader LeerNotas = ConsultaNotas.ExecuteReader();       

                    //    while (LeerNotas.Read())
                    //    {

                    //        var Nota1 = new Nota();

                    //        Nota1.Puntacion = Convert.ToDouble(LeerNotas.GetValue(1));

                    //        Alumno2.ListaNotas.Add(Nota1);

                    //    }

                    //    LeerNotas.Close();

                    //    Ramo1.ListaAlumnos.Add(Alumno2);


                    //}



                    ListaRamos.Add(Ramo1);






                }
                LstRamosDados.ItemsSource = ListaRamos;




            }
            else
            {



            }

            ConexionDataBase.Close();

        }



        private void BtnMostrarAlumnos_Click(object sender, RoutedEventArgs e)
        {
            ListaAlumnos = new List<Alumno_Por_Ramo>();


            MySqlConnection ConexionDataBase = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=sistema_seguimiento");
            ConexionDataBase.Open();
            MySqlCommand ConsultaLista = new MySqlCommand();
            ConsultaLista.Connection = ConexionDataBase;


            if (LstRamosDados.SelectedItem != null)
            {
                var Ram = new Ramo();
                Ram = (Ramo)LstRamosDados.SelectedItem;
                ConsultaLista.CommandText = ("SELECT * FROM alumno, lista_alumnos, ramo WHERE lista_alumnos.Ramo_Id = ramo.id and lista_alumnos.Ramo_Id = ramo.id and ramo.Codigo ='" + Ram.Codigo + "'  and ramo.Seccion = " + Ram.Seccion + " AND lista_alumnos.Alumno_Id=alumno.id");

                MySqlDataReader LeerAlumnos = ConsultaLista.ExecuteReader();



                while (LeerAlumnos.Read())
                {

                    var Alumno2 = new Alumno_Por_Ramo();
                    Alumno2.Nombre = LeerAlumnos.GetValue(4).ToString();
                    Alumno2.RUTAlumno = LeerAlumnos.GetValue(5).ToString();

                    ListaAlumnos.Add(Alumno2);
                }

            }
            LstAlumnosInscritos.ItemsSource = ListaAlumnos;
        }

        private void LstRamosDados_GotFocus(object sender, RoutedEventArgs e)
        {
            //ListaAlumnos = new List<Alumno_Por_Ramo>();


            //MySqlConnection ConexionDataBase = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=sistema_seguimiento");
            //ConexionDataBase.Open();
            //MySqlCommand ConsultaLista = new MySqlCommand();
            //ConsultaLista.Connection = ConexionDataBase;
            //Alumno_Por_Ramo Alumno12 = new Alumno_Por_Ramo();

            //if (LstRamosDados.SelectedItem != null)
            //{
            //    var Ram = new Ramo();
            //    Ram = (Ramo)LstRamosDados.SelectedItem;
            //    ConsultaLista.CommandText = ("SELECT * FROM alumno, lista_alumnos, ramo WHERE lista_alumnos.Ramo_Id = ramo.id and lista_alumnos.Ramo_Id = ramo.id and ramo.Codigo ='" + Ram.Codigo + "'  and ramo.Seccion = " + Ram.Seccion + " AND lista_alumnos.Alumno_Id=alumno.id");

            //    MySqlDataReader LeerAlumnos = ConsultaLista.ExecuteReader();



            //    while (LeerAlumnos.Read())
            //    {

            //        var Alumno2 = new Alumno_Por_Ramo();
            //        Alumno2.Nombre = LeerAlumnos.GetValue(4).ToString();
            //        Alumno2.RUTAlumno = LeerAlumnos.GetValue(5).ToString();

            //        ListaAlumnos.Add(Alumno2);
            //    }

            //}



            //LstAlumnosInscritos.ItemsSource = ListaAlumnos;
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

                ConsultaNotas.CommandText = ("SELECT * FROM nota, lista_alumnos,ramo,alumno WHERE nota.Lista_Alumnos_Id = lista_alumnos.id and lista_alumnos.Ramo_Id = ramo.id AND ramo.Codigo ='"+Ramo1.Codigo+"' and ramo.Seccion = "+Ramo1.Seccion+" and alumno.RUT ='"+Persona1.RUTAlumno+"'");
                MySqlDataReader LeerNotas = ConsultaNotas.ExecuteReader();

               
                while (LeerNotas.Read())
                {

                    var Nota2 = new Nota();
                    
                    Nota2.NumeroNota = LeerNotas.GetValue(1).ToString();
                    Nota2.Puntacion = Convert.ToDouble(LeerNotas.GetValue(2));

                    ListaNotas.Add(Nota2);
                    ListaModificacionesNota.Add(Nota2.NumeroNota);

                }

                LsvNotasAlumno.ItemsSource = ListaNotas;
                CmbSeleccionarNota.ItemsSource = ListaModificacionesNota;

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





        }

        private void BtnSubirPuntuacion_Click(object sender, RoutedEventArgs e)
        {





        }
    }
}
