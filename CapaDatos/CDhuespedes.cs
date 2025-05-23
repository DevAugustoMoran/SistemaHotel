using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CDhuespedes
    {
        Conexión cd_conexion = new Conexión();

        public DataTable MtdConsultarHuespedes()
        {
            string QueryConsultarHuespedes = "Select * from tbl_huespedes";
            SqlDataAdapter dt_adapter = new SqlDataAdapter(QueryConsultarHuespedes, cd_conexion.MtdAbrirConexion());
            DataTable dt_huespedes = new DataTable();
            dt_adapter.Fill(dt_huespedes);
            cd_conexion.MtdCerrarConexion();
            return dt_huespedes;
        }

        public void MtdAgregarHuespedes(string Nombre, string Nit, string Telefono, string Tipo, string Estado, string UsuarioSistema, DateTime FechaSistema)
        {
            string QueryAgregarHuespedes = "Insert into tbl_huespedes(Nombre, Nit, Telefono, Tipo, Estado, UsuarioSistema, FechaSistema) values (@Nombre, @Nit, @Telefono, @Tipo, @Estado, @UsuarioSistema, @FechaSistema)";
            SqlCommand CommandAgregarHuespedes = new SqlCommand(QueryAgregarHuespedes, cd_conexion.MtdAbrirConexion());
            CommandAgregarHuespedes.Parameters.AddWithValue("@Nombre", Nombre);
            CommandAgregarHuespedes.Parameters.AddWithValue("@Nit", Nit);
            CommandAgregarHuespedes.Parameters.AddWithValue("@Telefono", Telefono);
            CommandAgregarHuespedes.Parameters.AddWithValue("@Tipo", Tipo);
            CommandAgregarHuespedes.Parameters.AddWithValue("@Estado", Estado);
            CommandAgregarHuespedes.Parameters.AddWithValue("@UsuarioSistema", UsuarioSistema);
            CommandAgregarHuespedes.Parameters.AddWithValue("@FechaSistema", FechaSistema);
            CommandAgregarHuespedes.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

        public void MtdActualizarHuespedes(int CodigoHuesped, string Nombre, string Nit, string Telefono, string Tipo, string Estado, string UsuarioSistema, DateTime FechaSistema)
        {
            string QueryActualizarHuespedes = "Update tbl_huespedes set Nombre = @Nombre, Nit = @Nit, Telefono = @Telefono, Tipo = @Tipo, Estado = @Estado, UsuarioSistema = @UsuarioSistema, FechaSistema = @FechaSistema where CodigoHuesped = @CodigoHuesped";
            SqlCommand CommandActualizarHuespedes = new SqlCommand(QueryActualizarHuespedes, cd_conexion.MtdAbrirConexion());
            CommandActualizarHuespedes.Parameters.AddWithValue("@CodigoHuesped", CodigoHuesped);
            CommandActualizarHuespedes.Parameters.AddWithValue("@Nombre", Nombre);
            CommandActualizarHuespedes.Parameters.AddWithValue("@Nit", Nit);
            CommandActualizarHuespedes.Parameters.AddWithValue("@Telefono", Telefono);
            CommandActualizarHuespedes.Parameters.AddWithValue("@Tipo", Tipo);
            CommandActualizarHuespedes.Parameters.AddWithValue("@Estado", Estado);
            CommandActualizarHuespedes.Parameters.AddWithValue("@UsuarioSistema", UsuarioSistema);
            CommandActualizarHuespedes.Parameters.AddWithValue("@FechaSistema", FechaSistema);
            CommandActualizarHuespedes.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

        public void MtdEliminarHuespedes(int CodigoHuesped)
        {
            string QueryEliminarHuespedes = "Delete tbl_huespedes where CodigoHuesped = @CodigoHuesped";
            SqlCommand CommandEliminarHuespedes = new SqlCommand(QueryEliminarHuespedes, cd_conexion.MtdAbrirConexion());
            CommandEliminarHuespedes.Parameters.AddWithValue("@CodigoHuesped", CodigoHuesped);
            CommandEliminarHuespedes.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }
    }
}
