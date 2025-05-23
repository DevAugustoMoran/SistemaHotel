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
            connectionString = "Data Source=UNI-1000914\\SQLEXPRESS;Initial Catalog=db_hotel;Integrated Security=True;Encrypt=False";
        }
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

    }
}
