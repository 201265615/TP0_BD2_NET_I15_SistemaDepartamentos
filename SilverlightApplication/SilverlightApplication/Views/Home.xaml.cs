using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SilverlightApplication
{
    public partial class Home : Page
    {
        public OpenFileDialog fileDialog = null; //dialogo para subir imagen
        EmpleadosServiceReference.EmpleadosServiceClient proxyEmpleados = new EmpleadosServiceReference.EmpleadosServiceClient(); //se crea el objeto del servicio
        DepartamentosServiceReference.DepartamentosServiceClient proxyDepartamentos = new DepartamentosServiceReference.DepartamentosServiceClient(); //se crea el objeto del servicio
        public Home()
        {
            
            InitializeComponent();
            cargarDatos();


        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        //Carga los datos en la parte grafica al momento de iniciar 
        private void cargarDatos()
        {
            //Departamentos
            proxyDepartamentos.getDepartamentosCompleted += proxyDepartamentos_getDepartamentosCompleted;
            proxyDepartamentos.getDepartamentosAsync();


            //Empleados
            var proxyEmpleados = new EmpleadosServiceReference.EmpleadosServiceClient();
            proxyEmpleados.getEmpleadosCompleted += proxyEmpleados_getEmpleadosCompleted;
            proxyEmpleados.getEmpleadosAsync();
            
        }

        //Cargar datos en itemsources
        private void proxyEmpleados_getEmpleadosCompleted(object sender, EmpleadosServiceReference.getEmpleadosCompletedEventArgs e)
        {
            
            cmbxEmpleadosNuevoDepartamento.ItemsSource = e.Result;
            dtGdEmpleados.ItemsSource = e.Result;
        }

        //Cargar datos en itemsources
        void proxyDepartamentos_getDepartamentosCompleted(object sender, DepartamentosServiceReference.getDepartamentosCompletedEventArgs e)
        {
            
            cmbxDepartamentosNuevoEmpleado.ItemsSource = e.Result;
            dtGdDepartamentos.ItemsSource = e.Result;

            SilverlightApplication.DepartamentosServiceReference.departamento depto = new SilverlightApplication.DepartamentosServiceReference.departamento();

            depto.nbrDepto = "Todos los departamentos";// creo objeto tipo departamento
            List<SilverlightApplication.DepartamentosServiceReference.departamento> listaDepartamentos = e.Result.ToList();//convertir en lista
            listaDepartamentos.Insert(0, depto); //insertar nuevo objeto
            cmBxFiltroEmpleados.ItemsSource = listaDepartamentos;//enviar informacion al combobox de filtro
        }


        //Crear nuevo departamento
        private void btnCrearDepartamento_Click(object sender, RoutedEventArgs e)
        {
            if (txtbxNombreNuevoDepartamento.Text != "" && txtbxUbicacionNuevoDepartamento.Text != "")
            {
                //Crear objeto de tipo departamento para enviarlo al webService de forma asincronica
                SilverlightApplication.DepartamentosServiceReference.departamento nuevoDepartamento = new SilverlightApplication.DepartamentosServiceReference.departamento();

                nuevoDepartamento.nbrDepto = txtbxNombreNuevoDepartamento.Text;


                //si no hay encargado entonces no lo envia
                if (cmbxEmpleadosNuevoDepartamento.SelectedIndex >= 0)
                {
                    nuevoDepartamento.idEncargado = Int32.Parse(cmbxEmpleadosNuevoDepartamento.SelectedValue.ToString());
                }
                nuevoDepartamento.ubicacion = txtbxUbicacionNuevoDepartamento.Text;

                proxyDepartamentos.agregarNuevoDepartamentoAsync(nuevoDepartamento); //envia el objeto de tipo departamento al webService

                cargarDatos();
                cargarDatos();
            }
            else
            {
                //msj de error
            }
   
        }


        //Edita las filas dentro del datagrid
        private void dtGdDepartamentos_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                //Crear objeto de tipo departamento para enviarlo al webService de forma asincronica
                SilverlightApplication.DepartamentosServiceReference.departamento departamentoParaEditar = e.Row.DataContext as SilverlightApplication.DepartamentosServiceReference.departamento;
               
                proxyDepartamentos.modificarDepartamentoAsync(departamentoParaEditar); //envia el objeto de tipo departamento al webService
            }
        }


        //Eliminar departamento
        private void btnEliminarDepartamento_Click(object sender, RoutedEventArgs e)
        {
            if (dtGdDepartamentos.SelectedItem != null)
            {
                //Crear objeto de tipo departamento para enviarlo al webService de forma asincronica
                SilverlightApplication.DepartamentosServiceReference.departamento departamentoParaEliminar = dtGdDepartamentos.SelectedItem as SilverlightApplication.DepartamentosServiceReference.departamento;

                proxyDepartamentos.eliminarDepartamentoAsync(departamentoParaEliminar.idDepto); //envia el objeto de tipo departamento al webService
                cargarDatos();
                cargarDatos();
            }
            else
            {
                //aqui puede ir msj de error
            }

        }


        //Edita las filas dentro del datagrid
        private void dtGdEmpleados_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                //Crear objeto de tipo departamento para enviarlo al webService de forma asincronica
                SilverlightApplication.EmpleadosServiceReference.empleado empleadoParaEditar = e.Row.DataContext as SilverlightApplication.EmpleadosServiceReference.empleado;

                proxyEmpleados.modificarEmpleadoAsync(empleadoParaEditar); //envia el objeto de tipo departamento al webService
            }
        }


        //Crear empleado
        private void btnCrearNuevoEmpleado_Click(object sender, RoutedEventArgs e)
        {
            //Crear objeto de tipo empleado para enviarlo al webService de forma asincronica
            SilverlightApplication.EmpleadosServiceReference.empleado nuevoEmpleado = new SilverlightApplication.EmpleadosServiceReference.empleado();
                
            if (txtbxNombreNuevoEmpleado.Text != "")
            {
                //Para subir imagen
                //Si selecciona imagen, entonces pide que suba la imagen
                if (chkBxFotoNuevoEmpleado.IsChecked.Value)
                {
	                OpenFileDialog openFileDialog = new OpenFileDialog();
	                openFileDialog.Filter = "JPEG files|*.jpg";

	                bool? IsSelected = openFileDialog.ShowDialog();

	                if (IsSelected == true)
	                {
		                BitmapImage bitImage = new BitmapImage();
		                bitImage.SetSource(openFileDialog.File.OpenRead());

		                //Image1 is object of Image
		                Myimage.Source = bitImage;
	                }
                
                }

                
                nuevoEmpleado.nbrEmpleado = txtbxNombreNuevoEmpleado.Text;

                //si no hay encargado entonces no lo envia
                if (cmbxDepartamentosNuevoEmpleado.SelectedIndex >= 0)
                {
                    nuevoEmpleado.idDepto = Int32.Parse(cmbxDepartamentosNuevoEmpleado.SelectedValue.ToString());
                }

                proxyEmpleados.agregarNuevoEmpleadoAsync(nuevoEmpleado); //envia el objeto de tipo empleado al webService

                cargarDatos();
                cargarDatos();
            }
            else
            {
                //msj de error
            }
            
        }


        //Eliminar empleado
        private void btnEliminarEmpleado_Click(object sender, RoutedEventArgs e)
        {
            if (dtGdEmpleados.SelectedItem != null)
            {
                //Crear objeto de tipo departamento para enviarlo al webService de forma asincronica
                SilverlightApplication.EmpleadosServiceReference.empleado empleadoParaEliminar = dtGdEmpleados.SelectedItem as SilverlightApplication.EmpleadosServiceReference.empleado;

                proxyEmpleados.eliminarEmpleadoAsync(empleadoParaEliminar.idEmpleado); //envia el objeto de tipo empleado al webService
                cargarDatos();
                cargarDatos();
            }
            else
            {
                //aqui puede ir popup diciendo error
            }
            
        }

        private void cmBxFiltroEmpleados_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if (cmBxFiltroEmpleados.SelectedIndex > 0)
            {
                //Crear objeto de tipo departamento para enviarlo al webService de forma asincronica
                SilverlightApplication.EmpleadosServiceReference.empleado empleadosDepartamento = new SilverlightApplication.EmpleadosServiceReference.empleado();
                empleadosDepartamento.idDepto = Int32.Parse(cmBxFiltroEmpleados.SelectedValue.ToString());
                proxyEmpleados.getEmpleadosDepartamentoCompleted += proxyEmpleados_getEmpleadosDepartamentoCompleted;
                proxyEmpleados.getEmpleadosDepartamentoAsync(empleadosDepartamento); //envia el objeto de tipo empleado al webService
            }
            else if (cmBxFiltroEmpleados.SelectedIndex == 0)
            {
                cargarDatos();
            }
            
            
        }

        private void proxyEmpleados_getEmpleadosDepartamentoCompleted(object sender, EmpleadosServiceReference.getEmpleadosDepartamentoCompletedEventArgs e)
        {
            dtGdEmpleados.ItemsSource = e.Result;
        }

        private void chkbxEstadisticasDepartamentos_Checked(object sender, RoutedEventArgs e)
        {
            //Crear objeto de tipo departamento para enviarlo al webService de forma asincronica
            SilverlightApplication.DepartamentosServiceReference.departamento empleadosDepartamento = new SilverlightApplication.DepartamentosServiceReference.departamento();
            proxyDepartamentos.getEstadisticasCompleted += proxyDepartamentos_getEstadisticasCompleted;
            proxyDepartamentos.getEstadisticasAsync(); //envia el objeto de tipo departamentos al webService
        }

        private void proxyDepartamentos_getEstadisticasCompleted(object sender, DepartamentosServiceReference.getEstadisticasCompletedEventArgs e)
        {
            dtGdDepartamentos.ItemsSource = e.Result;
        }

        private void chkbxEstadisticasDepartamentos_Unchecked(object sender, RoutedEventArgs e)
        {
            cargarDatos();
        }


 
    }
}