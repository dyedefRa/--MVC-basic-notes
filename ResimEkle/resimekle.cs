  //VITRIN RESIM ISLEMLERI
                Image orj = Image.FromStream(vitrinResim.InputStream);
                Bitmap bmOrta = new Bitmap(orj, boyutCeken.ortaBoyutCek);
                string resimAd = Guid.NewGuid() + Path.GetExtension(vitrinResim.FileName);
                string resimOrtaYol = $"/Images/HaberResimleri/OrtaBoyut/" + resimAd;

                //VITRIN RESIM EKLEMEK
                Resim eklenecekResim = new Resim { HaberID = sonhaberID, ResimYol = resimOrtaYol, VitrinMi = true };
                _resimRepository.Insert(eklenecekResim);
                _resimRepository.Save();
                bmOrta.Save(Server.MapPath(resimOrtaYol));