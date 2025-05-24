using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CDusuarios
    {
        Conexión cd_conexion = new Conexión();

        public List<dynamic> MtdListarEmpleados()
        {
            List<dynamic> ListaEmpleados = new List<dynamic>();
            string QueryListaEmpleados = "Select CodigoEmpleado, Nombre from tbl_Empleados";
            SqlCommand cmd = new SqlCommand(QueryListaEmpleados, cd_conexion.MtdAbrirConexion());
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ListaEmpleados.Add(new
                {
                    Value = reader["CodigoEmpleado"],
                    Text = $"{reader["CodigoEmpleado"]} - {reader["Nombre"]}"
                });
            }

            cd_conexion.MtdCerrarConexion();
            return ListaEmpleados;
        }

        public DataTable MtdConsultarUsuarios()
        {
            string QueryConsultarUsuarios = "Select * from tbl_Usuarios";
            SqlDataAdapter dt_adapter = new SqlDataAdapter(QueryConsultarUsuarios, cd_conexion.MtdAbrirConexion());
            DataTable dt_usuarios = new DataTable();
            dt_adapter.Fill(dt_usuarios);
            cd_conexion.MtdCerrarConexion();
            return dt_usuarios;
        }

        public void MtdAgregarUsuarios(int CodigoEmpleado, string NombreUsuario, string Contrasena, string Rol, string Estado, string UsuarioSistema, DateTime FechaSistema)
        {
            string QueryAgregarUsuarios = "Insert into tbl_Usuarios(CodigoEmpleado, NombreUsuario, Contrasena, Rol, Estado, UsuarioSistema, FechaSistema) values (@CodigoEmpleado, @NombreUsuario, @Contrasena, @Rol, @Estado, @UsuarioSistema, @FechaSistema)";
            SqlCommand CommandAgregarUsuarios = new SqlCommand(QueryAgregarUsuarios, cd_conexion.MtdAbrirConexion());
            CommandAgregarUsuarios.Parameters.AddWithValue("@CodigoEmpleado", CodigoEmpleado);
            CommandAgregarUsuarios.Parameters.AddWithValue("@NombreUsuario", NombreUsuario);
            CommandAgregarUsuarios.Parameters.AddWithValue("@Contrasena", Contrasena);
            CommandAgregarUsuarios.Parameters.AddWithValue("@Rol", Rol);
            CommandAgregarUsuarios.Parameters.AddWithValue("@Estado", Estado);
            CommandAgregarUsuarios.Parameters.AddWithValue("@UsuarioSistema", UsuarioSistema);
            CommandAgregarUsuarios.Parameters.AddWithValue("@FechaSistema", FechaSistema);
            CommandAgregarUsuarios.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

        public void MtdActualizarUsuarios(int CodigoUsuario, int CodigoEmpleado, string NombreUsuario, string Contrasena, string Rol, string Estado, string UsuarioSistema, DateTime FechaSistema)
        {
            string QueryActualizarUsuarios = "Update tbl_Usuarios set CodigoEmpleado = @CodigoEmpleado, NombreUsuario = @NombreUsuario, Contrasena = @Contrasena, Rol = @Rol, Estado = @Estado, UsuarioSistema = @UsuarioSistema, FechaSistema = @FechaSistema where CodigoUsuario = @CodigoUsuario";
            SqlCommand CommandActualizarUsuarios = new SqlCommand(QueryActualizarUsuarios, cd_conexion.MtdAbrirConexion());
            CommandActualizarUsuarios.Parameters.AddWithValue("@CodigoUsuario", CodigoUsuario);
            CommandActualizarUsuarios.Parameters.AddWithValue("@CodigoEmpleado", CodigoEmpleado);
            CommandActualizarUsuarios.Parameters.AddWithValue("@NombreUsuario", NombreUsuario);
            CommandActualizarUsuarios.Parameters.AddWithValue("@Contrasena", Contrasena);
            CommandActualizarUsuarios.Parameters.AddWithValue("@Rol", Rol);
            CommandActualizarUsuarios.Parameters.AddWithValue("@Estado", Estado);
            CommandActualizarUsuarios.Parameters.AddWithValue("@UsuarioSistema", UsuarioSistema);
            CommandActualizarUsuarios.Parameters.AddWithValue("@FechaSistema", FechaSistema);
            CommandActualizarUsuarios.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

        public void MtdEliminarUsuarios(int CodigoUsuario)
        {
            string QueryEliminarUsuarios = "Delete tbl_Usuarios where CodigoUsuario = @CodigoUsuario";
            SqlCommand CommandEliminarUsuarios = new SqlCommand(QueryEliminarUsuarios, cd_conexion.MtdAbrirConexion());
            CommandEliminarUsuarios.Parameters.AddWithValue("@CodigoUsuario", CodigoUsuario);
            CommandEliminarUsuarios.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }
    }
}
