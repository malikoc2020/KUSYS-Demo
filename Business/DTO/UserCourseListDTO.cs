﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
    public class UserCourseListDTO
    {
        public UserCourseListDTO()
        {
            Users = new List<UserDTO>();
        }
        public List<UserDTO> Users { get; set; }
        public UserCourseDTO UserCourseAddorUpdate { get; set; }
    }
}
