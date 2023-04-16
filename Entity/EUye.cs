using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Entity
{
    public class EUye
    {
        private int _uyeno;
        private string _uyeadi;
        private string _uyelikt;
        private string _dogumt;
        private string _meslek;

        
        public int uyeNo
        {
            get { return _uyeno; }
            set { _uyeno = value; }
        }
        public string uyeAdi
        {
            get { return _uyeadi; }
            set { _uyeadi = value; }
        }

        public string uyelikT
        {
            get { return _uyelikt; }
            set { _uyelikt = value; }
        }
        public string dogumT
        {
            get { return _dogumt; }
            set { _dogumt = value; }
        }

        public string meslek
        {
            get { return _meslek; }
            set { _meslek = value; }
        }
    }
}
