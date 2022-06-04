﻿using Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserCourse:BaseEntity
    {

        public string UserId { get; set; }
        public int CourseId { get; set; }

        public virtual User User { get; set; }
        public virtual Course Course { get; set; }
    }
}
