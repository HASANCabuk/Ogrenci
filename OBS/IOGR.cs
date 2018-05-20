using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS
{
    interface IOGR
    {
        string OgrNo { get; set; }
        string OgrAd { get; set; }
        string OgrSoyad { get; set; }
        string OgrBlm { get; set; }
        string OgrMznLsnsU { get; set; }
        string OgrMznLsnsBlm { get; set; }
        string OgrMznYLsnsU { get; set; }
        string OgrMznYLsnsBlm { get; set; }
    }
}
