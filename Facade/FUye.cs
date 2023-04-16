using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entity;
using System.Runtime.InteropServices.ComTypes;

namespace Facade
{
    public class FUye
    {
        public static DataTable Listele()
        {
            SqlDataAdapter adp = new SqlDataAdapter("UyeListele", Baglanti.conn);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }


        
    
        
         //public DataTable FetchData()
         //{

         //       Baglanti objDataAccess = new Baglanti();
         //       DataTable dt = objDataAccess.GetData();
         //       return dt;

         //}

            //    SqlCommand adp = new SqlCommand("select * from uyeler", Baglanti.conn);
            //adp.Connection.Open();
            //adp.CommandType = CommandType.Text;
            //SqlDataReader reader = null;
            //reader = adp.ExecuteReader(CommandBehavior.CloseConnection);
            //return reader;
        

        
    


        public static bool Ekle(EUye veri)
        {
            SqlCommand cmd = new SqlCommand("UyeEkle",DBaglanti.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("uyeAdi",veri.uyeAdi);
            cmd.Parameters.AddWithValue("uyelikT", veri.uyelikT);
            cmd.Parameters.AddWithValue("dogumT", veri.dogumT);
            cmd.Parameters.AddWithValue("meslek", veri.meslek);

            return DBaglanti.ExecuteNonQuery(cmd);
        }

        public static bool Guncelle(EUye veri) 
        {
            SqlCommand cmd = new SqlCommand("UyeYenile", DBaglanti.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("uyeNo",veri.uyeNo);
            cmd.Parameters.AddWithValue("uyeAdi", veri.uyeAdi);
            cmd.Parameters.AddWithValue("uyelikT", veri.uyelikT);
            cmd.Parameters.AddWithValue("dogumT", veri.dogumT);
            cmd.Parameters.AddWithValue("meslek", veri.meslek);

            return DBaglanti.ExecuteNonQuery(cmd);
        }
        public static bool Sil(EUye veri)
        {
            SqlCommand cmd = new SqlCommand("UyeSil", DBaglanti.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("uyeNo", veri.uyeNo);

            return DBaglanti.ExecuteNonQuery(cmd);

        }
    }
}
