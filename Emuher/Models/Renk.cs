using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Emuher.Models
{
    public class Renk
    {
        public int RenkID { get; set; }
        [Display(Name = "Renk Adı")]
        [Required(ErrorMessage = "Lütfen renk adını giriniz.")]
        public string RenkAdi { get; set; }
        public virtual ICollection<AracRenk> AracRenkFK { get; set; }
    }
}