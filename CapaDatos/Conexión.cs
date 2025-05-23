using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class Conexión
    {
        private SqlConnection db_conexion = new SqlConnection("Data Source=UNI-1000914\\SQLEXPRESS;Initial Catalog=db_hotel;Integrated Security=True;Encrypt=False");
    
           public SqlConnection MtdAbrirConexion()
           {
                if (db_conexion.State == ConnectionState.Closed)
                {
                    db_conexion.Open();
                }
                return db_conexion;
           }

           public SqlConnection MtdCerrarConexion()
           {
                if (db_conexion.State == ConnectionState.Open)
                {
                    db_conexion.Close();
                }
                return db_conexion;
           }
    }
}
