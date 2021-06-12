using MySql.Data.MySqlClient;

namespace SeguimientoAlumnos
{
    partial class VistaGrafico
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.GraficoSeguimiento = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.GraficoSeguimiento)).BeginInit();
            this.SuspendLayout();
            // 
            // GraficoSeguimiento
            // 
            chartArea1.Name = "ChartArea1";
            this.GraficoSeguimiento.ChartAreas.Add(chartArea1);
            this.GraficoSeguimiento.DataSource = this.GraficoSeguimiento.Titles;
            legend1.Name = "Legend1";
            this.GraficoSeguimiento.Legends.Add(legend1);
            this.GraficoSeguimiento.Location = new System.Drawing.Point(1, 1);
            this.GraficoSeguimiento.Name = "GraficoSeguimiento";
            this.GraficoSeguimiento.Size = new System.Drawing.Size(516, 426);
            this.GraficoSeguimiento.TabIndex = 0;
            this.GraficoSeguimiento.Text = "Grafico Seguimiento";
            title1.Name = "titulo 1";
            this.GraficoSeguimiento.Titles.Add(title1);
            // 
            // VistaGrafico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 427);
            this.Controls.Add(this.GraficoSeguimiento);
            this.Name = "VistaGrafico";
            this.Text = "Grafico de Seguimiento";
            this.Load += new System.EventHandler(this.VistaGrafico_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GraficoSeguimiento)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart GraficoSeguimiento;
    }
}