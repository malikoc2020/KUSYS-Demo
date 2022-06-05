using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
    public class CourseListDTO
    {
        public CourseListDTO()
        {
            Courses = new List<CourseDTO>();
        }
        public List<CourseDTO> Courses { get; set; }
        public CourseDTO CourseAddorUpdate { get; set; }
    }
}
