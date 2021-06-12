using MySql.Data.MySqlClient;
using System.Windows;
using Clases;
namespace SeguimientoAlumnos
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
   

        public MainWindow()
        {
            InitializeComponent();

        }

        private void BtnIniciarProfesor_Click(object sender, RoutedEventArgs e)
        {


            var Profesor1 = new Profesor();
            
            var Inicio = Profesor1.Inicio_Sesion_Profesor("select * FROM profesor where RUT ='" + this.TxtUsuarioProfesor.Text + "' and Contrasenia ='" + this.TxtContraseniaProfesor.Text + " ' ");

            if (Inicio != null)
            {

                VistaProfesor VistaProfe = new VistaProfesor(Inicio);

                VistaProfe.Show();

            }
            else
            {

                MessageBox.Show("Algun dato esta mal introducido");

            }

            


           

        }

        private void BtnIniciarAlumno_Click(object sender, RoutedEventArgs e)
        {

            var Conexion1 = new Conexion();
            Conexion1.NombreConexion = "InicioSeseionAlumno";
            var Inicio = Conexion1.Inicio_Sesion_Alumno("select * FROM alumno where RUT ='" + this.TxtUsuarioAlumno.Text + "' and Contrasenia ='" + this.TxtContraseniaAlumno.Text + " ' ");



            if (Inicio != null)
            {

                VistaAlumno_v2 VistaAlumno1 = new VistaAlumno_v2(Inicio);

                VistaAlumno1.Show();
            }
            else
            {
                MessageBox.Show("Hay algun dato mal ingresado");
            }


        }
    }
}
