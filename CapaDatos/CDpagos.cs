using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CDpagos
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

        public Decimal MtdMontoPago(int CodigoReserva)
        {
            decimal MontoPago = 0;

            string QueryConsultarMontoPago = "Select Total from tbl_Reservaciones where CodigoReserva = @CodigoReserva";
            SqlCommand CommandMontoPago = new SqlCommand(QueryConsultarMontoPago, cd_conexion.MtdAbrirConexion());
            CommandMontoPago.Parameters.AddWithValue("@CodigoReserva", CodigoReserva);
            SqlDataReader reader = CommandMontoPago.ExecuteReader();

            if (reader.Read())
            {
                MontoPago = decimal.Parse(reader["Total"].ToString());
            }
            else
            {
                MontoPago = 0;
            }

            cd_conexion.MtdCerrarConexion();
            return MontoPago;
        }

        public DataTable MtdConsultarPagos()
        {
            string QueryConsultarPagos = "Select * from tbl_Pagos";
            SqlDataAdapter dt_adapter = new SqlDataAdapter(QueryConsultarPagos, cd_conexion.MtdAbrirConexion());
            DataTable dt_pagos = new DataTable();
            dt_adapter.Fill(dt_pagos);
            cd_conexion.MtdCerrarConexion();
            return dt_pagos;
        }

        public void MtdAgregarPagos(int CodigoReserva, decimal Monto, decimal Propina, decimal Impuesto, decimal Descuento, decimal TotalPago, DateTime FechaPago, string MetodoPago, string UsuarioSistema, DateTime FechaSistema)
        {
            string QueryAgregarPagos = "Insert into tbl_Pagos(CodigoReserva, Monto, Propina, Impuesto, Descuento, TotalPago, FechaPago, MetodoPago, UsuarioSistema, FechaSistema) values (@CodigoReserva, @Monto, @Propina, @Impuesto, @Descuento, @TotalPago, @FechaPago, @MetodoPago, @UsuarioSistema, @FechaSistema)";
            SqlCommand CommandAgregarPagos = new SqlCommand(QueryAgregarPagos, cd_conexion.MtdAbrirConexion());
            CommandAgregarPagos.Parameters.AddWithValue("@CodigoReserva", CodigoReserva);
            CommandAgregarPagos.Parameters.AddWithValue("@Monto", Monto);
            CommandAgregarPagos.Parameters.AddWithValue("@Propina", Propina);
            CommandAgregarPagos.Parameters.AddWithValue("@Impuesto", Impuesto);
            CommandAgregarPagos.Parameters.AddWithValue("@Descuento", Descuento);
            CommandAgregarPagos.Parameters.AddWithValue("@TotalPago", TotalPago);
            CommandAgregarPagos.Parameters.AddWithValue("@FechaPago", FechaPago);
            CommandAgregarPagos.Parameters.AddWithValue("@MetodoPago", MetodoPago);
            CommandAgregarPagos.Parameters.AddWithValue("@UsuarioSistema", UsuarioSistema);
            CommandAgregarPagos.Parameters.AddWithValue("@FechaSistema", FechaSistema);
            CommandAgregarPagos.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

        public void MtdActualizarPagos(int CodigoPago, int CodigoReserva, decimal Monto, decimal Propina, decimal Impuesto, decimal Descuento, decimal TotalPago, DateTime FechaPago, string MetodoPago, string UsuarioSistema, DateTime FechaSistema)
        {
            string QueryActualizarPagos = "Update tbl_Pagos set CodigoReserva = @CodigoReserva, Monto = @Monto, Propina = @Propina, Impuesto = @Impuesto, Descuento = @Descuento, TotalPago = @TotalPago, FechaPago = @FechaPago, MetodoPago = @MetodoPago, UsuarioSistema = @UsuarioSistema, FechaSistema = @FechaSistema where CodigoPago = @CodigoPago";
            SqlCommand CommandActualizarPagos = new SqlCommand(QueryActualizarPagos, cd_conexion.MtdAbrirConexion());
            CommandActualizarPagos.Parameters.AddWithValue("@CodigoPago", CodigoPago);
            CommandActualizarPagos.Parameters.AddWithValue("@CodigoReserva", CodigoReserva);
            CommandActualizarPagos.Parameters.AddWithValue("@Monto", Monto);
            CommandActualizarPagos.Parameters.AddWithValue("@Propina", Propina);
            CommandActualizarPagos.Parameters.AddWithValue("@Impuesto", Impuesto);
            CommandActualizarPagos.Parameters.AddWithValue("@Descuento", Descuento);
            CommandActualizarPagos.Parameters.AddWithValue("@TotalPago", TotalPago);
            CommandActualizarPagos.Parameters.AddWithValue("@FechaPago", FechaPago);
            CommandActualizarPagos.Parameters.AddWithValue("@MetodoPago", MetodoPago);
            CommandActualizarPagos.Parameters.AddWithValue("@UsuarioSistema", UsuarioSistema);
            CommandActualizarPagos.Parameters.AddWithValue("@FechaSistema", FechaSistema);
            CommandActualizarPagos.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

        public void MtdEliminarPagos(int CodigoPago)
        {
            string QueryEliminarPagos = "Delete tbl_Pagos where CodigoPago = @CodigoPago";
            SqlCommand CommandEliminarPagos = new SqlCommand(QueryEliminarPagos, cd_conexion.MtdAbrirConexion());
            CommandEliminarPagos.Parameters.AddWithValue("@CodigoPago", CodigoPago);
            CommandEliminarPagos.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }
    }
}
