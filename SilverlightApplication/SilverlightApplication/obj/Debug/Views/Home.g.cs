﻿#pragma checksum "C:\Users\kevem94\documents\visual studio 2013\Projects\SilverlightApplication\SilverlightApplication\Views\Home.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "BFB974CB7F8948C4109471523C71B147"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace SilverlightApplication {
    
    
    public partial class Home : System.Windows.Controls.Page {
        
        internal System.Windows.Controls.TextBlock HeaderText;
        
        internal System.Windows.Controls.ComboBox cmbxDepartamentosNuevoEmpleado;
        
        internal System.Windows.Controls.TextBox txtbxNombreNuevoEmpleado;
        
        internal System.Windows.Controls.Button btnCrearNuevoEmpleado;
        
        internal System.Windows.Controls.Button btnEl;
        
        internal System.Windows.Controls.CheckBox chkBxFotoNuevoEmpleado;
        
        internal System.Windows.Controls.DataGrid dtGdEmpleados;
        
        internal System.Windows.Controls.ComboBox cmBxFiltroEmpleados;
        
        internal System.Windows.Controls.Image Myimage;
        
        internal System.Windows.Controls.TextBlock HeaderText_Copy1;
        
        internal System.Windows.Controls.ComboBox cmbxEmpleadosNuevoDepartamento;
        
        internal System.Windows.Controls.TextBox txtbxNombreNuevoDepartamento;
        
        internal System.Windows.Controls.TextBox txtbxUbicacionNuevoDepartamento;
        
        internal System.Windows.Controls.Button btnCrearDepartamento;
        
        internal System.Windows.Controls.DataGrid dtGdDepartamentos;
        
        internal System.Windows.Controls.Button btnEliminarDepartamento;
        
        internal System.Windows.Controls.CheckBox chkbxEstadisticasDepartamentos;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/SilverlightApplication;component/Views/Home.xaml", System.UriKind.Relative));
            this.HeaderText = ((System.Windows.Controls.TextBlock)(this.FindName("HeaderText")));
            this.cmbxDepartamentosNuevoEmpleado = ((System.Windows.Controls.ComboBox)(this.FindName("cmbxDepartamentosNuevoEmpleado")));
            this.txtbxNombreNuevoEmpleado = ((System.Windows.Controls.TextBox)(this.FindName("txtbxNombreNuevoEmpleado")));
            this.btnCrearNuevoEmpleado = ((System.Windows.Controls.Button)(this.FindName("btnCrearNuevoEmpleado")));
            this.btnEl = ((System.Windows.Controls.Button)(this.FindName("btnEl")));
            this.chkBxFotoNuevoEmpleado = ((System.Windows.Controls.CheckBox)(this.FindName("chkBxFotoNuevoEmpleado")));
            this.dtGdEmpleados = ((System.Windows.Controls.DataGrid)(this.FindName("dtGdEmpleados")));
            this.cmBxFiltroEmpleados = ((System.Windows.Controls.ComboBox)(this.FindName("cmBxFiltroEmpleados")));
            this.Myimage = ((System.Windows.Controls.Image)(this.FindName("Myimage")));
            this.HeaderText_Copy1 = ((System.Windows.Controls.TextBlock)(this.FindName("HeaderText_Copy1")));
            this.cmbxEmpleadosNuevoDepartamento = ((System.Windows.Controls.ComboBox)(this.FindName("cmbxEmpleadosNuevoDepartamento")));
            this.txtbxNombreNuevoDepartamento = ((System.Windows.Controls.TextBox)(this.FindName("txtbxNombreNuevoDepartamento")));
            this.txtbxUbicacionNuevoDepartamento = ((System.Windows.Controls.TextBox)(this.FindName("txtbxUbicacionNuevoDepartamento")));
            this.btnCrearDepartamento = ((System.Windows.Controls.Button)(this.FindName("btnCrearDepartamento")));
            this.dtGdDepartamentos = ((System.Windows.Controls.DataGrid)(this.FindName("dtGdDepartamentos")));
            this.btnEliminarDepartamento = ((System.Windows.Controls.Button)(this.FindName("btnEliminarDepartamento")));
            this.chkbxEstadisticasDepartamentos = ((System.Windows.Controls.CheckBox)(this.FindName("chkbxEstadisticasDepartamentos")));
        }
    }
}

