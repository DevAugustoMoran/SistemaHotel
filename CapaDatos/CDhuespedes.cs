using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    internal class CDhuespedes
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
    }
}
