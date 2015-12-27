using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Emuher.Models
{
    public class Model
    {
        public int ModelID { get; set; }
        [Required]
        public int MarkaID { get; set; }
        [Display(Name = "Model Adı")]
        [Required(ErrorMessage = "Marka adı giriniz.")]
        public string ModelAdi { get; set; }
        public virtual Marka Marka { get; set; }
        public virtual ICollection<AracRenk> ModelRenkFK { get; set; }
        public virtual ICollection<AracPlaza> ModelPlazaFK { get; set; }
        public virtual ICollection<Araba> ModelArabaFK { get; set; }
        public static IEnumerable<object> Musteri { get; internal set; }
    }
}