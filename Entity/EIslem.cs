using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class EIslem
    {
        private int _islemno;
        private int _uyeno;
        private int _kitapno;
        private string _islemT;
        private string _teslimT;
        private string _islemdurum;

        public int islemno
        {
            get { return _islemno; }
            set { _islemno = value; }   
        }

        public int uyeno
        {
            get { return _uyeno; }
            set { _uyeno = value; }
        }

        public int kitapno
        {
            get { return _kitapno; }
            set { _kitapno = value; }
        }

        public string islemT
        {
            get { return _islemT; }
            set { _islemT = value; }
        }

        public string teslimT
        {
            get { return _teslimT; }
            set { _teslimT = value; }
        }

        public string islemdurum
        {
            get { return _islemdurum; }
            set
            {
                _islemdurum = value;
            }
        }
    }
}
