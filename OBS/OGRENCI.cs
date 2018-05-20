using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS
{
    class OGRENCI:IOGR
    {
        public string ogrno, ograd, ogrsoyad, ogrblm, ogrmznlsnsU, ogrmznblm, ogrmznylsnsU, ogrmznylsnsblm;
        public string OgrNo//Numara
        {

            get { return ogrno; }
            set
            {
                ogrno = value;
            }
        }
        public string OgrAd { get { return ograd; } set { ograd = value; } }//adi
        public string OgrSoyad { get { return ogrsoyad; } set { ogrsoyad = value; } }//soyadi
        public string OgrBlm { get { return ogrblm; } set { ogrblm = value; } }//Okudugu bolum
        public string OgrMznLsnsBlm { get { return ogrmznblm; } set { ogrmznblm = value; } }//Mezun olunan lisans bolum
        public string OgrMznLsnsU { get { return ogrmznlsnsU; } set { ogrmznlsnsU = value; } }//Mezun oluna universite
        public string OgrMznYLsnsBlm { get { return ogrmznylsnsblm; } set { ogrmznylsnsblm = value; } }//Mezun olunan Yuksek lisans bolum
        public string OgrMznYLsnsU { get { return ogrmznylsnsU; } set { ogrmznylsnsU = value; } }//Mezun oluna  Yuksek universite
    }
}
