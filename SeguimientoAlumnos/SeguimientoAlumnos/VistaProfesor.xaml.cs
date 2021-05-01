using MySql.Data.MySqlClient;
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

namespace SeguimientoAlumnos
{
    /// <summary>
    /// Lógica de interacción para VistaProfesor.xaml
    /// </summary>
    public partial class VistaProfesor : Window
    {
        public List<Ramo> ListaRamos { get; set; }
        public VistaProfesor(Profesor Profe)
        {

            

            MySqlConnection ConexionDataBase = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=sistema_seguimiento");
            ConexionDataBase.Open();
            MySqlCommand Consulta = new MySqlCommand();
            Consulta.Connection = ConexionDataBase;
            Consulta.CommandText = ("SELECT * FROM ramo , profesor WHERE Profesor_Id = profesor.id AND profesor.RUT ='"+ Profe.RUT +"'");

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
                DataContext = this;
                    
               


            }
            else
            {

                

            }



            InitializeComponent();

        }

    }
}
