using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Emuher.Models;

namespace Emuher.DAL
{
    public class EmuherBaslangicData : System.Data.Entity.DropCreateDatabaseIfModelChanges<EmuherContext>
    {
        protected override void Seed(EmuherContext context)
        {
            var Musteri = new List<Musteri>
            {
                new Musteri { Adsoy="Erkan Ceylan",KullaniciAdi="erkan",Sifre="1234",Telefon="05517187319",Email="erkanceylan4@gmail.com",Adres="Kyk Erkek Yurdu - Sakarya",KayitTarihi=Convert.ToDateTime("2015-06-04")},
                new Musteri { Adsoy="Emre Uysal",KullaniciAdi="emre",Sifre="1234",Telefon="05517187349",Email="emre@gmail.com",Adres="Bahçelievler No:75 - Sakarya",KayitTarihi=Convert.ToDateTime("2013-04-04")},
                new Musteri { Adsoy="Muhammet Akgümüş",KullaniciAdi="muhammed",Sifre="1234",Telefon="05513487319",Email="muhammed@gmail.com",Adres="Çiçek Apartmanı No:23/4 - Ankaraa",KayitTarihi=Convert.ToDateTime("2012-06-04")},
                new Musteri { Adsoy="Esra",KullaniciAdi="esra5423",Sifre="1234",Telefon="05517567319",Email="esra@hotmail.com",Adres="Abraham Lincoln St. No:45/8 - California USA",KayitTarihi=Convert.ToDateTime("2015-02-04")},
                new Musteri { Adsoy="Ayşe Topal",KullaniciAdi="ayse1",Sifre="abcd",Telefon="05517167899",Email="ayse4@gmail.com",Adres="Ayça Kız Öğrenci Yurdu - Isparta",KayitTarihi=Convert.ToDateTime("2014-11-04")},
                new Musteri { Adsoy="Emin Ersek",KullaniciAdi="emin",Sifre="xyz123",Telefon="05512347319",Email="emine54@hotmail.com",Adres="Greenwich - Londra",KayitTarihi=Convert.ToDateTime("2015-08-04")}
            };
            Musteri.ForEach(s => context.Musteri.Add(s));
            var Renk = new List<Renk>
            {
                new Renk { RenkAdi="Metalik"},
                new Renk { RenkAdi="Beyaz"},
                new Renk { RenkAdi="Siyah"},
                new Renk { RenkAdi="Lacivert"},
                new Renk { RenkAdi="Mavi"},
                new Renk { RenkAdi="Kırmızı"},
                new Renk { RenkAdi="Benzin Yeşili"},
                new Renk { RenkAdi="Metalik Gri"},
                new Renk { RenkAdi="Zümrüt Yeşili"}
            };
            Renk.ForEach(s => context.Renk.Add(s));
            var Marka = new List<Marka>
            {
                new Marka { MarkaAdi="Ford"},
                new Marka { MarkaAdi="Toyota"},
                new Marka { MarkaAdi="Audi"},
                new Marka { MarkaAdi="Fiat"},
                new Marka { MarkaAdi="BMW"},
                new Marka { MarkaAdi="Renault"},
                new Marka { MarkaAdi="Ferrari"},
                new Marka { MarkaAdi="Porsche"}
            };
            Marka.ForEach(s => context.Marka.Add(s));
            var Model = new List<Model>
            {
                new Model { MarkaID=1,ModelAdi="Fiesta"},
                new Model { MarkaID=1,ModelAdi="Focus"},
                new Model { MarkaID=1,ModelAdi="Kuga"},
                new Model { MarkaID=1,ModelAdi="Mondeo"},
                new Model { MarkaID=2,ModelAdi="Auris"},
                new Model { MarkaID=2,ModelAdi="Corolla"}
            };
            Model.ForEach(s => context.Model.Add(s));
            context.SaveChanges();
            var Araba = new List<Araba>
            {
                new Araba {ModelID=1,Fiyat = 65000,Kilometre=0,SanzimanTipi="Otomatik",YakitTipi="Dizel",GovdeTipi="Hatchback",MotorGucu="1500 hp",Resim= "~/images/ford_titanium_blue.jpg"},
                new Araba {ModelID=2,Fiyat = 35000,Kilometre=0,SanzimanTipi="Otomatik",YakitTipi="Dizel",GovdeTipi="Hatchback",MotorGucu="1500 hp",Resim= "~/images/ford_titanium_blue.jpg"},
                new Araba {ModelID=3,Fiyat = 45000,Kilometre=0,SanzimanTipi="Otomatik",YakitTipi="Dizel",GovdeTipi="Hatchback",MotorGucu="1500 hp",Resim= "~/images/ford_titanium_blue.jpg"},
                new Araba {ModelID=1,Fiyat = 85000,Kilometre=0,SanzimanTipi="Otomatik",YakitTipi="Dizel",GovdeTipi="Hatchback",MotorGucu="1500 hp",Resim= "~/images/ford_titanium_blue.jpg"},
                new Araba {ModelID=4,Fiyat = 35000,Kilometre=0,SanzimanTipi="Otomatik",YakitTipi="Dizel",GovdeTipi="Hatchback",MotorGucu="1500 hp",Resim= "~/images/ford_titanium_blue.jpg"},
                new Araba {ModelID=4,Fiyat = 25000,Kilometre=0,SanzimanTipi="Otomatik",YakitTipi="Dizel",GovdeTipi="Hatchback",MotorGucu="1500 hp",Resim= "~/images/ford_titanium_blue.jpg"},
                new Araba {ModelID=5,Fiyat = 25000,Kilometre=0,SanzimanTipi="Otomatik",YakitTipi="Dizel",GovdeTipi="Hatchback",MotorGucu="1500 hp",Resim= "~/images/ford_titanium_blue.jpg"},
                new Araba {ModelID=2,Fiyat = 15000,Kilometre=0,SanzimanTipi="Otomatik",YakitTipi="Dizel",GovdeTipi="Hatchback",MotorGucu="1500 hp",Resim= "~/images/ford_titanium_blue.jpg"},
                new Araba {ModelID=2,Fiyat = 455000,Kilometre=0,SanzimanTipi="Otomatik",YakitTipi="Dizel",GovdeTipi="Hatchback",MotorGucu="1500 hp",Resim= "~/images/ford_titanium_blue.jpg"},
                new Araba {ModelID=3,Fiyat = 56000,Kilometre=0,SanzimanTipi="Otomatik",YakitTipi="Dizel",GovdeTipi="Hatchback",MotorGucu="1500 hp",Resim= "~/images/ford-kuga-white.jpg"}
            };
            Araba.ForEach(s => context.Araba.Add(s));

            var Plaza = new List<Plaza>
            {
                new Plaza {PlazaAdi="İstanbul Emuher",Adres="Caddebostan Sahili, İstanbul",Telefon="02127858934",Email="istanbul@emuher.com" },
                new Plaza {PlazaAdi="Ankara Emuher",Adres="Kızılay, Ankara",Telefon="02327858934",Email="izmir@emuher.com" },
                new Plaza {PlazaAdi="İzmir Emuher",Adres="Konak, İzmir",Telefon="02167858934",Email="ankara@emuher.com" },
                new Plaza {PlazaAdi="Sakarya Emuher",Adres="Esentepe Kampüsü, Sakarya",Telefon="02647858934",Email="sakarya@emuher.com" }

            };
            Plaza.ForEach(s => context.Plaza.Add(s));
            var Admin = new List<Admin>
            {
                new Models.Admin { KullaniciAdi="muhammed",Sifre="1234"},
                new Models.Admin { KullaniciAdi="erkan",Sifre="1234"},
                new Models.Admin { KullaniciAdi="emre",Sifre="1234"}
            };
            Admin.ForEach(s => context.Admin.Add(s));
            context.SaveChanges();
        }
    }
}