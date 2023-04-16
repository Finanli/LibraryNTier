using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Facade;

namespace Business
{
    public class BLEKitap
    {
        public static bool KEkle(EKitap veri)
        {
            if (veri.kitapadi != null && veri.kitapadi.Trim().Length>0) 
            {
                return FKitap.KitapEk(veri);
            }
            
            return false;

        }
        public static bool UEkle(EUye veri)
        {
            if (veri.uyeAdi != null)
            {
                return FUye.Ekle(veri);

            }
            return false;
        }


        public static bool IEkle(EIslem veri)
        {
            if (veri.uyeno != 0 && veri.kitapno != 0)
            {
                return FIslem.Ekle(veri);
            }
            return false;
        }

    }
}
