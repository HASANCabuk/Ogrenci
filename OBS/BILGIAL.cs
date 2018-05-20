using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS
{
    class BILGIAL
    {
        OGRENCI ogr = new OGRENCI();//ogr nesnesi
        DERS drs = new DERS();// drs nesnesi
        LISANSOGR lo=new LISANSOGR();
        YLISANSOGR ylo = new YLISANSOGR();
        DKTROGR dktro = new DKTROGR();     
        private string blg, mrtb, dvm;//bilgi mertebe devam
        private uint a;
        private char[] tutucu;
        public void Iste()
        {                  
            do
            {
                Console.WriteLine("Bilgi Girisi İcin  " + "(1)  " + "Bilgi Gosterme  İcin  " + "(2)");//Menu Bilgi Girisi           
                blg = Convert.ToString(Console.ReadLine());
                Console.WriteLine(UInt32.TryParse(blg, out a) == true ? "" : " Dogru  deger giriniz"); //gelen degerin istenilen uygunlugu kontrol edildi      
            } while (blg != "1" && blg != "2");
            OgrBilgi();
        }
      
        private void OgrBilgi()
        {
            if (blg == "1")//Bilgi girisi secimi
            {
                do
                {
                    Console.WriteLine("Lisans icin (1) Yuksek Lisans icin (2) Doktora icin (3)");// hangi programdan giris yapacagı istendi
                    mrtb = Convert.ToString(Console.ReadLine());
                    Console.WriteLine(UInt32.TryParse(blg, out a) == true ? "" : " Dogru  deger giriniz");//gelen degerin istenilen uygunlugu kontrol edildi      
                } while (mrtb != "1" && mrtb != "2" && mrtb != "3");
                if (mrtb == "1")//Ogrencinin bilgileri isteniyor
                {                 
                    OgrLsns();//metot ile  lisans ogrencisinin bilgileri   
                    lo.OgrTut(ogr);
                    if (lo.ekli==true)
                    {
                        OgrLsns();
                    } else                            
                    DersBilgi();// ders bilgileri isteniyor                                     
                }
                else
                {
                    if (mrtb == "2")
                    {
                        OgrYLsns();
                        ylo.OgrTut(ogr);
                        if (ylo.ekli==true)
                        {
                            OgrYLsns();
                        }else
                        DersBilgi();
                    }
                    else
                    {
                        OgrDktr();
                       dktro.OgrTut(ogr);
                        if (dktro.ekli == true)
                        {
                            OgrYLsns();
                        }
                        else
                            DersBilgi();
                    }
                }

            }
            else
            {
                Console.Clear();
                lo.OgrGoster();
                ylo.OgrGoster();
                dktro.OgrGoster();
                Iste();
            }
        }
        private void OgrLsns()//Bu metot lisans icin bilgi sorularını calıstırır
        {
            No(); Ad("1"); Ad("2"); Ad("3");

        }
        private void OgrYLsns()// yuksek  lisass icin
        {
            No(); Ad("1"); Ad("2"); Ad("3"); Ad("4"); Ad("5");

        }
        private void OgrDktr()//doktora icin
        {
            No(); Ad("1"); Ad("2"); Ad("3"); Ad("4"); Ad("5"); Ad("6"); Ad("7");

        }
        private void No()//ogrencin numarası
        {
            do
            {
                Console.WriteLine("Ogrencinin numarasını girin");
                ogr.OgrNo = Convert.ToString(Console.ReadLine());
                Console.WriteLine(UInt32.TryParse(ogr.OgrNo, out a) == true ? "" : "Dogru deger giriniz");
            } while (UInt32.TryParse(ogr.OgrNo, out a) != true);
        }
        private void Ad(string istnn)//istenilen degere gore ogrencinin bilgileri alınıyor
        {
            string d = istnn; //yanlış bir girdigindede  tekrar kullanmak icin tuttum;
            switch (istnn)
            {
                case "1":
                    Console.WriteLine("Ogrenci adini girin");
                    ogr.OgrAd = Convert.ToString(Console.ReadLine());//ogr adi olan property istedim
                    tutucu = ogr.OgrAd.ToCharArray();// diziye atarak kontrol ettim
                    for (int i = 0; i < tutucu.Length; i++)
                    {
                        if (!char.IsNumber(tutucu[i]) && !char.IsPunctuation(tutucu[i]) && !char.IsWhiteSpace(tutucu[i]))// icersinde sayi ve noktalama olmamasini istedim
                        {
                        }
                        else
                        {
                            Ad(d);//eger var ise tekrar istedim
                            break;
                        }
                    }
                    break;
                case "2":
                    Console.WriteLine("Ogrencinin soyadini girin");
                    ogr.OgrSoyad = Convert.ToString(Console.ReadLine());
                    tutucu = ogr.OgrSoyad.ToCharArray();
                    for (int i = 0; i < tutucu.Length; i++)
                    {
                        if (!char.IsNumber(tutucu[i]) && !char.IsPunctuation(tutucu[i]) && !char.IsWhiteSpace(tutucu[i]))
                        {
                        }
                        else
                        {
                            Ad(d);
                            break;
                        }
                    }
                    break;
                case "3":
                    Console.WriteLine("Ogrencinin okudugu bölümü girin");
                    ogr.OgrBlm = Convert.ToString(Console.ReadLine());
                    tutucu = ogr.OgrBlm.ToCharArray();
                    for (int i = 0; i < tutucu.Length; i++)
                    {
                        if (!char.IsNumber(tutucu[i]) && !char.IsPunctuation(tutucu[i]))
                        {
                        }
                        else
                        {
                            Ad(d);
                            break;
                        }
                    }
                    break;
                case "4":
                    Console.WriteLine("Ogrencinin bitirdigi lisans üniversitesi  girin");
                    ogr.OgrMznLsnsU = Convert.ToString(Console.ReadLine());
                    tutucu = ogr.OgrMznLsnsU.ToCharArray();
                    for (int i = 0; i < tutucu.Length; i++)
                    {
                        if (!char.IsNumber(tutucu[i]) && !char.IsPunctuation(tutucu[i]))
                        {
                        }
                        else
                        {
                            Ad(d);
                            break;
                        }
                    }
                    break;
                case "5":
                    Console.WriteLine("Ogrencinin lisans da mezun oldugu bölümü girin");
                    ogr.OgrMznLsnsBlm = Convert.ToString(Console.ReadLine());
                    tutucu = ogr.OgrMznLsnsBlm.ToCharArray();
                    for (int i = 0; i < tutucu.Length; i++)
                    {
                        if (!char.IsNumber(tutucu[i]) && !char.IsPunctuation(tutucu[i]))
                        {
                        }
                        else
                        {
                            Ad(d);
                            break;
                        }
                    }
                    break;
                case "6":
                    Console.WriteLine("Ogrencinin yüksek lisas da okudugu üniversiteyi girin");
                    ogr.OgrMznYLsnsU = Convert.ToString(Console.ReadLine());
                    tutucu = ogr.OgrMznYLsnsU.ToCharArray();
                    for (int i = 0; i < tutucu.Length; i++)
                    {
                        if (!char.IsNumber(tutucu[i]) && !char.IsPunctuation(tutucu[i]))
                        {
                        }
                        else
                        {
                            Ad(d);
                            break;
                        }
                    }
                    break;
                case "7":
                    Console.WriteLine("Ogrencinin yuksek lisans da bitirdigi bölümü girin");
                    ogr.OgrMznYLsnsBlm = Convert.ToString(Console.ReadLine());
                    tutucu = ogr.OgrMznYLsnsBlm.ToCharArray();
                    for (int i = 0; i < tutucu.Length; i++)
                    {
                        if (!char.IsNumber(tutucu[i]) && !char.IsPunctuation(tutucu[i]))
                        {
                        }
                        else
                        {
                            Ad(d);
                            break;
                        }
                    }
                    break;
            }

        }
        private void DersBilgi()
        {
            Ders("1"); Ders("2"); Ders("3"); Ders("4"); Ders("5");
            if (mrtb=="1")
            {
                lo.Derstut(drs);
            }
            else
            {
                if (mrtb == "2")
                {
                    ylo.Derstut(drs); 
                }
                else
                    dktro.Derstut(drs);
            }
            Napalim();

        }
        private void Ders(string istnn)//ders bilgileri alindi
        {
            string k = istnn;
            switch (istnn)
            {
                case "1":
                    Console.WriteLine("Dersin kodunu girin");//ogrenci bilgileri  alinirken uygulan adimler uygulandi
                    drs.DersKodu = Convert.ToString(Console.ReadLine());
                    tutucu = drs.DersKodu.ToCharArray();
                    for (int i = 0; i < tutucu.Length; i++)
                    {
                        if (!char.IsPunctuation(tutucu[i]))
                        {
                        }
                        else
                        {
                            Ders(k);
                            break;
                        }
                    }
                    break;
                case "2":
                    Console.WriteLine("Dersin Adini girin");
                    drs.DersAdi = Convert.ToString(Console.ReadLine());
                    tutucu = drs.DersAdi.ToCharArray();
                    for (int i = 0; i < tutucu.Length; i++)
                    {
                        if (!char.IsNumber(tutucu[i]) && !char.IsPunctuation(tutucu[i]))
                        {
                        }
                        else
                        {
                            Ders(k);
                            break;
                        }
                    }
                    break;
                case "3":
                    do
                    {
                        Console.WriteLine("Dersin kredisini(1 ve 70) arası girin");
                        drs.DersKredi = Convert.ToString(Console.ReadLine());
                        Console.WriteLine(UInt32.TryParse(drs.DersKredi, out a) == true ? "" : " Dogru  deger giriniz");
                    } while (UInt32.TryParse(drs.DersKredi, out a) != true);
                    break;
                case "4":
                    do
                    {
                        Console.WriteLine("Ders notunu (0 ile 100 ) arasi girin");
                        drs.DersNotu = Convert.ToString(Console.ReadLine());
                        Console.WriteLine(UInt32.TryParse(drs.DersNotu, out a) == true ? "" : " Dogru  deger giriniz");
                    } while (UInt32.TryParse(drs.DersNotu, out a) != true);
                    break;
                case "5":
                   
                        if (dvm == "1")
                        {
                            drs.aldıgıders++;
                        }
                        else
                        {
                            drs.aldıgıders = 1;
                        }                                       
                    break;
            }
        }
        private void Napalim()// ilk ders kaydından sonra ders kayıdına devam edip etmeyecegi ile ders bilgisi veya ogrenci bilgisi cagrıldı
        {          
            do
            {
                Console.WriteLine("Ders girisine devam icin (1) basiniz Yeni ogrenci kayit icin (2) basiniz basa donmek icin (3) basın");
                dvm = Convert.ToString(Console.ReadLine());
                Console.WriteLine(UInt32.TryParse(dvm, out a) == true ? "" : " Dogru  deger giriniz");
            } while (dvm != "1" && dvm != "2" && dvm != "3");
            if (dvm == "1")
            {
                DersBilgi();               
            }
            else
            {
                if (dvm == "2")
                {
                                   
                    OgrBilgi();
                }
                else
                {
                    Iste();//dvm degeri 3 ise iste bölümünden bilgi göstermek icin kullanıldı
                }

            }

        }
    }
}
