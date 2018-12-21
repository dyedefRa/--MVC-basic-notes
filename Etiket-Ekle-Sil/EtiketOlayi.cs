  public void EtiketEkle(string etiketler, int eklenecekHaberID)
        {



            if (etiketler != null)
            {
                List<Etiket> etiketListesi = new List<Etiket>();
                //EKLEYECEGIMIZ HABERI ALDIK
                var eklenecekHaber = ctx.Haber.FirstOrDefault(x => x.Id == eklenecekHaberID);
                //HABER YOKSA HATA VERSIN
                if (eklenecekHaber == null)
                {
                    //UMARIM BURAYA GIRMEZ :D
                    throw new Exception("Haber bulunamadı");
                }
                //VIRGUL ILE AYRILMIS TAGLERI DIZIYE ATTIK
                string[] etiketDizisi = etiketler.ToLower().Split(',');
                //DIZININ ICINDE GEZIYORUZ
                for (int i = 0; i < etiketDizisi.Length; i++)
                {
                    var donenAd = etiketDizisi[i].ToString();
                    //BOYLE BIR ETIKET ADINDA BIR ETIKET VARMI
                    var etiketVarmi = ctx.Etiket.FirstOrDefault(x => x.Adi == donenAd);
                    //YOKSA ETIKETI SQLE EKLE VE ETIKET LISTESINE  BU ETIKETI EKLE
                    if (etiketVarmi == null)
                    {
                        Etiket et = new Etiket { Adi = etiketDizisi[i] };
                        ctx.Etiket.Add(et);
                        etiketListesi.Add(et);
                    }
                    //VARSA ETIKET LISTESINE BU ETIKETI EKLE
                    else
                    {
                        etiketListesi.Add(etiketVarmi);
                    }


                }
                ctx.SaveChanges();
              
                //ETIKET DUZENLENME OLAYLARI ICIN VAR OLAN HABERETIKETLERI ALIYORUZ
                var varolanHaberEtiketListesi = ctx.HaberEtiket.Where(x => x.HaberID == eklenecekHaberID).ToList();


                //GUNCEL HABERETIKETLERINI ATACAGIMIZ LISTEYI OLUSTURDUK (  EXCEPT LERIMIZ ESIT OLSUN DIYE)
                
                List<int> yeniHaberEtiketEqual = new List<int>();
                //HER ETIKET LISTESI ICIN BIR HABER ETIKET OLUSTURACAGIZ
                foreach (var etiket in etiketListesi)
                {
                    HaberEtiket yeni = new HaberEtiket { HaberID = eklenecekHaberID, EtiketID = etiket.Id };
                    //BOYLE BIR HABERETIKET VARSA EKLEME YAPMICAZ
                    var haberEtiketVarmi = ctx.HaberEtiket.FirstOrDefault(x => x.HaberID == yeni.HaberID && x.EtiketID == yeni.EtiketID);
                    //YOKSA HABERETIKET E SQLDE EKELME YAPICAZ
                    if (haberEtiketVarmi == null)
                    {
                        ctx.HaberEtiket.Add(yeni);
                    }
                    //VE HER HALUKARDA YENI HABERETIKET LISTEMIZE BU HABER ETIKETI EKLIYORUZ
                   
                    yeniHaberEtiketEqual.Add(yeni.EtiketID);

                }
               
                List<int> varolanHaberEtiketEqual = new List<int>();
                foreach (var item in varolanHaberEtiketListesi)
                {
                    
                    varolanHaberEtiketEqual.Add(item.EtiketID);
                }


                //AMAC SU ; YOLLADIGIM VIRGULLU ETIKET LISTESINI EGER OYLE BIR ETIKET YOKSA ETIKET LISTESINE KAYDETMEK ARDINDAN HABERETIKET LISTESINE KAYDETMEK
                // BURADAKI AMAC ISE KALDIRILMIS OLAN ETIKET HABERETIKETTEN KALDIRMAK

                var fazlalik = varolanHaberEtiketEqual.Except(yeniHaberEtiketEqual).ToList();
                foreach (var item in fazlalik)
                {
                    var haberetiket = ctx.HaberEtiket.FirstOrDefault(x => x.EtiketID == item && x.HaberID == eklenecekHaberID);
                    ctx.HaberEtiket.Remove(haberetiket);
                }
            

                ctx.SaveChanges();


            }
        }