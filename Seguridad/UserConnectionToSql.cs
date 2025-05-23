using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaPresentacion.Seguridad
{
    public abstract class UserConnectionToSql
    {
        private readonly string connectionString;
        public UserConnectionToSql()
        {
            connectionString = "Server=EMORALES\\SQLEXPRESS;DataBase= db_hoteles; integrated security= true";
        }
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

    }
}
