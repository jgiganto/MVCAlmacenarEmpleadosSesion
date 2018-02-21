using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAlmacenarEmpleadosSesion.Models
{
    public class ModeloHospital
    {
        ContextoHospital contexto;
        public ModeloHospital()
        {
            contexto = new ContextoHospital();
        }

        public IQueryable<EMP> GetEmpleados()
        {
            var consulta = from datos in this.contexto.EMP
                           select datos;
            return consulta;

        }
        public IQueryable<EMP> GetEmpleadosSession(List<int> empleados)
        {
            var consulta = from datos in this.contexto.EMP
                           where empleados.Contains(datos.EMP_NO)
                           select datos;
            return consulta;
        }
    }
}