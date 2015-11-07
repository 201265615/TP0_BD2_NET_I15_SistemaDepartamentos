using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TareaServiceWebRole
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EmpleadosService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EmpleadosService.svc or EmpleadosService.svc.cs at the Solution Explorer and start debugging.
    public class EmpleadosService : IEmpleadosService
    {
        TareaDataClassesDataContext data = new TareaDataClassesDataContext();
        public bool agregarNuevoEmpleado(empleado nuevoEmpleado)
        {
            try
            {
                nuevoEmpleado.fechaIngreso = DateTime.Now;
                data.empleados.InsertOnSubmit(nuevoEmpleado);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool eliminarEmpleado(int empleadoID)
        {
            try
            {
                empleado empleadoParaBorrar = (from empleado in data.empleados
                                             where empleado.idEmpleado == empleadoID
                                             select empleado).Single();
                data.empleados.DeleteOnSubmit(empleadoParaBorrar);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool modificarEmpleado(empleado nuevoEmpleado)
        {
            try
            {
                empleado empleadoParaModificar = (from empleado in data.empleados
                                             where empleado.idEmpleado == nuevoEmpleado.idEmpleado
                                             select empleado).Single();
                empleadoParaModificar.nbrEmpleado = nuevoEmpleado.nbrEmpleado;
                empleadoParaModificar.idDepto = nuevoEmpleado.idDepto;
                empleadoParaModificar.fechaIngreso = nuevoEmpleado.fechaIngreso;
                empleadoParaModificar.foto = nuevoEmpleado.foto;
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<empleado> getEmpleados()
        {
            try
            {
                return (from empleado in data.empleados
                        select empleado).ToList();
            }
            catch
            {
                return null;
            }
        }

        /*
        CREATE PROCEDURE proyecto.SP_getEmpleadosDepartamento @pIdDepto int
        AS
        SELECT idEmpleado, nbrEmpleado, idDepto, fechaIngreso, foto
        FROM proyecto.Empleados
        WHERE idDepto= @pIdDepto
        GO
        */
        public List<empleado> getEmpleadosDepartamento(empleado buscarEmpleado)
        {
            try
            {
                var TareaData = new TareaDataClassesDataContext();
                var query = TareaData.SP_getEmpleadosDepartamento(buscarEmpleado.idDepto);
                List<empleado> respuesta = new List<empleado>();
                
                foreach (var c in query)
                {
                    empleado empleadoNuevo = new empleado();
                    empleadoNuevo.idEmpleado = c.idEmpleado;
                    empleadoNuevo.nbrEmpleado = c.nbrEmpleado;
                    empleadoNuevo.idDepto = c.idDepto;
                    empleadoNuevo.fechaIngreso = c.fechaIngreso;
                    empleadoNuevo.foto = c.foto;
                    respuesta.Add(empleadoNuevo);
                }
                return respuesta;
            }
            catch
            {
                return null;
            }
        }
    }
}