using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
    public class UserCourseDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Kullanıcı Adı girilmesi zorunlu!")]
        public string UserId { get; set; }
        [Required(ErrorMessage = "Kurs seçimi zorunlu!")]
        public int CourseId { get; set; }

        //public virtual User User { get; set; }
        public virtual CourseDTO Course { get; set; }
    }
}
