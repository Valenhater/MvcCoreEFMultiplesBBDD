using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MvcCoreEFMultiplesBBDD.Data;
using MvcCoreEFMultiplesBBDD.Models;

namespace MvcCoreEFMultiplesBBDD.Repositories
{
    public class RepositoryEmpleados
    {
        private HospitalContext context;
        public RepositoryEmpleados(HospitalContext context)
        {
            this.context = context;
        }
        public async Task<List<Empleado>> GetEmpleadosAsync()
        {
            var consulta = from datos in this.context.Empleados select datos;
            return await consulta.ToListAsync();
        }
        public Empleado FindEmpleado(int idempleado)
        {
            //PARA LLAMAR A PROCEDIMIENTOS CON PARAMETROS LA LLAMADA SE REALIZA INCLUYENDO LOS PARAMETROS Y TAMBIEN EL NOMBRE DEL PROCEDURE
            //sp_procedure @param1 @param2
            string sql = "SP_FIND_EMPLEADO @idempleado";
            //PARA DECLARAR PARAMETROS SE UTILIZA LA CLASE SqlParameter
            //Cuidado con el namespace
            //el namespace es Microsoft.Data
            SqlParameter pamEmpleado = new SqlParameter("@idempleado", idempleado);
            var consulta = this.context.Empleados.FromSqlRaw(sql, pamEmpleado);
            Empleado empleado = consulta.AsEnumerable().FirstOrDefault();
            return empleado;

        }
    }
}
