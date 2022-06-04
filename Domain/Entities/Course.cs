using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Course:BaseEntity
    {
        public string CourseCode { get; set; }
        public string Name { get; set; }
        //public ICollection<User> CourseUsers { get; set; }
        public ICollection<UserCourse> CourseUsers { get; set; }
        //public string UserId { get; set; }
        //public User User { get; set; }
    }
}
