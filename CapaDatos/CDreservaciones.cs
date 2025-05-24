using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CDreservaciones
    {
        Conexión cd_conexion = new Conexión();

        public List<dynamic> MtdListarHuesped()
        {
            List<dynamic> ListaHuesped = new List<dynamic>();
            string QueryListaHuesped = "Select CodigoHuesped, Nombre from tbl_huespedes";
            SqlCommand cmd = new SqlCommand(QueryListaHuesped, cd_conexion.MtdAbrirConexion());
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ListaHuesped.Add(new
                {
                    Value = reader["CodigoHuesped"],
                    Text = $"{reader["CodigoHuesped"]} - {reader["Nombre"]}"
                });
            }

            cd_conexion.MtdCerrarConexion();
            return ListaHuesped;
        }

        public List<dynamic> MtdListarHabitaciones()
        {
            List<dynamic> ListaHabitaciones = new List<dynamic>();
            string QueryListaHabitaciones = "Select CodigoHabitacion, Tipo from tbl_Habitaciones";
            SqlCommand cmd = new SqlCommand(QueryListaHabitaciones, cd_conexion.MtdAbrirConexion());
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ListaHabitaciones.Add(new
                {
                    Value = reader["CodigoHabitacion"],
                    Text = $"{reader["CodigoHabitacion"]} - {reader["Tipo"]}"
                });
            }

            cd_conexion.MtdCerrarConexion();
            return ListaHabitaciones;
        }

        public Decimal MtdTotalReservacion(int CodigoHabitacion)
        {
            decimal PrecioHabitacion = 0;

            string QueryConsultarPrecioHabitacion = "Select Precio from tbl_Habitaciones where CodigoHabitacion = @CodigoHabitacion";
            SqlCommand CommandPrecioHabitacion = new SqlCommand(QueryConsultarPrecioHabitacion, cd_conexion.MtdAbrirConexion());
            CommandPrecioHabitacion.Parameters.AddWithValue("@CodigoHabitacion", CodigoHabitacion);
            SqlDataReader reader = CommandPrecioHabitacion.ExecuteReader();

            if (reader.Read())
            {
                PrecioHabitacion = decimal.Parse(reader["Precio"].ToString());
            }
            else
            {
                PrecioHabitacion = 0;
            }

            cd_conexion.MtdCerrarConexion();
            return PrecioHabitacion;
        }

        public DataTable MtdConsultarReservaciones()
        {
            string QueryConsultarReservaciones = "Select * from tbl_Reservaciones";
            SqlDataAdapter dt_adapter = new SqlDataAdapter(QueryConsultarReservaciones, cd_conexion.MtdAbrirConexion());
            DataTable dt_reservaciones = new DataTable();
            dt_adapter.Fill(dt_reservaciones);
            cd_conexion.MtdCerrarConexion();
            return dt_reservaciones;
        }

        public void MtdAgregarReservaciones(int CodigoHuesped, int CodigoHabitacion, DateTime FechaEntrada, DateTime FechaSalida, decimal Total, string UsuarioSistema, DateTime FechaSistema)
        {
            string QueryAgregarReservaciones = "Insert into tbl_Reservaciones(CodigoHuesped, CodigoHabitacion, FechaEntrada, FechaSalida, Total, UsuarioSistema, FechaSistema) values (@CodigoHuesped, @CodigoHabitacion, @FechaEntrada, @FechaSalida, @Total, @UsuarioSistema, @FechaSistema)";
            SqlCommand CommandAgregarReservaciones = new SqlCommand(QueryAgregarReservaciones, cd_conexion.MtdAbrirConexion());
            CommandAgregarReservaciones.Parameters.AddWithValue("@CodigoHuesped", CodigoHuesped);
            CommandAgregarReservaciones.Parameters.AddWithValue("@CodigoHabitacion", CodigoHabitacion);
            CommandAgregarReservaciones.Parameters.AddWithValue("@FechaEntrada", FechaEntrada);
            CommandAgregarReservaciones.Parameters.AddWithValue("@FechaSalida", FechaSalida);
            CommandAgregarReservaciones.Parameters.AddWithValue("@Total", Total);
            CommandAgregarReservaciones.Parameters.AddWithValue("@UsuarioSistema", UsuarioSistema);
            CommandAgregarReservaciones.Parameters.AddWithValue("@FechaSistema", FechaSistema);
            CommandAgregarReservaciones.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

        public void MtdActualizarReservaciones(int CodigoReserva, int CodigoHuesped, int CodigoHabitacion, DateTime FechaEntrada, DateTime FechaSalida, decimal Total, string UsuarioSistema, DateTime FechaSistema)
        {
            string QueryActualizarReservaciones = "Update tbl_Reservaciones set CodigoHuesped = @CodigoHuesped, CodigoHabitacion = @CodigoHabitacion, FechaEntrada = @FechaEntrada, FechaSalida = @FechaSalida, Total = @Total, UsuarioSistema = @UsuarioSistema, FechaSistema = @FechaSistema where CodigoReserva = @CodigoReserva";
            SqlCommand CommandActualizarReservaciones = new SqlCommand(QueryActualizarReservaciones, cd_conexion.MtdAbrirConexion());
            CommandActualizarReservaciones.Parameters.AddWithValue("@CodigoReserva", CodigoReserva);
            CommandActualizarReservaciones.Parameters.AddWithValue("@CodigoHuesped", CodigoHuesped);
            CommandActualizarReservaciones.Parameters.AddWithValue("@CodigoHabitacion", CodigoHabitacion);
            CommandActualizarReservaciones.Parameters.AddWithValue("@FechaEntrada", FechaEntrada);
            CommandActualizarReservaciones.Parameters.AddWithValue("@FechaSalida", FechaSalida);
            CommandActualizarReservaciones.Parameters.AddWithValue("@Total", Total);
            CommandActualizarReservaciones.Parameters.AddWithValue("@UsuarioSistema", UsuarioSistema);
            CommandActualizarReservaciones.Parameters.AddWithValue("@FechaSistema", FechaSistema);
            CommandActualizarReservaciones.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

        public void MtdEliminarReservaciones(int CodigoReserva)
        {
            string QueryEliminarReservaciones = "Delete tbl_Reservaciones where CodigoReserva = @CodigoReserva";
            SqlCommand CommandEliminarReservaciones = new SqlCommand(QueryEliminarReservaciones, cd_conexion.MtdAbrirConexion());
            CommandEliminarReservaciones.Parameters.AddWithValue("@CodigoReserva", CodigoReserva);
            CommandEliminarReservaciones.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }
    }
}
