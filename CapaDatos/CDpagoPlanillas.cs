using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CDpagoPlanillas
    {
        Conexión cd_conexion = new Conexión();

        public DataTable MtdConsultarPlanillas()
        {
            string QueryConsultarPlanillas = "Select * from tbl_PagoPlanillas";
            SqlDataAdapter dt_adapter = new SqlDataAdapter(QueryConsultarPlanillas, cd_conexion.MtdAbrirConexion());
            DataTable dt_planillas = new DataTable();
            dt_adapter.Fill(dt_planillas);
            cd_conexion.MtdCerrarConexion();
            return dt_planillas;
        }

        public void MtdAgregarPlanillas(int CodigoEmpleado, DateTime FechaPago, decimal Salario, decimal Bono, int HorasExtras, decimal MontoTotal, string Estado, string UsuarioSistema, DateTime FechaSistema)
        {
            string QueryAgregarPlanillas = "Insert into tbl_PagoPlanillas(CodigoEmpleado, FechaPago, Salario, Bono, HorasExtras, MontoTotal, Estado, UsuarioSistema, FechaSistema) values (@CodigoEmpleado, @FechaPago, @Salario, @Bono, @HorasExtras, @MontoTotal, @Estado, @UsuarioSistema, @FechaSistema)";
            SqlCommand CommandAgregarPlanillas = new SqlCommand(QueryAgregarPlanillas, cd_conexion.MtdAbrirConexion());
            CommandAgregarPlanillas.Parameters.AddWithValue("@CodigoEmpleado", CodigoEmpleado);
            CommandAgregarPlanillas.Parameters.AddWithValue("@FechaPago", FechaPago);
            CommandAgregarPlanillas.Parameters.AddWithValue("@Salario", Salario);
            CommandAgregarPlanillas.Parameters.AddWithValue("@Bono", Bono);
            CommandAgregarPlanillas.Parameters.AddWithValue("@HorasExtras", HorasExtras);
            CommandAgregarPlanillas.Parameters.AddWithValue("@MontoTotal", MontoTotal);
            CommandAgregarPlanillas.Parameters.AddWithValue("@Estado", Estado);
            CommandAgregarPlanillas.Parameters.AddWithValue("@UsuarioSistema", UsuarioSistema);
            CommandAgregarPlanillas.Parameters.AddWithValue("@FechaSistema", FechaSistema);
            CommandAgregarPlanillas.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

        public void MtdActualizarPlanillas(int CodigoPagoPlanilla, int CodigoEmpleado, DateTime FechaPago, decimal Salario, decimal Bono, int HorasExtras, decimal MontoTotal, string Estado, string UsuarioSistema, DateTime FechaSistema)
        {
            string QueryActualizarPlanillas = "Update tbl_PagoPlanillas set CodigoEmpleado = @CodigoEmpleado, FechaPago = @FechaPago,Salario = @Salario, Bono = @Bono, HorasExtras = @HorasExtras, MontoTotal = @MontoTotal, Estado = @Estado, UsuarioSistema = @UsuarioSistema, FechaSistema = @FechaSistema where CodigoPagoPlanilla = @CodigoPagoPlanilla";
            SqlCommand CommandActualizarPlanillas = new SqlCommand(QueryActualizarPlanillas, cd_conexion.MtdAbrirConexion());
            CommandActualizarPlanillas.Parameters.AddWithValue("@CodigoPagoPlanilla", CodigoPagoPlanilla);
            CommandActualizarPlanillas.Parameters.AddWithValue("@CodigoEmpleado", CodigoEmpleado);
            CommandActualizarPlanillas.Parameters.AddWithValue("@FechaPago", FechaPago);
            CommandActualizarPlanillas.Parameters.AddWithValue("@Salario", Salario);
            CommandActualizarPlanillas.Parameters.AddWithValue("@Bono", Bono);
            CommandActualizarPlanillas.Parameters.AddWithValue("@HorasExtras", HorasExtras);
            CommandActualizarPlanillas.Parameters.AddWithValue("@MontoTotal", MontoTotal);
            CommandActualizarPlanillas.Parameters.AddWithValue("@Estado", Estado);
            CommandActualizarPlanillas.Parameters.AddWithValue("@UsuarioSistema", UsuarioSistema);
            CommandActualizarPlanillas.Parameters.AddWithValue("@FechaSistema", FechaSistema);
            CommandActualizarPlanillas.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

        public void MtdEliminarPlanillas(int CodigoPagoPlanilla)
        {
            string QueryEliminarPlanillas = "Delete tbl_Empleados where CodigoPagoPlanilla = @CodigoPagoPlanilla";
            SqlCommand CommandEliminarPlanillas = new SqlCommand(QueryEliminarPlanillas, cd_conexion.MtdAbrirConexion());
            CommandEliminarPlanillas.Parameters.AddWithValue("@CodigoPagoPlanilla", CodigoPagoPlanilla);
            CommandEliminarPlanillas.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }
    }
}
