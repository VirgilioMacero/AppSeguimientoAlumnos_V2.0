﻿#pragma checksum "..\..\VistaAlumno.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "45C4F3C36D6DD462AD5337096AAA413202E8619B18A27BD851A06A92868E3C93"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using SeguimientoAlumnos;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace SeguimientoAlumnos {
    
    
    /// <summary>
    /// VistaAlumno
    /// </summary>
    public partial class VistaAlumno : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\VistaAlumno.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LblNombreAlumno;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\VistaAlumno.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView LstRamosActuales;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\VistaAlumno.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnMostrarNotas;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\VistaAlumno.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView LstMostarNotas;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\VistaAlumno.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView LstNotificaciones;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\VistaAlumno.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TxtBNotificacion;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/SeguimientoAlumnos;component/vistaalumno.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\VistaAlumno.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.LblNombreAlumno = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.LstRamosActuales = ((System.Windows.Controls.ListView)(target));
            return;
            case 3:
            this.BtnMostrarNotas = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\VistaAlumno.xaml"
            this.BtnMostrarNotas.Click += new System.Windows.RoutedEventHandler(this.BtnMostrarNotas_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.LstMostarNotas = ((System.Windows.Controls.ListView)(target));
            return;
            case 5:
            this.LstNotificaciones = ((System.Windows.Controls.ListView)(target));
            return;
            case 6:
            this.TxtBNotificacion = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
