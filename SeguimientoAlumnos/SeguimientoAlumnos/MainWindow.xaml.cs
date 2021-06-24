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
            
            var Inicio = Profesor1.Inicio_Sesion_Profesor(TxtUsuarioProfesor.Text,TxtContraseniaProfesor.Password);

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
           
            var Inicio = Alumnno1.Inicio_Sesion_Alumno(TxtUsuarioAlumno.Text,TxtContraseniaAlumno.Password);



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

        private void BtnIniciarAdmin_Click(object sender, RoutedEventArgs e)
        {


            var Admin1 = new Administrador();
            var Admin2 = new Administrador();
            Admin2 = Admin1.Inicio_SesionAdministrador(TxtUsuarioAdministrador.Text,TxtContraseniaAdmin.Password);


            if (Admin2 != null)
            {

                var VentanaAdmin = new VistaAdministrador(Admin2);

                VentanaAdmin.Show();

            }
            else
            {
                MessageBox.Show("Algun Dato Esta Mal ingresado");
            }



        }

        private void BtnMostrarClaveAlumno_Click(object sender, RoutedEventArgs e)
        {

            if (BtnMostrarClaveAlumno.Content.ToString() == "Mostrar")
            {
            LblContraseniaVisible_Alumno.Content = TxtContraseniaAlumno.Password;
                BtnMostrarClaveAlumno.Content = "Ocultar";
                TxtContraseniaAlumno.Focus();
            }
            else
            {
                LblContraseniaVisible_Alumno.Content = string.Empty;
                BtnMostrarClaveAlumno.Content = "Mostrar" ;
                TxtContraseniaAlumno.Focus();
            }

        }

        private void TxtContraseniaAlumno_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (BtnMostrarClaveAlumno.Content.ToString() != "Mostrar")
            {
                LblContraseniaVisible_Alumno.Content = TxtContraseniaAlumno.Password;
              
            }
            else
            {
                LblContraseniaVisible_Alumno.Content = string.Empty;
                
            }


        }

        private void BtnMostrarClaveProfesor_Click(object sender, RoutedEventArgs e)
        {

            if (BtnMostrarClaveProfesor.Content.ToString() == "Mostrar")
            {
                LblContraseniaVisible_Profesor.Content = TxtContraseniaProfesor.Password;
                BtnMostrarClaveProfesor.Content = "Ocultar";
                TxtContraseniaProfesor.Focus();

            }
            else
            {
                LblContraseniaVisible_Profesor.Content = string.Empty;
                BtnMostrarClaveProfesor.Content = "Mostrar";
                TxtContraseniaProfesor.Focus();
            }



        }

        private void TxtContraseniaProfesor_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (BtnMostrarClaveProfesor.Content.ToString() != "Mostrar")
            {
                LblContraseniaVisible_Profesor.Content = TxtContraseniaProfesor.Password;
            }
            else
            {
                LblContraseniaVisible_Profesor.Content = string.Empty;
            }


        }

        private void BtnMostrarClaveAdministrador_Click(object sender, RoutedEventArgs e)
        {

            if (BtnMostrarClaveAdministrador.Content.ToString() == "Mostrar")
            {
                LblContraseniaVisible_Administrador.Content = TxtContraseniaAdmin.Password;
                BtnMostrarClaveAdministrador.Content = "Ocultar";
                TxtContraseniaAdmin.Focus();

            }
            else
            {
                LblContraseniaVisible_Administrador.Content = string.Empty;
                BtnMostrarClaveAdministrador.Content = "Mostrar";
                TxtContraseniaAdmin.Focus();
            }


        }

        private void TxtContraseniaAdmin_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (BtnMostrarClaveAdministrador.Content.ToString() != "Mostrar")
            {
                LblContraseniaVisible_Administrador.Content = TxtContraseniaAdmin.Password;
            }
            else
            {
                LblContraseniaVisible_Administrador.Content = string.Empty;
            }
        }
    }
}
