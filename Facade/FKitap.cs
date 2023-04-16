using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entity;

namespace Facade
{
    public class FKitap
    {
        public static DataTable KitapListe()
        {
            SqlDataAdapter adp = new SqlDataAdapter("KitapListele", Baglanti.conn);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }
        public static bool KitapEk(EKitap veri)
        {
            SqlCommand cmd = new SqlCommand("KitapEkle", DBaglanti.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("kitapadi", veri.kitapadi);
            cmd.Parameters.AddWithValue("yazaradi", veri.yazaradi);
            cmd.Parameters.AddWithValue("sayfasayi", veri.sayfasayi);
            cmd.Parameters.AddWithValue("konu", veri.konu);
            cmd.Parameters.AddWithValue("yayinevi", veri.yayinevi);

            return DBaglanti.ExecuteNonQuery(cmd);
        }

        public static bool KitapGuncelle(EKitap veri)
        {
            SqlCommand cmd = new SqlCommand("KitapYenile", DBaglanti.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("kitapNo", veri.kitapno);
            cmd.Parameters.AddWithValue("kitapAdi", veri.kitapadi);
            cmd.Parameters.AddWithValue("yazarAdi", veri.yazaradi);
            cmd.Parameters.AddWithValue("sayfasayi", veri.sayfasayi);
            cmd.Parameters.AddWithValue("konu", veri.konu);
            cmd.Parameters.AddWithValue("yayinevi", veri.yayinevi);

            return DBaglanti.ExecuteNonQuery(cmd);
        }

        public static bool KitapSil(EKitap veri)
        {
            SqlCommand cmd = new SqlCommand("KitapSil", DBaglanti.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("kitapNo", veri.kitapno);
            return DBaglanti.ExecuteNonQuery(cmd);
        }
    }
}
