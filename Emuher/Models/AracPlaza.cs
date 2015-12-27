using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Emuher.Models
{
    public class AracPlaza
    {
        public int AracPlazaID { get; set; }
        [Display(Name = "Model")]
        [Required]
        public int ModelID { get; set; }
        [Display(Name = "Plaza")]
        [Required]
        public int PlazaID { get; set; }
        [Display(Name = "Stok")]
        [Required(ErrorMessage = "Lütfen araç stoğunu giriniz.")]
        public int Stok { get; set; }
        public virtual Model Model { get; set; }
        public virtual Plaza Plaza { get; set; }
    }
}