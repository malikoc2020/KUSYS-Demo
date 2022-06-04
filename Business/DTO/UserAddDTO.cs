using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
    public class UserAddDTO
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Ad girilmesi zorunlu!1")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Soyad girilmesi zorunlu!1")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "KullanıcıAdı girilmesi zorunlu!1")]

        public string UserName { get; set; }
        [Required(ErrorMessage = "Email girilmesi zorunlu!")]
        [EmailAddress(ErrorMessage = "Email hatalı!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Şifre girilmesi zorunlu!")]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{6,}$", ErrorMessage = "Şifre en az 1 küçük harf, 1 büyük harf, 1 rakam ve bir sembolden oluşan en az 6 karakterlik bir ifade olmalıdır!")]
        public string Password { get; set; }

        public string? PhoneNumber { get; set; }
        [Required(ErrorMessage = "Rol seçimi zorunlu!")]
        public string RoleSelected { get; set; }
        [Required(ErrorMessage = "T.C. Kimlik No girilmesi zorunlu!")]
        public string TC { get; set; }
        [Required(ErrorMessage = "Doğum tarihi girilmesi zorunlu!")]
        public DateTime BirthDate { get; set; }

    }
}
