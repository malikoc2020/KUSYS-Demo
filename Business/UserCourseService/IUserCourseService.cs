using Business.DTO;
using Domain.Entities;

namespace Business.UserCourseService
{
    public interface IUserCourseService
    {
        IQueryable<UserCourse> UserCourses();
        ReturnObjectDTO GetUserCourse(int id);
        ReturnObjectDTO GetAllUserCourses();
        ReturnObjectDTO AddUserCourse(UserCourseDTO UserCourse, string insertedBy = "");
        ReturnObjectDTO UpdateUserCourse(int id, UserCourseDTO UserCourse, string updatedBy = "");
        ReturnObjectDTO DeleteUserCourse(int id, string updatedBy = "");
    }
}
