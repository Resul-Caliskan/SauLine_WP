using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OgrTum.Models
{
    public class Ogrenci
    {
        [Display(Name = "Öğrenci No")]
        public string OgrNo { get; set; }
        [Required(ErrorMessage = "Ad alanı zorunlu")]
        [Display(Name = "Öğrenci Ad")]
        public string OgrAd { get; set; }
        [Display(Name = "Öğrenci Soyad")]
        public string OgrSoyad { get; set; }
    }
   
}
