using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exec01Lista2
{
    public static class DBConnection 
    {
        public static SqlConnection Connection { get; } = new SqlConnection(@"Data Source=MASTER-PC\SQLSERVER14;Integrated Security=True");
    }
}
