using System.ComponentModel.DataAnnotations;

namespace Web_Projem.Models
{
    public class Users
    {
        [Display(Name="Kullanıcı Adı")]
        [Required(ErrorMessage ="Kullanıcı Adı Alanı Zorunlu")]
        public String UserName { get; set; }
        [Required(ErrorMessage ="Şifre Alanı Zorunlu")]
        [Display(Name ="Şifre")]
        public String Password { get; set; }
    }
}
