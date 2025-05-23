using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CDservicios
    {
        Conexión cd_conexion = new Conexión();

        public DataTable MtdConsultarServicios()
        {
            string QueryConsultarServicios = "Select * from tbl_Servicios";
            SqlDataAdapter dt_adapter = new SqlDataAdapter(QueryConsultarServicios, cd_conexion.MtdAbrirConexion());
            DataTable dt_servicios = new DataTable();
            dt_adapter.Fill(dt_servicios);
            cd_conexion.MtdCerrarConexion();
            return dt_servicios;
        }

        public void MtdAgregarServicios(string Nombre, string Tipo, decimal Precio, DateTime FechaVigencia, DateTime FechaVencimiento, string Estado, string UsuarioSistema, DateTime FechaSistema)
        {
            string QueryAgregarServicios = "Insert Into tbl_Servicios(Nombre, Tipo, Precio, FechaVigencia, FechaVencimiento, Estado, UsuarioSistema, FechaSistema) values (@Nombre, @Tipo, @Precio, @FechaVigencia, @FechaVencimiento, @Estado, @UsuarioSistema, @FechaSistema)";
            SqlCommand CommandAgregarServicios = new SqlCommand(QueryAgregarServicios, cd_conexion.MtdAbrirConexion());
            CommandAgregarServicios.Parameters.AddWithValue("@Nombre", Nombre);
            CommandAgregarServicios.Parameters.AddWithValue("@Tipo", Tipo);
            CommandAgregarServicios.Parameters.AddWithValue("@Precio", Precio);
            CommandAgregarServicios.Parameters.AddWithValue("@FechaVigencia", FechaVigencia);
            CommandAgregarServicios.Parameters.AddWithValue("@FechaVencimiento", FechaVencimiento);
            CommandAgregarServicios.Parameters.AddWithValue("@Estado", Estado);
            CommandAgregarServicios.Parameters.AddWithValue("@UsuarioSistema", UsuarioSistema);
            CommandAgregarServicios.Parameters.AddWithValue("@FechaSistema", FechaSistema);
            CommandAgregarServicios.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

        public void MtdActualizarServicios(int CodigoServicio, string Nombre, string Tipo, decimal Precio, DateTime FechaVigencia, DateTime FechaVencimiento, string Estado, string UsuarioSistema, DateTime FechaSistema)
        {
            string QueryActualizarServicios = "Update tbl_Servicios set Nombre = @Nombre, Tipo = @Tipo, Precio = @Precio, FechaVigencia = @FechaVigencia, FechaVencimiento = @FechaVencimiento, Estado = @Estado, UsuarioSistema = @UsuarioSistema, FechaSistema = @FechaSistema where CodigoServicio = @CodigoServicio";
            SqlCommand CommandActualizarServicios = new SqlCommand(QueryActualizarServicios, cd_conexion.MtdAbrirConexion());
            CommandActualizarServicios.Parameters.AddWithValue("@CodigoServicio", CodigoServicio);
            CommandActualizarServicios.Parameters.AddWithValue("@Nombre", Nombre);
            CommandActualizarServicios.Parameters.AddWithValue("@Tipo", Tipo);
            CommandActualizarServicios.Parameters.AddWithValue("@Precio", Precio);
            CommandActualizarServicios.Parameters.AddWithValue("@FechaVigencia", FechaVigencia);
            CommandActualizarServicios.Parameters.AddWithValue("@FechaVencimiento", FechaVencimiento);
            CommandActualizarServicios.Parameters.AddWithValue("@Estado", Estado);
            CommandActualizarServicios.Parameters.AddWithValue("@UsuarioSistema", UsuarioSistema);
            CommandActualizarServicios.Parameters.AddWithValue("@FechaSistema", FechaSistema);
            CommandActualizarServicios.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

        public void MtdEliminarServicios(int CodigoServicio)
        {
            string QueryEliminarServicios = "Delete tbl_Servicios where CodigoServicio = @CodigoServicio";
            SqlCommand CommandEliminarServicios = new SqlCommand(QueryEliminarServicios, cd_conexion.MtdAbrirConexion());
            CommandEliminarServicios.Parameters.AddWithValue("@CodigoServicio", CodigoServicio);
            CommandEliminarServicios.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }
    }
}
