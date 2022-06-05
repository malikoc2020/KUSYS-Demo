using Business.CourseService;
using Business.DTO;
using Business.UserCourseService;
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
        private readonly ICourseService _courseService;
        public UserCourseController(ILogger<UserCourseController> logger, UserManager<User> userManager, RoleManager<Role> roleManager, IUserCourseService userCourseService, ICourseService courseService)
        {
            _logger = logger;
            _userManager = userManager;
            _roleManager = roleManager;
            _userCourseService = userCourseService;
            _courseService = courseService;
        }


        public IActionResult UserCourseList()
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

            var allCourses = _courseService.Courses().Select(x => new CourseDTO() { Id = x.Id, Name = x.Name, CourseCode = x.CourseCode}).ToList();
           // allCourses.Prepend(new CourseDTO() { Id = -1, CourseCode = "", Name = "-Seçiniz-" });
            ViewBag.AllCourses = allCourses;

            return View(model);
        }

        [HttpPost]
        public JsonResult AddUserCourse(UserCourseListDTO userList)
        {

            UserCourseDTO userCourse = userList.UserCourseAddorUpdate;
            var res = new ReturnObjectDTO();

            var validationMessage = string.Join(" | ", ModelState.Values
           .SelectMany(v => v.Errors)
           .Select(e => e.ErrorMessage));


            if (ModelState.IsValid || validationMessage== "The Course field is required.")
            {
                res = _userCourseService.AddUserCourse(userCourse);
            }
            else
            {
                res.isSuccess = false;
                res.errorMessage = "Model is not valid!";
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
        public JsonResult UpdateUserCourse(UserCourseListDTO userList)
        {
            UserCourseDTO userCourse = userList.UserCourseAddorUpdate;
            var res = new ReturnObjectDTO();

            var validationMessage = string.Join(" | ", ModelState.Values
           .SelectMany(v => v.Errors)
           .Select(e => e.ErrorMessage));

            if (ModelState.IsValid || validationMessage == "The Course field is required.")
            {
                res = _userCourseService.UpdateUserCourse(userCourse.Id, userCourse);
            }
            else
            {
                res.isSuccess = false;
                res.errorMessage = "Model is not valid!";
            }
            return new JsonResult(res);
        }

        [HttpPost]
        public JsonResult DeleteUserCourse(int id)
        {
            var res = _userCourseService.DeleteUserCourse(id);

            return new JsonResult(res);
        }


    }
}
