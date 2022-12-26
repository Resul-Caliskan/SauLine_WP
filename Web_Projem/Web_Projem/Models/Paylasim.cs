using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace Web_Projem.Models
{
    public class Paylasim
    {
        
       
        public String User { get; set; }
        [Required]
        [Display(Name ="URL giriniz:")]
        public String Url { get; set; }
        List<String> Begenenler { get; set; }
        List<String> yorumlar { get; set; }
    }
}
