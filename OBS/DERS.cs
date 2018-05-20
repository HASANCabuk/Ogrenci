using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS
{
    class DERS:IDRS
    {
        public string derskod, dersad, derskred, dersnot;
        public uint aldıgıders = 0;
        private uint a;
        public string DersKodu { get { return derskod; } set { derskod = value; } }
        public string DersAdi { get { return dersad; } set { dersad = value; } }
        public string DersKredi
        {
            get
            {
                if (UInt32.TryParse(derskred, out a) == true)
                {
                    if (Convert.ToUInt32(derskred) > 70)
                    {
                        derskred = "70";
                    }
                   
                }
                return derskred;
            }
                    set
                 {
                    derskred = value;
                }
        }
        public string DersNotu
        {
            get {
                if (UInt32.TryParse(dersnot, out a) == true)
                {
                    if (Convert.ToUInt32(dersnot) > 100)
                    {
                        dersnot = "100";
                    }
                }
                return dersnot;
            }
            set
            {              
                dersnot = value;
            }
        }
    }
}
