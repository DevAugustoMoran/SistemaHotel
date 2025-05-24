using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CDasignaciones
    {
        Conexión cd_conexion = new Conexión();

        public DataTable MtdConsultarAsignaciones()
        {
            string QueryConsultarAsignaciones = "Select * from tbl_Asignaciones";
            SqlDataAdapter dt_adapter = new SqlDataAdapter(QueryConsultarAsignaciones, cd_conexion.MtdAbrirConexion());
            DataTable dt_asignaciones = new DataTable();
            dt_adapter.Fill(dt_asignaciones);
            cd_conexion.MtdCerrarConexion();
            return dt_asignaciones;
        }

        public void MtdAgregarAsignaciones(int CodigoEmpleado, int CodigoHabitacion, string TipoAsignacion, DateTime FechaAsignacion, string Estado, string UsuarioSistema, DateTime FechaSistema)
        {
            string QueryAgregarAsignaciones = "Insert into tbl_Asignaciones(CodigoEmpleado, CodigoHabitacion, TipoAsignacion, FechaAsignacion, Estado, UsuarioSistema, FechaSistema) values (@CodigoEmpleado, @CodigoHabitacion, @TipoAsignacion, @FechaAsignacion, @Estado, @UsuarioSistema, @FechaSistema)";
            SqlCommand CommandAgregarAsignaciones = new SqlCommand(QueryAgregarAsignaciones, cd_conexion.MtdAbrirConexion());
            CommandAgregarAsignaciones.Parameters.AddWithValue("@CodigoEmpleado", CodigoEmpleado);
            CommandAgregarAsignaciones.Parameters.AddWithValue("@CodigoHabitacion", CodigoHabitacion);
            CommandAgregarAsignaciones.Parameters.AddWithValue("@TipoAsignacion", TipoAsignacion);
            CommandAgregarAsignaciones.Parameters.AddWithValue("@FechaAsignacion", FechaAsignacion);
            CommandAgregarAsignaciones.Parameters.AddWithValue("@Estado", Estado);
            CommandAgregarAsignaciones.Parameters.AddWithValue("@UsuarioSistema", UsuarioSistema);
            CommandAgregarAsignaciones.Parameters.AddWithValue("@FechaSistema", FechaSistema);
            CommandAgregarAsignaciones.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

        public void MtdActualizarAsignaciones(int CodigoAsignacion, int CodigoEmpleado, int CodigoHabitacion, string TipoAsignacion, DateTime FechaAsignacion, string Estado, string UsuarioSistema, DateTime FechaSistema)
        {
            string QueryActualizarAsignaciones = "Update tbl_Asignaciones set CodigoEmpleado = @CodigoEmpleado, CodigoHabitacion = @CodigoHabitacion, TipoAsignacion = @TipoAsignacion, FechaAsignacion = @FechaAsignacion, Estado = @Estado, UsuarioSistema = @UsuarioSistema, FechaSistema = @FechaSistema where CodigoAsignacion = @CodigoAsignacion";
            SqlCommand CommandActualizarAsignaciones = new SqlCommand(QueryActualizarAsignaciones, cd_conexion.MtdAbrirConexion());
            CommandActualizarAsignaciones.Parameters.AddWithValue("@CodigoAsignacion", CodigoAsignacion);
            CommandActualizarAsignaciones.Parameters.AddWithValue("@CodigoEmpleado", CodigoEmpleado);
            CommandActualizarAsignaciones.Parameters.AddWithValue("@CodigoHabitacion", CodigoHabitacion);
            CommandActualizarAsignaciones.Parameters.AddWithValue("@TipoAsignacion", TipoAsignacion);
            CommandActualizarAsignaciones.Parameters.AddWithValue("@FechaAsignacion", FechaAsignacion);
            CommandActualizarAsignaciones.Parameters.AddWithValue("@Estado", Estado);
            CommandActualizarAsignaciones.Parameters.AddWithValue("@UsuarioSistema", UsuarioSistema);
            CommandActualizarAsignaciones.Parameters.AddWithValue("@FechaSistema", FechaSistema);
            CommandActualizarAsignaciones.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

        public void MtdEliminarAsignaciones(int CodigoAsignacion)
        {
            string QueryEliminarAsignaciones = "Delete tbl_Asignaciones where CodigoAsignacion = @CodigoAsignacion";
            SqlCommand CommandEliminarAsignaciones = new SqlCommand(QueryEliminarAsignaciones, cd_conexion.MtdAbrirConexion());
            CommandEliminarAsignaciones.Parameters.AddWithValue("@CodigoAsignacion", CodigoAsignacion);
            CommandEliminarAsignaciones.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }
    }
}
