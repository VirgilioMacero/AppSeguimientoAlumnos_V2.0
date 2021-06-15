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
        //En este apartado se ingresan los datos del inicio de sesion del profesor
        private void BtnIniciarProfesor_Click(object sender, RoutedEventArgs e)
        {


            var Profesor1 = new Profesor();
            
            var Inicio = Profesor1.Inicio_Sesion_Profesor("select * FROM profesor where RUT ='" + this.TxtUsuarioProfesor.Text + "' and Contrasenia ='" + this.TxtContraseniaProfesor.Password + " ' ");

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
        //En este Apartado se ingresan los datos de inicio de sesion del Alumno
        private void BtnIniciarAlumno_Click(object sender, RoutedEventArgs e)
        {

            var Alumnno1 = new Alumno();
           
            var Inicio = Alumnno1.Inicio_Sesion_Alumno("select * FROM alumno where RUT ='" + this.TxtUsuarioAlumno.Text + "' and Contrasenia ='" + this.TxtContraseniaAlumno.Password + " ' ");



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
