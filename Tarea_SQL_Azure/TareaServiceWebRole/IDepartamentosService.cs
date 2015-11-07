using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TareaServiceWebRole
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDepartamentosService" in both code and config file together.
    [ServiceContract]
    public interface IDepartamentosService
    {
        [OperationContract]
        bool agregarNuevoDepartamento(departamento nuevoDepartamento);

        [OperationContract]
        bool eliminarDepartamento(int departamentoID);

        [OperationContract]
        bool modificarDepartamento(departamento nuevoDepartamento);

        [OperationContract]
        List<departamento> getDepartamentos();

        [OperationContract]
        departamento getDepartamento(int idDepto);

        [OperationContract]
        List<departamento> getEstadisticas();

    }
}
