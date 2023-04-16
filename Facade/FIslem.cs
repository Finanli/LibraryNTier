using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entity;

namespace Facade
{
    public class FIslem
    {
        public static DataTable Listele()
        {
            SqlDataAdapter adp = new SqlDataAdapter("IslemListele", Baglanti.conn);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt= new DataTable();
            adp.Fill(dt);
            return dt;
        }

        


        public static bool Ekle(EIslem veri)
        {
            SqlCommand cmd = new SqlCommand("IslemEkle", DBaglanti.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("uyeNo", veri.uyeno);
            cmd.Parameters.AddWithValue("kitapno", veri.kitapno);
            cmd.Parameters.AddWithValue("islemT", veri.islemT);
            cmd.Parameters.AddWithValue("teslimT", veri.teslimT);
            cmd.Parameters.AddWithValue("islemdurum", veri.islemdurum);

            return DBaglanti.ExecuteNonQuery(cmd);
        }
        
        public static bool Guncelle(EIslem veri)
        {
            SqlCommand cmd = new SqlCommand("IslemYenile", DBaglanti.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("islemno", veri.islemno);
            cmd.Parameters.AddWithValue("uyeNo", veri.uyeno);
            cmd.Parameters.AddWithValue("kitapno", veri.kitapno);
            cmd.Parameters.AddWithValue("islemT", veri.islemT);
            cmd.Parameters.AddWithValue("teslimT", veri.teslimT);
            cmd.Parameters.AddWithValue("islemdurum", veri.islemdurum);

            return DBaglanti.ExecuteNonQuery(cmd);
        }

        public static bool Sil(EIslem veri)
        {
            SqlCommand cmd = new SqlCommand("IslemSil", DBaglanti.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("islemno", veri.islemno);
            return DBaglanti.ExecuteNonQuery(cmd);
        }
    }
}
