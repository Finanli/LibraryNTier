using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entity
{
    public class EKitap
    {
        private int _kitapno;
        private string _kitapadi;
        private string _yazaradi;
        private int _sayfasayi;
        private string _konu;
        
        private string _yayinevi;

        public int kitapno
        { 
            get { return _kitapno; }
            set { _kitapno = value; }
        }
        public string kitapadi
        {
            get { return _kitapadi; }
            set { _kitapadi = value; }
        }

        public string yazaradi
        {
            get { return _yazaradi; }
            set
            {
                _yazaradi = value;
            }
        }

        public int sayfasayi
        {
            get { return _sayfasayi; }
            set
            {
                _sayfasayi = value;
            }
        }

        public string konu
        {
            get { return _konu; }
            set
            {
                _konu = value;
            }
        }

        public string yayinevi
        {
            get { return _yayinevi; }
            set
            {
                _yayinevi = value;
            }
        }
    }
}
