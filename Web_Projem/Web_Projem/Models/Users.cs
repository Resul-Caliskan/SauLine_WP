using System.ComponentModel.DataAnnotations;

namespace Web_Projem.Models
{
    public class Users
    {
        [Display(Name="Kullanıcı Adı")]
        [Required]
        public String UserName { get; set; }
        [Required]
        [Display(Name ="Şifre")]
        public String Password { get; set; }
    }
}
