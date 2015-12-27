using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Emuher.Models
{
    public class AracRenk
    {
        public int AracRenkID { get; set; }
        [Display(Name = "Model")]
        [Required]
        public int ModelID { get; set; }
        [Display(Name = "Renk")]
        [Required]
        public int RenkID { get; set; }
        public virtual Model Model { get; set; }
        public virtual Renk Renk { get; set; }
    }
}