using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TareaServiceWebRole
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DepartamentosService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select DepartamentosService.svc or DepartamentosService.svc.cs at the Solution Explorer and start debugging.
    public class DepartamentosService : IDepartamentosService
    {
        TareaDataClassesDataContext data = new TareaDataClassesDataContext();
        public bool agregarNuevoDepartamento(departamento nuevoDepartamento)
        {
            try
            {
                data.departamentos.InsertOnSubmit(nuevoDepartamento);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool eliminarDepartamento(int departamentoID)
        {
            try
            {
                departamento departamentoParaBorrar = (from departamento in data.departamentos
                                               where departamento.idDepto == departamentoID
                                               select departamento).Single();
                data.departamentos.DeleteOnSubmit(departamentoParaBorrar);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool modificarDepartamento(departamento nuevoDepartamento)
        {
            try
            {
                departamento departamentoParaModificar = (from departamento in data.departamentos
                                                  where departamento.idDepto == nuevoDepartamento.idDepto
                                                  select departamento).Single();
                departamentoParaModificar.nbrDepto = nuevoDepartamento.nbrDepto;
                departamentoParaModificar.idEncargado = nuevoDepartamento.idEncargado;
                departamentoParaModificar.ubicacion = nuevoDepartamento.ubicacion;
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public departamento getDepartamento(int idDepto)
        {
            try
            {
                return (from departamento in data.departamentos
                        where departamento.idDepto == idDepto
                        select departamento).Single();
            }
            catch
            {
                return null;
            }
        }

        public List<departamento> getDepartamentos()
        {
            try
            {
                return (from departamentos in data.departamentos
                        select departamentos).ToList();
            }
            catch
            {
                return null;
            }
        }

        /*
        CREATE PROCEDURE proyecto.SP_getEmpleadosDepartamentoAno
        AS
        SELECT 
            case when (YEAR(fechaIngreso)) is null then 'Total' else str(YEAR(fechaIngreso)) end as ano,
            case when (idDepto) is null then 'Total' else str(idDepto) end as idDepto,
            COUNT(YEAR(fechaIngreso)) AS cantEmpleados
        FROM proyecto.Empleados 
        GROUP BY GROUPING SETS ((idDepto,YEAR(fechaIngreso)),(idDepto),())
        GO
        */
        public List<departamento> getEstadisticas()
        {
            try
            {
                var TareaData = new TareaDataClassesDataContext();
                var query = TareaData.SP_getEmpleadosDepartamentoAno();
                List<departamento> respuesta = new List<departamento>();

                foreach (var c in query)
                {
                    departamento departamentoNuevo = new departamento();
                    departamentoNuevo.idEncargado = c.ano.Value;
                    departamentoNuevo.nbrDepto = c.cantEmpleados.ToString();
                    departamentoNuevo.idDepto = c.idDepto.Value;
                    
                    respuesta.Add(departamentoNuevo);
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
