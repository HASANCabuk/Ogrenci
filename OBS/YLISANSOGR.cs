using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace OBS
{
    class YLISANSOGR:LISANSOGR
    {     
        protected  ArrayList lunvrs = new ArrayList();
        protected  ArrayList lblm = new ArrayList();
       internal override void OgrTut(OGRENCI ogr)
        {
            if (lNo.Count==0)
            {
                lNo.Add(ogr.OgrNo);
                lAdSoyad.Add(ogr.OgrAd + " " + ogr.OgrSoyad);
                blm.Add(ogr.OgrBlm);
                lunvrs.Add(ogr.OgrMznLsnsU);
                lblm.Add(ogr.OgrMznLsnsBlm);
            }
            else
            {
                for (int i = 0; i < lNo.Count; i++)
                {
                    if (lNo[i].ToString() == ogr.OgrNo)
                    {
                        ekli = true;
                        Console.WriteLine("{0} nolu  ögrenci kayatlarımızda mevcuttur", ogr.OgrNo);
                        break;
                    }
                }
                if (ekli==false)
                {
                    lNo.Add(ogr.OgrNo);
                    lAdSoyad.Add(ogr.OgrAd + " " + ogr.OgrSoyad);
                    blm.Add(ogr.OgrBlm);
                    lunvrs.Add(ogr.OgrMznLsnsU);
                    lblm.Add(ogr.OgrMznLsnsBlm);
                }
            }
           
        }
        internal override void Derstut(DERS drs)
        {
            if (kcders.Count == 0)
            {
                kcders.Add(drs.aldıgıders);
                dKod.Add(drs.DersKodu);
                dad.Add(drs.DersAdi);
                dkredi.Add(drs.DersKredi);
                dnot.Add(drs.DersNotu);
            }
            else
            {
                int k = Convert.ToInt32(kcders.Count) - Convert.ToInt32(kcders[kcders.Count - 1]);
                for (int i = k; i < kcders.Count; i++)
                {
                    if (dKod[i].ToString() == drs.DersKodu || dad[i].ToString() == drs.DersAdi)
                    {
                        varolan = true;
                        dkredi[i] = drs.DersKredi;
                        dnot[i] = drs.DersNotu;
                        Console.WriteLine("{0} nolu kişinin kayıtlarda var olan bir dersini girdiginizden dolayı ders notu ve kredisi güncellenmiştir. ", lNo[lNo.Count - 1].ToString());
                        break;
                    }
                }
                if (varolan == false)
                {
                    kcders.Add(drs.aldıgıders);
                    dKod.Add(drs.DersKodu);
                    dad.Add(drs.DersAdi);
                    dkredi.Add(drs.DersKredi);
                    dnot.Add(drs.DersNotu);
                }
            }

        }
       internal override void OgrGoster()
        {         
            if (lNo.Count == 0)
            {
                Console.WriteLine("Henüz bir kaydınız yok");
            }
            else
            {
                Console.WriteLine("YÜKSEK LİSANS");
                for (int i = 0; i < lNo.Count; i++)
                {
                    Console.WriteLine("\t{0}; {1}; {2}", lNo[i], lAdSoyad[i], blm[i]);
                    Console.WriteLine("\tLİSANS BİLGİLERİ");
                    Console.WriteLine("\t\t{0}; {0}",lunvrs[i],lblm[i]);
                    Console.WriteLine("\tDERS BİLGİSİ");
                    for (int j = c; j < kcders.Count; j++)
                    {
                        Console.WriteLine("\t\t{0} {1} {2} Aktts {3}", dKod[j], dad[j], dkredi[j], dnot[j]);
                        c++;
                        if (j+1!= kcders.Count)
                        {


                            if ((Convert.ToUInt32(kcders[j+1])) == 1)
                            {
                                Kumulatif(dkredi, dnot);
                                break;
                            }
                        }
                        else
                        {
                             Kumulatif(dkredi, dnot);
                        }
                    }
                }
            }
        }  
    }
}
