using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CDhabitaciones
    {
        Conexión cd_conexion = new Conexión();

        public DataTable MtdConsultarHabitaciones()
        {
            string QueryConsultarHabitaciones = "Select * from tbl_Habitaciones";
            SqlDataAdapter dt_adapter = new SqlDataAdapter(QueryConsultarHabitaciones, cd_conexion.MtdAbrirConexion());
            DataTable dt_habitaciones = new DataTable();
            dt_adapter.Fill(dt_habitaciones);
            cd_conexion.MtdCerrarConexion();
            return dt_habitaciones;
        }

        public void MtdAgregarHabitaciones(string Numero, string Ubicacion, string Tipo, decimal Precio, string Estado, string UsuarioSistema, DateTime FechaSistema)
        {
            string QueryAgregarHabitaciones = "Insert into tbl_Habitaciones(Numero, Ubicacion, Tipo, Precio, Estado, UsuarioSistema, FechaSistema) values (@Numero, @Ubicacion, @Tipo, @Precio, @Estado, @UsuarioSistema, @FechaSistema)";
            SqlCommand CommandAgregarHabitaciones = new SqlCommand(QueryAgregarHabitaciones, cd_conexion.MtdAbrirConexion());
            CommandAgregarHabitaciones.Parameters.AddWithValue("@Numero", Numero);
            CommandAgregarHabitaciones.Parameters.AddWithValue("@Ubicacion", Ubicacion);
            CommandAgregarHabitaciones.Parameters.AddWithValue("@Tipo", Tipo);
            CommandAgregarHabitaciones.Parameters.AddWithValue("@Precio", Precio);
            CommandAgregarHabitaciones.Parameters.AddWithValue("@Estado", Estado);
            CommandAgregarHabitaciones.Parameters.AddWithValue("@UsuarioSistema", UsuarioSistema);
            CommandAgregarHabitaciones.Parameters.AddWithValue("@FechaSistema", FechaSistema);
            CommandAgregarHabitaciones.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

        public void MtdActualizarHabitaciones(int CodigoHabitacion, string Numero, string Ubicacion, string Tipo, decimal Precio, string Estado, string UsuarioSistema, DateTime FechaSistema)
        {
            string QueryActualizarHabitaciones = "Update tbl_Habitaciones set Numero = @Numero, Ubicacion = @Ubicacion, Tipo = @Tipo, Precio = @Precio, Estado = @Estado, UsuarioSistema = @UsuarioSistema, FechaSistema = @FechaSistema where CodigoHabitacion = @CodigoHabitacion";
            SqlCommand CommandActualizarHabitaciones = new SqlCommand(QueryActualizarHabitaciones, cd_conexion.MtdAbrirConexion());
            CommandActualizarHabitaciones.Parameters.AddWithValue("@CodigoHabitacion", CodigoHabitacion);
            CommandActualizarHabitaciones.Parameters.AddWithValue("@Numero", Numero);
            CommandActualizarHabitaciones.Parameters.AddWithValue("@Ubicacion", Ubicacion);
            CommandActualizarHabitaciones.Parameters.AddWithValue("@Tipo", Tipo);
            CommandActualizarHabitaciones.Parameters.AddWithValue("@Precio", Precio);
            CommandActualizarHabitaciones.Parameters.AddWithValue("@Estado", Estado);
            CommandActualizarHabitaciones.Parameters.AddWithValue("@UsuarioSistema", UsuarioSistema);
            CommandActualizarHabitaciones.Parameters.AddWithValue("@FechaSistema", FechaSistema);
            CommandActualizarHabitaciones.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

        public void MtdEliminarHabitaciones(int CodigoHabitacion)
        {
            string QueryEliminarHabitaciones = "Delete tbl_Habitaciones where CodigoHabitacion = @CodigoHabitacion";
            SqlCommand CommandEliminarHabitaciones = new SqlCommand(QueryEliminarHabitaciones, cd_conexion.MtdAbrirConexion());
            CommandEliminarHabitaciones.Parameters.AddWithValue("@CodigoHabitacion", CodigoHabitacion);
            CommandEliminarHabitaciones.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }
    }
}
