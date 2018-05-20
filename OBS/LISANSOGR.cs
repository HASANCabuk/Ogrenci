using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace OBS
{
    class LISANSOGR
    {
        //bilgilerin geçici olarak saklandıgı listeler//proctected tanımlandı çünkü Sadece tanımlandığı sınıfta ya da o sınıfı miras alan sınıflardan erişilebilir.
        protected ArrayList lNo = new ArrayList();
        protected ArrayList lAdSoyad = new ArrayList();
        protected ArrayList blm = new ArrayList();
        protected ArrayList dKod = new ArrayList();
        protected ArrayList dad = new ArrayList();
        protected ArrayList dkredi = new ArrayList();
        protected ArrayList dnot = new ArrayList();
        protected ArrayList kcders = new ArrayList();
        protected double toplam = 0;//kumulatif degerinin payı
        protected  uint tkredi = 0;//kumulatif  degerinin paydası
        protected int c = 0,d=0;
      internal  bool ekli=false,varolan=false;//miras alınan sınıflarda ve bilgial sınıfında kulanıldıgı icin sadece kendi projesinde cagrılması icin      
       internal virtual void OgrTut(OGRENCI ogr)//ogrencilerin  kayıt edildigi ogrtut metodu
        {
            if (lNo.Count==0)// numara listesi boş ise direk ekler
            {
                lNo.Add(ogr.OgrNo);
                lAdSoyad.Add(ogr.OgrAd + " " + ogr.OgrSoyad);
                blm.Add(ogr.OgrBlm);
            }
            else
            { //degilse  ogrencinin kayıtlarda olup olmadıgını kontol ederek ekler
                for (int i = 0; i <lNo.Count ; i++)
                {
                    if (lNo[i].ToString()==ogr.OgrNo)
                    {
                        ekli = true;
                        Console.WriteLine("{0} nolu  ögrenci kayatlarımızda mevcuttur",ogr.OgrNo);
                        break;
                    }          
                }
                if (ekli==false)
                {
                    lNo.Add(ogr.OgrNo);
                    lAdSoyad.Add(ogr.OgrAd + " " + ogr.OgrSoyad);
                    blm.Add(ogr.OgrBlm);
                }            
            }
           
        }
        internal virtual void Derstut(DERS drs)
        {
            if (kcders.Count == 0)//ders listesi boş ise direk ekler 
            {
                kcders.Add(drs.aldıgıders);
                dKod.Add(drs.DersKodu);
                dad.Add(drs.DersAdi);
                dkredi.Add(drs.DersKredi);
                dnot.Add(drs.DersNotu);
            }
            else
            { //degil ise  son ekleme yapılan ogrencinin listede kac dersi var ise onlar arasından aynı kod dersi farklı ismi olmayacagı göz önüne alınarak  
                 
                int k = Convert.ToInt32(kcders.Count) - Convert.ToInt32(kcders[kcders.Count - 1]);
                for (int i =k ; i < kcders.Count; i++)
                {
                    if (dKod[i].ToString()==drs.DersKodu||dad[i].ToString()==drs.DersAdi)// ders ekli bir ders ise notu ve kredisi degiştirildi
                    {
                        varolan = true;
                        dkredi[i] = drs.DersKredi;
                        dnot[i] = drs.DersNotu;
                        Console.WriteLine("{0} nolu kişinin kayıtlarda var olan bir dersini girdiginizden  dolayı ders notu ve kredisi güncellenmiştir. ", lNo[lNo.Count - 1].ToString());
                        break;
                    }
                }
                if (varolan==false)// yok ise eklendi
                {
                    kcders.Add(drs.aldıgıders);
                    dKod.Add(drs.DersKodu);
                    dad.Add(drs.DersAdi);
                    dkredi.Add(drs.DersKredi);
                    dnot.Add(drs.DersNotu);
                }                     
            }
          
        }
        internal virtual void OgrGoster() //lisans ogrencilerini gösteren  metot
        {
            
            if (lNo.Count == 0)//listenin boş olup olmadıgı kontrol edildi
            {
                Console.WriteLine("Henüz bir kaydınız yok");
            }
            else
            {
                Console.WriteLine("LİSANS");
                for (int i = 0; i < lNo.Count; i++)
                {
                    Console.WriteLine("\t{0}; {1}; {2}", lNo[i], lAdSoyad[i], blm[i]);//ogrenci ekrana yazdırıldı
                    Console.WriteLine("\tDERS BİLGİSİ");
                    for (int j =c; j < kcders.Count; j++)
                    {                  
                        Console.WriteLine("\t\t{0} {1} {2} Aktts {3}", dKod[j], dad[j], dkredi[j], dnot[j]);//ogrencinin kayıttaki dersi yazdırıldı
                        c++;   //c degeri kacinci indisden devam edilecegini tuttu          
                        if (j+1!=kcders.Count)//
                        {
                            
                           if ((Convert.ToUInt32(kcders[j+1])) == 1)//bir sonraki indisin degeri 1 ise yeni bir kisinin dersi oldugu anlaşılır
                           {
                                Kumulatif(dkredi, dnot); //kişinin kümülatifi yazdırılır  ve  bırakılır                                     
                                break;
                            }
                        }
                        else
                        {
                            Kumulatif(dkredi, dnot);//son kişinin kümülatifi hesaplanır
                        }
                     
                    }
                }
            }
        }
       internal  void Kumulatif(ArrayList kredi, ArrayList not)//tüm miraslarda kulanılabilinir oldugundan  miraslarda  kullanmadım cünkü  kullanımı aynı
        {
           
            for (int j = d; j < kcders.Count; j++)
            {
                toplam += Convert.ToDouble(kredi[j]) * Convert.ToDouble(not[j]);//pay hesaplanır
                tkredi += Convert.ToUInt32(kredi[j]);// payda hesaplanır
                d++;
                if (j + 1 != kcders.Count)
                {
                   
                    if ((Convert.ToUInt32(kcders[j + 1])) == 1)//bir sonraki indisin degeri 1 ise yeni bir kisinin dersi oldugu anlaşılır
                    {
                        Console.WriteLine("Kümülatif başarı notu : {0}", toplam / tkredi);//hesaplanan kümülatif yazdırılır
                        toplam = 0;//bir sonraki icin sıfırlanır
                        tkredi = 0;
                        break;
                    }
                }
                else 
                {
                      Console.WriteLine("Kümülatif başarı notu : {0}", toplam / tkredi);//son kişinin kümülatifi yazdırılır
                }       

            }
           
        }
    }
}

