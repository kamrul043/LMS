using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace LibraryManagementSystem
{
    public class Connection
    {
        SqlConnection con = new SqlConnection("Data Source=LOCALHOST\\SQLEXPRESS;Initial Catalog=lmsDB;Integrated Security=True");

        public SqlConnection Activecon()
        {
            if (con.State== ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }
    }
}
