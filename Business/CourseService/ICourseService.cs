using Business.DTO;
using Domain.Entities;

namespace Business.CourseService
{
    public interface ICourseService
    {
        IQueryable<Course> Courses();
        ReturnObjectDTO GetCourse(int id);
        ReturnObjectDTO GetAllCourses();
        ReturnObjectDTO AddCourse(CourseDTO Course, string insertBy = "");
        ReturnObjectDTO UpdateCourse(int id, CourseDTO Course, string updatedBy = "");
        ReturnObjectDTO DeleteCourse(int id, string updatedBy = "");
    }
}
