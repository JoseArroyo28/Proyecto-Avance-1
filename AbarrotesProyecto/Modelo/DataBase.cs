using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD_Comm_MySQL;
using System.Data.SqlClient;

namespace AbarrotesProyecto.Modelo
{
    public class DataBase
    {

        public static string cadconn = "Data Source=LAPTOP-5UPDO2I6;Database = Abarrotes;Trusted_Connection=True";
        public static BDMSSQL mibd = new BDMSSQL(cadconn);

        public static SqlConnection SqlConn()
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-5UPDO2I6;Database = Abarrotes;Trusted_Connection=True");
            con.Open();
            return con;
        }
    }
}
