using Business.DTO;
using Business.UserUserCourseService;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace UI.Controllers
{
    [Authorize]
    public class UserCourseController : Controller
    {

        private readonly ILogger<UserCourseController> _logger;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IUserCourseService _userCourseService;
        public UserCourseController(ILogger<UserCourseController> logger, UserManager<User> userManager, RoleManager<Role> roleManager, IUserCourseService userCourseService)
        {
            _logger = logger;
            _userManager = userManager;
            _roleManager = roleManager;
            _userCourseService = userCourseService; 
        }


        public IActionResult UserCarList()
        {
            var model = new UserCourseListDTO();
            var users = _userManager.Users.Include(u => u.UserCourses).ThenInclude(i=>i.Course)
                .Select(x => new UserDTO()
                {
                    Id = x.Id,
                    Email = x.Email,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    PhoneNumber = x.PhoneNumber,
                    UserCourses = x.UserCourses.Select(y => new UserCourseDTO() { Id = y.Id, CourseId = y.CourseId, UserId = x.Id, Course = new CourseDTO() {Id = y.Course.Id, CourseCode  = y.Course.CourseCode, Name = y.Course.Name } }).ToList()

                }).ToList();

            model.Users = users;

            return View(model);
        }

        [HttpPost]
        public JsonResult AddUserCourse(UserCourseListDTO userList)
        {
            UserCourseDTO userCourse = userList.UserCourseAddorUpdate;
            var res = new ReturnObjectDTO();

            if (ModelState.IsValid)
            {
                res = _userCourseService.AddUserCourse(userCourse);
            }
            else
            {
                res.isSuccess = false;
                res.errorMessage = "";
            }
            return new JsonResult(res);
        }

        [HttpPost]
        public JsonResult GetUserCourse(int id)
        {
            var res = _userCourseService.GetUserCourse(id);

            return new JsonResult(res);
        }

        [HttpPost]
        public JsonResult UpdateCar(UserCourseListDTO userList)
        {
            UserCourseDTO userCourse = userList.UserCourseAddorUpdate;
            var res = new ReturnObjectDTO();

            if (ModelState.IsValid)
            {
                res = _userCourseService.UpdateUserCourse(userCourse.Id, userCourse);
            }
            else
            {
                res.isSuccess = false;
                res.errorMessage = "";
            }
            return new JsonResult(res);
        }

        [HttpPost]
        public JsonResult DeleteCar(int id)
        {
            var res = _userCourseService.DeleteUserCourse(id);

            return new JsonResult(res);
        }


    }
}
