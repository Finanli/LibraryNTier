using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Facade
{
    internal class Baglanti
    {
        public static readonly SqlConnection conn = new SqlConnection("Server = LAPTOP-DI6H08K1; Database = Kutuphane ; Integrated Security = true;");


        public DataTable GetData()
        {
            DataTable dt = new DataTable();

            string CMD = "SELECT * FROM uyeler";
            SqlDataAdapter da = new SqlDataAdapter(CMD, conn);
            da.Fill(dt);

            return dt;
        }
    }
}
