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
    /// Lógica de interacción para VistaAlumno.xaml
    /// </summary>
    public partial class VistaAlumno : Window
    {
        public VistaAlumno(Alumno Alumnito2)
        {
            InitializeComponent();


            var Alumnito = new Alumno(Alumnito2);

            LblNombreAlumno.Content = Alumnito.Nombre;


        }
    }
}
