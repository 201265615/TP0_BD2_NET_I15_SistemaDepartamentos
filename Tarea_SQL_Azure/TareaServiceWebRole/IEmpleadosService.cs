using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TareaServiceWebRole
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEmpleadosService" in both code and config file together.
    [ServiceContract]
    public interface IEmpleadosService
    {
        [OperationContract]
        bool agregarNuevoEmpleado(empleado nuevoEmpleado);

        [OperationContract]
        bool eliminarEmpleado(int empleadoID);

        [OperationContract]
        bool modificarEmpleado(empleado nuevoEmpleado);

        [OperationContract]
        List<empleado> getEmpleados();

        [OperationContract]
        List<empleado> getEmpleadosDepartamento(empleado buscarEmpleado);
    }
}
