using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace Web_Projem.Models
{
    public class Paylasim
    {

        public int Id { get; set; }
        public String User { get; set; }
        [Required]
        [Display(Name = "URL giriniz:")]
        public String Url { get; set; }
        public String Aciklama { get; set; }
        public int Begeni { get; set; }
        public List<String> Yorum { get; set; }
    }
}
