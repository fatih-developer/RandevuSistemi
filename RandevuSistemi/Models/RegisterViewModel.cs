using System.ComponentModel.DataAnnotations;

namespace RandevuSistemi.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Kullanıcı Adı olmadan olmaz.")]
        [Display(Name = "Kullanıcı Adınız :")]
        public string  Username { get; set; }

        [Required(ErrorMessage = "Adınız olmadan olmaz.")]
        [Display(Name = "Adınız :")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyadı olmadan olmaz.")]
        [Display(Name = "Soyadınız :")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Parola olmadan olmaz.")]
        [Display(Name = "Parolanız :")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required(ErrorMessage = "Email olmadan olmaz.")]
        [Display(Name = "Emailiniz :")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Renk Seçiminiz :")]
        public string Color { get; set; }

        [Display(Name = "Doktor musunuz ?")]
        public bool IsDentist { get; set; }

    }
}