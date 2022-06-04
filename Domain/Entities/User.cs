using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Column(TypeName = "Date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime BirthDate { get; set; }
        public string PictureUrl { get; set; }
        public string TC { get; set; }
        [NotMapped]
        public string DefaultRole { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }

        public ICollection<UserCourse> UserCourses { get; set; }

        //[ForeignKey("CourceId")]
        //public string CourceId { get; set; }
        //public Course Course { get; set; }

        //public ICollection<Course> UserCourses { get; set; }
        //[InverseProperty("SendUser")]
        //public virtual ICollection<Message> SendedMessages { get; set; }
        //[InverseProperty("ReceiveUser")]
        //public virtual ICollection<Message> ReceivedMessages { get; set; }
    }
}
