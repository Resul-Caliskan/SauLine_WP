using Microsoft.Build.Framework;

namespace Web_Projem.Models
{
    public class Paylasim
    {
        [Required]
        public String User { get; set; }
        [Required]
        public String Url { get; set; }
        List<String> Begenenler { get; set; }
        List<String> yorumlar { get; set; }
    }
}
