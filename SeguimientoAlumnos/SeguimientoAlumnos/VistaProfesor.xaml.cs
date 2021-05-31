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
            LblNombreProfesor.Content = Profe.Nombre;
            LblRutProfesor.Content = Profe.RUT;
            MySqlConnection ConexionDataBase = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=sistema_seguimiento");
            ConexionDataBase.Open();
            MySqlCommand Consulta = new MySqlCommand();
            Consulta.Connection = ConexionDataBase;
            Consulta.CommandText = ("SELECT * FROM ramo,profesor WHERE ramo.RUT_Profesor=profesor.RUT and ramo.RUT_Profesor ='" + Profe.RUT + "'");

            MySqlDataReader Leer = Consulta.ExecuteReader();

            ListaRamos = new List<Ramo>();
            var ListaRamosAyudantias = new List<Ayudantia>();

            if (Leer.HasRows)
            {


                while (Leer.Read())
                {

                    var Ramo1 = new Ramo();
                    Ramo1.ID = Convert.ToInt32(Leer.GetValue(0));
                    Ramo1.Nombre = Leer.GetValue(3).ToString();
                    Ramo1.Codigo = Leer.GetValue(4).ToString();
                    Ramo1.Seccion = Convert.ToInt32(Leer.GetValue(5));

                    ListaRamos.Add(Ramo1);

                }
                LstRamosDados.ItemsSource = ListaRamos;
                LstRamosDadosAyudantias.ItemsSource = ListaRamos;
            }
            else
            {

            }

            ConexionDataBase.Close();
            ConexionDataBase.Open();
            MySqlCommand Consulta2 = new MySqlCommand();
            Consulta2.Connection = ConexionDataBase;
            Consulta2.CommandText = "SELECT * FROM ayudantia,ramo WHERE ayudantia.id_Ramo=ramo.id AND ramo.RUT_Profesor='" + Profe.RUT + "'";


            MySqlDataReader Leer2 = Consulta2.ExecuteReader();




            while (Leer2.Read())
            {
                var Ayudantia1 = new Ayudantia();
                Ayudantia1.ID = Convert.ToInt32(Leer2.GetValue(0));
                Ayudantia1.NombreRamo = Leer2.GetValue(2).ToString();
                Ayudantia1.Fecha = Convert.ToDateTime(Leer2.GetValue(3));

                ListaRamosAyudantias.Add(Ayudantia1);

            }

            LstRamosAyudantias.ItemsSource = ListaRamosAyudantias;
            


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
                ConsultaLista.CommandText = ("SELECT * FROM alumno,ramo,alumno_por_ramo WHERE alumno.RUT=alumno_por_ramo.RUT_Alumno AND alumno_por_ramo.id_Ramo=ramo.id AND ramo.Codigo='"+Ram.Codigo+"' AND ramo.Seccion ="+Ram.Seccion+"");

                MySqlDataReader LeerAlumnos = ConsultaLista.ExecuteReader();



                while (LeerAlumnos.Read())
                {

                    var Alumno2 = new Alumno_Por_Ramo();
                    Alumno2.ID= Convert.ToInt32(LeerAlumnos.GetValue(11));
                    Alumno2.Nombre = LeerAlumnos.GetValue(2).ToString();
                    Alumno2.RUTAlumno = LeerAlumnos.GetValue(0).ToString();

                    ListaAlumnos.Add(Alumno2);
                }

            }
            LstAlumnosInscritos.ItemsSource = ListaAlumnos;

            ConexionDataBase.Close();
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
