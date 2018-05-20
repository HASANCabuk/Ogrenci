using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS
{
    interface IDRS
    {
        string DersKodu { get; set; }
        string DersAdi { get; set; }
        string DersKredi { get; set; }
        string DersNotu { get; set; }
    }
}
