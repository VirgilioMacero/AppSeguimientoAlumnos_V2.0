using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MySql.Data.MySqlClient;
using Clases;

namespace SeguimientoAlumnos
{
    public partial class VistaGrafico : Form
    {
        private Alumno_Por_Ramo AlumnoAux = new Alumno_Por_Ramo();
        public VistaGrafico(Alumno_Por_Ramo Alumno1)
        {
            InitializeComponent();

            AlumnoAux = Alumno1;
        }

        private void VistaGrafico_Load(object sender, EventArgs e)
        {
            

            GraficoSeguimiento.Palette = ChartColorPalette.EarthTones;

            GraficoSeguimiento.Titles.Add("Notas de "+AlumnoAux.Nombre);

            foreach (var Nota in AlumnoAux.ListaNotas)
            {

                Series serie = GraficoSeguimiento.Series.Add(Nota.NumeroNota +"_"+ Nota.Fecha.ToString("MMMM dd, yyyy"));
                serie.Label = Nota.Puntacion.ToString();
                serie.Points.Add(Nota.Puntacion);

            }


        }
    }
}
