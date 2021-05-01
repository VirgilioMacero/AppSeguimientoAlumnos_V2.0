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


                    //string Codigo = (Leer.GetValue(5)).ToString()+"-"+(Leer.GetValue(6)).ToString();
                    var Ramo1 = new Ramo();


                    Ramo1.Codigo = Leer.GetValue(5).ToString();

                    Ramo1.Seccion = Convert.ToInt32(Leer.GetValue(6));



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
