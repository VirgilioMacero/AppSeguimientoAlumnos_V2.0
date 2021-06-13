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
            
            //Aqui se Carga el grafico con los datos de el Objeto AlumnoAux
            GraficoSeguimiento.Palette = ChartColorPalette.EarthTones;

            GraficoSeguimiento.Titles.Add("Notas de "+AlumnoAux.Nombre);

            foreach (var Nota in AlumnoAux.ListaNotas)
            {

                Series serie = GraficoSeguimiento.Series.Add(Nota.NumeroNota +"_"+ Nota.Fecha.ToString("MMMM dd, yyyy"));
                serie.Label = Nota.Puntacion.ToString();
                serie.Points.Add(Nota.Puntacion);

            }
            //En este apartado se Carga el Lisview de Seguimientos

            LstSeguimientos.Columns.Add("Id", 30, HorizontalAlignment.Center);
            LstSeguimientos.Columns.Add("Causa",220,HorizontalAlignment.Center);
            LstSeguimientos.Columns.Add("Fecha",180,HorizontalAlignment.Center);

            foreach (var SeguimientoAux in AlumnoAux.Seguimientos)
            {

                ListViewItem Fila = new ListViewItem(SeguimientoAux.ID.ToString());
                ListViewItem.ListViewSubItem Causa = new ListViewItem.ListViewSubItem(Fila, SeguimientoAux.Causa);
                ListViewItem.ListViewSubItem Fecha = new ListViewItem.ListViewSubItem(Fila, SeguimientoAux.Fecha.ToString("MMMM dd, yyyy"));

                Fila.SubItems.Add(Causa);
                Fila.SubItems.Add(Fecha);
                LstSeguimientos.Items.Add(Fila);
            }

            //En este apartado se Carga el ListView de ayudantias

            LstAyudantias.Columns.Add("Id", 30, HorizontalAlignment.Center);
            LstAyudantias.Columns.Add("Ramo",220,HorizontalAlignment.Center);
            LstAyudantias.Columns.Add("Fecha",180,HorizontalAlignment.Center);

            foreach (var AyudantiaAux in AlumnoAux.ListaAyudantiasInscritas)
            {

                ListViewItem Fila = new ListViewItem(AyudantiaAux.ID.ToString());
                ListViewItem.ListViewSubItem Nombre = new ListViewItem.ListViewSubItem(Fila, AyudantiaAux.NombreRamo);
                ListViewItem.ListViewSubItem Fecha = new ListViewItem.ListViewSubItem(Fila, AyudantiaAux.Fecha.ToString("MMMM dd, yyyy"));

                Fila.SubItems.Add(Nombre);
                Fila.SubItems.Add(Fecha);
                LstAyudantias.Items.Add(Fila);
            }


        }

        private void LstSeguimientos_SelectedIndexChanged(object sender, EventArgs e)
        {

                if (LstSeguimientos.SelectedItems.Count > 0)
                {
                    ListViewItem listItem = LstSeguimientos.SelectedItems[0];
                    int  Id = Convert.ToInt32(listItem.Text);


                foreach (var SeguimientoAux in AlumnoAux.Seguimientos)
                {
                    if (SeguimientoAux.ID == Id)
                    {
                        TxtLeerMensaje.Text = string.Empty;

                        TxtLeerMensaje.Text = SeguimientoAux.Mensaje;

                    }

                }

                }

            LstSeguimientos.SelectedItems.Clear();

        }
    }
}
