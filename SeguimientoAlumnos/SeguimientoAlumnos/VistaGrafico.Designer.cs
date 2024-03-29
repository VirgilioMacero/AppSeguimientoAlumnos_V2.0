﻿using MySql.Data.MySqlClient;

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
            this.LstSeguimientos = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtLeerMensaje = new System.Windows.Forms.TextBox();
            this.LstAyudantias = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
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
            this.GraficoSeguimiento.Size = new System.Drawing.Size(516, 502);
            this.GraficoSeguimiento.TabIndex = 0;
            this.GraficoSeguimiento.Text = "Grafico Seguimiento";
            title1.Name = "titulo 1";
            this.GraficoSeguimiento.Titles.Add(title1);
            
            // 
            // LstSeguimientos
            // 
            this.LstSeguimientos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LstSeguimientos.FullRowSelect = true;
            this.LstSeguimientos.GridLines = true;
            this.LstSeguimientos.HideSelection = false;
            this.LstSeguimientos.Location = new System.Drawing.Point(523, 41);
            this.LstSeguimientos.MultiSelect = false;
            this.LstSeguimientos.Name = "LstSeguimientos";
            this.LstSeguimientos.Size = new System.Drawing.Size(436, 161);
            this.LstSeguimientos.TabIndex = 1;
            this.LstSeguimientos.UseCompatibleStateImageBehavior = false;
            this.LstSeguimientos.View = System.Windows.Forms.View.Details;
            this.LstSeguimientos.SelectedIndexChanged += new System.EventHandler(this.LstSeguimientos_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(523, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Seguimientos";
            // 
            // TxtLeerMensaje
            // 
            this.TxtLeerMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtLeerMensaje.Location = new System.Drawing.Point(523, 197);
            this.TxtLeerMensaje.Multiline = true;
            this.TxtLeerMensaje.Name = "TxtLeerMensaje";
            this.TxtLeerMensaje.ReadOnly = true;
            this.TxtLeerMensaje.Size = new System.Drawing.Size(436, 89);
            this.TxtLeerMensaje.TabIndex = 3;
            // 
            // LstAyudantias
            // 
            this.LstAyudantias.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LstAyudantias.FullRowSelect = true;
            this.LstAyudantias.GridLines = true;
            this.LstAyudantias.HideSelection = false;
            this.LstAyudantias.Location = new System.Drawing.Point(523, 331);
            this.LstAyudantias.MultiSelect = false;
            this.LstAyudantias.Name = "LstAyudantias";
            this.LstAyudantias.Size = new System.Drawing.Size(436, 172);
            this.LstAyudantias.TabIndex = 4;
            this.LstAyudantias.UseCompatibleStateImageBehavior = false;
            this.LstAyudantias.View = System.Windows.Forms.View.Details;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(523, 299);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 29);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ayudantias";
            // 
            // VistaGrafico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 502);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LstAyudantias);
            this.Controls.Add(this.TxtLeerMensaje);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LstSeguimientos);
            this.Controls.Add(this.GraficoSeguimiento);
            this.Name = "VistaGrafico";
            this.Text = "Grafico de Seguimiento";
            this.Load += new System.EventHandler(this.VistaGrafico_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GraficoSeguimiento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart GraficoSeguimiento;
        private System.Windows.Forms.ListView LstSeguimientos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtLeerMensaje;
        private System.Windows.Forms.ListView LstAyudantias;
        private System.Windows.Forms.Label label2;
    }
}