using System.ComponentModel.DataAnnotations;

namespace DreamsBytes.ECommerce.DTOs.Concrete.AppUserDtos
{
    public class AppUserAddDto
    {
        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez")]
        [Display(Name = "Kullanıcı Adı :")]
        public string UserName { get; set; }

        [Display(Name = "Parola :")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Parola alanı boş geçilemez")]
        public string Password { get; set; }

        [Display(Name = "Parolanızı Tekrar Giriniz :")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Parolalar eşleşmiyor")]
        public string ConfirmPassword { get; set; }

        public string Name { get; set; }

        [Display(Name = "Soyadınız :")]
        [Required(ErrorMessage = "Soyad alanı boş geçilemez")]
        public string Surname { get; set; }

        [Display(Name = "Cep Telefonu :")]
        [Required(ErrorMessage = "Cep Telefonu alanı boş geçilemez")]
        [DataType(DataType.PhoneNumber)]
        public int Phone { get; set; }


    }
}
