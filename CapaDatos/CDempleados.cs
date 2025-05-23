using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CDempleados
    {
        Conexión cd_conexion = new Conexión();

        public DataTable MtdConsultarEmpleados()
        {
            string QueryConsultarEmpleados = "Select * from tbl_Empleados";
            SqlDataAdapter dt_adapter = new SqlDataAdapter(QueryConsultarEmpleados, cd_conexion.MtdAbrirConexion());
            DataTable dt_empleados = new DataTable();
            dt_adapter.Fill(dt_empleados);
            cd_conexion.MtdCerrarConexion();
            return dt_empleados;
        }

        public void MtdAgregarEmpleados(string Nombre, string Cargo, decimal Salario, DateTime FechaContratacion, string Estado, string UsuarioSistema, DateTime FechaSistema)
        {
            string QueryAgregarEmpleados = "Insert into tbl_Empleados(Nombre, Cargo, Salario, FechaContratacion, Estado, UsuarioSistema, FechaSistema) values (@Nombre, @Cargo, @Salario, @FechaContratacion, @Estado, @UsuarioSistema, @FechaSistema)";
            SqlCommand CommandAgregarEmpleados = new SqlCommand(QueryAgregarEmpleados, cd_conexion.MtdAbrirConexion());
            CommandAgregarEmpleados.Parameters.AddWithValue("@Nombre", Nombre);
            CommandAgregarEmpleados.Parameters.AddWithValue("@Cargo", Cargo);
            CommandAgregarEmpleados.Parameters.AddWithValue("@Salario", Salario);
            CommandAgregarEmpleados.Parameters.AddWithValue("@FechaContratacion", FechaContratacion);
            CommandAgregarEmpleados.Parameters.AddWithValue("@Estado", Estado);
            CommandAgregarEmpleados.Parameters.AddWithValue("@UsuarioSistema", UsuarioSistema);
            CommandAgregarEmpleados.Parameters.AddWithValue("@FechaSistema", FechaSistema);
            CommandAgregarEmpleados.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

        public void MtdActualizarEmpleados(int CodigoEmpleado, string Nombre, string Cargo, decimal Salario, DateTime FechaContratacion, string Estado, string UsuarioSistema, DateTime FechaSistema)
        {
            string QueryActualizarEmpleados = "Update tbl_Empleados set Nombre = @Nombre, Cargo = @Cargo, Salario = @Salario, FechaContratacion = @FechaContratacion, Estado = @Estado, UsuarioSistema = @UsuarioSistema, FechaSistema = @FechaSistema where CodigoEmpleado = @CodigoEmpleado";
            SqlCommand CommandActualizarEmpleados = new SqlCommand(QueryActualizarEmpleados, cd_conexion.MtdAbrirConexion());
            CommandActualizarEmpleados.Parameters.AddWithValue("@CodigoEmpleado", CodigoEmpleado);
            CommandActualizarEmpleados.Parameters.AddWithValue("@Nombre", Nombre);
            CommandActualizarEmpleados.Parameters.AddWithValue("@Cargo", Cargo);
            CommandActualizarEmpleados.Parameters.AddWithValue("@Salario", Salario);
            CommandActualizarEmpleados.Parameters.AddWithValue("@FechaContratacion", FechaContratacion);
            CommandActualizarEmpleados.Parameters.AddWithValue("@Estado", Estado);
            CommandActualizarEmpleados.Parameters.AddWithValue("@UsuarioSistema", UsuarioSistema);
            CommandActualizarEmpleados.Parameters.AddWithValue("@FechaSistema", FechaSistema);
            CommandActualizarEmpleados.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

        public void MtdEliminarEmpleados(int CodigoEmpleado)
        {
            string QueryEliminarEmpleados = "Delete tbl_Empleados where CodigoEmpleado = @CodigoEmpleado";
            SqlCommand CommandEliminarEmpleados = new SqlCommand(QueryEliminarEmpleados, cd_conexion.MtdAbrirConexion());
            CommandEliminarEmpleados.Parameters.AddWithValue("@CodigoEmpleado", CodigoEmpleado);
            CommandEliminarEmpleados.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }
    }
}
