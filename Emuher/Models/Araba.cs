using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Emuher.Models
{
    public class Araba
    {
        public int MyProperty { get; set; }
        public int ArabaID { get; set; }
        [Required]
        public int ModelID { get; set; }
        [Display(Name = "Fiyat")]
        [Required(ErrorMessage = "Lütfen araç fiyatını giriniz.")]
        public int Fiyat { get; set; }
        [Display(Name = "Kilometre")]
        [Required(ErrorMessage = "Lütfen araç km'sini giriniz.")]
        public int Kilometre { get; set; }
        [Display(Name = "Şanzıman Tipi")]
        [Required(ErrorMessage = "Lütfen araç şanzıman tipini giriniz.")]
        public string SanzimanTipi { get; set; }
        [Display(Name = "Yakıt Tipi")]
        [Required(ErrorMessage = "Lütfen araç yakıt tipini giriniz.")]
        public string YakitTipi { get; set; }

        internal static IQueryable<Araba> OrderByDescending(Func<object, object> p)
        {
            throw new NotImplementedException();
        }

        internal static IQueryable<Araba> OrderBy(Func<object, object> p)
        {
            throw new NotImplementedException();
        }

        [Display(Name = "Gövde Tipi")]
        [Required(ErrorMessage = "Lütfen araç gövde tipini giriniz.")]
        public string GovdeTipi { get; set; }
        [Display(Name = "Motor Gücü")]
        [Required(ErrorMessage = "Lütfen araç motor gücünü giriniz.")]
        public string MotorGucu { get; set; }
        [Display(Name = "Resim")]
        [DataType(DataType.ImageUrl, ErrorMessage = "Lütfen resim yolunuzu doğru şekilde giriniz.")]
        public string Resim { get; set; }
        public virtual Model Model { get; set; }
    }
}