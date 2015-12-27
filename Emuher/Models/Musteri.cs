using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Emuher.Models
{
    public class Musteri
    {
        public int MusteriID { get; set; }
        [Display(Name = "Ad Soyad")]
        [Required(ErrorMessage = "Lütfen adınızı giriniz.")]
        public string Adsoy { get; set; }
        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Lütfen kullanıcı adınızı giriniz.")]
        public string KullaniciAdi { get; set; }
        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Lütfen şifrenizi giriniz.")]
        public string Sifre { get; set; }
        [Display(Name = "Telefon")]
        [Required(ErrorMessage = "Telefon numaranızı giriniz.")]
        //   [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",ErrorMessage ="Lütfen geçerli bir telefon numarası giriniz.")]
        public string Telefon { get; set; }
        [Display(Name = "E-Mail")]
        [Required(ErrorMessage = "Lütfen e-posta adresinizi giriniz.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Lütfen e-posta adresinizi geçerli bir formatta giriniz.")]
        public string Email { get; set; }
        [Display(Name = "Adres")]
        [Required(ErrorMessage = "Lütfen adresinizi giriniz.")]
        public string Adres { get; set; }
        [Display(Name = "Kayıt Tarihi")]
        public DateTime KayitTarihi { get; set; }
    }
}