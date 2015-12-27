using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Emuher.Models
{
    public class Marka
    {
        public int MarkaID { get; set; }
        [Display(Name = "Marka Adı")]
        [Required(ErrorMessage = "Marka Adını Giriniz")]
        public string MarkaAdi { get; set; }
        public virtual ICollection<Model> MarkaModelFK { get; set; }
    }
}