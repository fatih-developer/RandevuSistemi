using System.ComponentModel.DataAnnotations;

namespace RandevuSistemi.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Kullanıcı Adı olmadan olmaz.")]
        [Display(Name = "Kullanıcı Adınız :")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Parola olmadan olmaz.")]
        [Display(Name = "Parolanız :")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Display(Name = "Beni Hatırla")] 
        public bool RememberMe { get; set; }



    }
}