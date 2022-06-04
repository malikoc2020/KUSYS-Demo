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
        public string Name { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
