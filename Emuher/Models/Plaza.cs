using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Emuher.Models
{
    public class Plaza
    {
        public int PlazaID { get; set; }
        [Display(Name = "Plaza Adı")]
        [Required(ErrorMessage = "Lütfen plaza adını giriniz.")]
        public string PlazaAdi { get; set; }
        [Display(Name = "Adres")]
        [Required(ErrorMessage = "Lütfen plaza adresini giriniz.")]
        public string Adres { get; set; }
        [Display(Name = "Telefon")]
        [Required(ErrorMessage = "Lütfen plaza telefon numarasını giriniz.")]
        //     [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Lütfen plaza telefonunu giriniz.")]
        public string Telefon { get; set; }
        [Display(Name = "E-Mail")]
        [Required(ErrorMessage = "Lütfen plaza e-mail'ini giriniz.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Lütfen e-posta adresini geçerli bir formatta giriniz.")]
        public string Email { get; set; }
        public virtual ICollection<AracPlaza> AracPlazaFK { get; set; }
    }
}