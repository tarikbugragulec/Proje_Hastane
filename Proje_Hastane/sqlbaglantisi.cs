using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Proje_Hastane
{
    class sqlbaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection sc = new SqlConnection("Data Source=DESKTOP-0EUS3MP\\SQLEXPRESS;Initial Catalog=HastaneOtomasyon;Integrated Security=True");
            sc.Open();
            return sc;
        }
    }
}
