using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CDconsumos
    {
        Conexión cd_conexion = new Conexión();

        public List<dynamic> MtdListarReservas()
        {
            List<dynamic> ListaReservas = new List<dynamic>();
            string QueryListaReservas = "Select CodigoReserva from tbl_Reservaciones";
            SqlCommand cmd = new SqlCommand(QueryListaReservas, cd_conexion.MtdAbrirConexion());
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ListaReservas.Add(new
                {
                    Value = reader["CodigoReserva"],
                    Text = reader["CodigoReserva"]
                });
            }

            cd_conexion.MtdCerrarConexion();
            return ListaReservas;
        }

        public List<dynamic> MtdListarServicios()
        {
            List<dynamic> ListaServicios = new List<dynamic>();
            string QueryListaServicios = "Select CodigoServicio, Nombre from tbl_Servicios";
            SqlCommand cmd = new SqlCommand(QueryListaServicios, cd_conexion.MtdAbrirConexion());
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ListaServicios.Add(new
                {
                    Value = reader["CodigoServicio"],
                    Text = $"{reader["CodigoServicio"]} - {reader["Nombre"]}"
                });
            }

            cd_conexion.MtdCerrarConexion();
            return ListaServicios;
        }

        public Decimal MtdMontoConsumo(int CodigoServicio)
        {
            decimal MontoConsumo = 0;

            string QueryConsultarMontoConsumo = "Select Precio from tbl_Servicios where CodigoServicio = @CodigoServicio";
            SqlCommand CommandMontoConsumo = new SqlCommand(QueryConsultarMontoConsumo, cd_conexion.MtdAbrirConexion());
            CommandMontoConsumo.Parameters.AddWithValue("@CodigoServicio", CodigoServicio);
            SqlDataReader reader = CommandMontoConsumo.ExecuteReader();

            if (reader.Read())
            {
                MontoConsumo = decimal.Parse(reader["Precio"].ToString());
            }
            else
            {
                MontoConsumo = 0;
            }

            cd_conexion.MtdCerrarConexion();
            return MontoConsumo;
        }

        public DataTable MtdConsultarConsumos()
        {
            string QueryConsultarConsumos = "Select * from tbl_Consumos";
            SqlDataAdapter dt_adapter = new SqlDataAdapter(QueryConsultarConsumos, cd_conexion.MtdAbrirConexion());
            DataTable dt_consumos = new DataTable();
            dt_adapter.Fill(dt_consumos);
            cd_conexion.MtdCerrarConexion();
            return dt_consumos;
        }

        public void MtdAgregarConsumos(int CodigoReserva, int CodigoServicio, decimal Monto, DateTime FechaConsumo, string Estado, string UsuarioSistema, DateTime FechaSistema)
        {
            string QueryAgregarConsumos = "Insert into tbl_Consumos(CodigoReserva, CodigoServicio, Monto, FechaConsumo, Estado, UsuarioSistema, FechaSistema) values (@CodigoReserva, @CodigoServicio, @Monto, @FechaConsumo, @Estado, @UsuarioSistema, @FechaSistema)";
            SqlCommand CommandAgregarConsumos = new SqlCommand(QueryAgregarConsumos, cd_conexion.MtdAbrirConexion());
            CommandAgregarConsumos.Parameters.AddWithValue("@CodigoReserva", CodigoReserva);
            CommandAgregarConsumos.Parameters.AddWithValue("@CodigoServicio", CodigoServicio);
            CommandAgregarConsumos.Parameters.AddWithValue("@Monto", Monto);
            CommandAgregarConsumos.Parameters.AddWithValue("@FechaConsumo", FechaConsumo);
            CommandAgregarConsumos.Parameters.AddWithValue("@Estado", Estado);
            CommandAgregarConsumos.Parameters.AddWithValue("@UsuarioSistema", UsuarioSistema);
            CommandAgregarConsumos.Parameters.AddWithValue("@FechaSistema", FechaSistema);
            CommandAgregarConsumos.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

        public void MtdActualizarConsumos(int CodigoConsumo, int CodigoReserva, int CodigoServicio, decimal Monto, DateTime FechaConsumo, string Estado, string UsuarioSistema, DateTime FechaSistema)
        {
            string QueryActualizarConsumos = "Update tbl_Consumos set CodigoReserva = @CodigoReserva, CodigoServicio = @CodigoServicio, Monto = @Monto, FechaConsumo = @FechaConsumo, Estado = @Estado, UsuarioSistema = @UsuarioSistema, FechaSistema = @FechaSistema where CodigoConsumo = @CodigoConsumo";
            SqlCommand CommandActualizarConsumos = new SqlCommand(QueryActualizarConsumos, cd_conexion.MtdAbrirConexion());
            CommandActualizarConsumos.Parameters.AddWithValue("@CodigoConsumo", CodigoConsumo);
            CommandActualizarConsumos.Parameters.AddWithValue("@CodigoReserva", CodigoReserva);
            CommandActualizarConsumos.Parameters.AddWithValue("@CodigoServicio", CodigoServicio);
            CommandActualizarConsumos.Parameters.AddWithValue("@Monto", Monto);
            CommandActualizarConsumos.Parameters.AddWithValue("@FechaConsumo", FechaConsumo);
            CommandActualizarConsumos.Parameters.AddWithValue("@Estado", Estado);
            CommandActualizarConsumos.Parameters.AddWithValue("@UsuarioSistema", UsuarioSistema);
            CommandActualizarConsumos.Parameters.AddWithValue("@FechaSistema", FechaSistema);
            CommandActualizarConsumos.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

        public void MtdEliminarConsumos(int CodigoConsumo)
        {
            string QueryEliminarConsumos = "Delete tbl_Consumos where CodigoConsumo = @CodigoConsumo";
            SqlCommand CommandEliminarConsumos = new SqlCommand(QueryEliminarConsumos, cd_conexion.MtdAbrirConexion());
            CommandEliminarConsumos.Parameters.AddWithValue("@CodigoConsumo", CodigoConsumo);
            CommandEliminarConsumos.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }
    }
}
