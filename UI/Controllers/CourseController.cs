using Business.CourseService;
using Business.DTO;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CourseController : Controller
    {

        private readonly ILogger<CourseController> _logger;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        public readonly ICourseService _courseService;
        public CourseController(ILogger<CourseController> logger, UserManager<User> userManager, RoleManager<Role> roleManager, ICourseService courseService)
        {
            _logger = logger;
            _userManager = userManager;
            _roleManager = roleManager;
            _courseService = courseService;
        }

        public IActionResult CourseList()
        {
            var model = new CourseListDTO();
            var courses = _courseService.Courses().Select(c => new CourseDTO() { CourseCode = c.CourseCode, Id = c.Id, Name = c.Name }).ToList();
            model.Courses = courses;
 
            return View(model);
        }

        [HttpPost]
        public JsonResult Get(int id)
        {
            var res = new ReturnObjectDTO();

            var model = _courseService.Courses().Where(x=>x.Id == id).Select(c => new CourseDTO() { CourseCode = c.CourseCode, Id = c.Id, Name = c.Name }).FirstOrDefault();

            if (model == null)
            {
                res.isSuccess = false;
                res.errorMessage = "Kurs bulunamadı.";
            }
            else
            {
                res.data = model;
            }

            return new JsonResult(res);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            var res = _courseService.DeleteCourse(id);           

            return new JsonResult(res);
        }

        [HttpPost]
        public JsonResult Add(CourseListDTO courseList)
        {
            var validationMessage = string.Join(" | ", ModelState.Values
            .SelectMany(v => v.Errors)
            .Select(e => e.ErrorMessage));
            CourseDTO course = courseList.CourseAddorUpdate;
            var res = new ReturnObjectDTO();

            //update objesinin olmamasını dikkate alma! Burada insert işlemi yapılıyor. 
            if (ModelState.IsValid|| validationMessage == "The UserForUpdate field is required.")
            { 
                res = _courseService.AddCourse(course);                           }
            else
            {
                res.isSuccess = false;
                res.errorMessage = validationMessage;
            }
            return new JsonResult(res);
        }

        [HttpPost]
        public JsonResult Update(CourseListDTO courseList)
        {
            var validationMessage = string.Join(" | ", ModelState.Values
            .SelectMany(v => v.Errors)
            .Select(e => e.ErrorMessage));
            CourseDTO course = courseList.CourseAddorUpdate;
            var res = new ReturnObjectDTO();

            //update objesinin olmamasını dikkate alma! Burada insert işlemi yapılıyor. 
            if (ModelState.IsValid || validationMessage == "The UserForUpdate field is required.")
            {
                res = _courseService.UpdateCourse(course.Id, course);
            }
            else
            {
                res.isSuccess = false;
                res.errorMessage = validationMessage;
            }
            return new JsonResult(res);
        }












        public IActionResult UserDetailList()
        {
            var model = new UserRoleDTO();
            var users = _userManager.Users.Include(u => u.UserRoles).ThenInclude(ur => ur.Role)
                .Select(x => new UserDTO()
                {
                    Id = x.Id,
                    UserName = x.UserName,
                    AccessFailedCount = x.AccessFailedCount,
                    ConcurrencyStamp = x.ConcurrencyStamp,
                    Email = x.Email,
                    EmailConfirmed = x.EmailConfirmed,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    LockoutEnabled = x.LockoutEnabled,
                    PhoneNumberConfirmed = x.PhoneNumberConfirmed,
                    LockoutEnd = x.LockoutEnd,
                    NormalizedEmail = x.NormalizedEmail,
                    NormalizedUserName = x.NormalizedUserName,
                    PhoneNumber = x.PhoneNumber,
                    PictureUrl = x.PictureUrl,
                    TwoFactorEnabled = x.TwoFactorEnabled,
                    SecurityStamp = x.SecurityStamp,
                    TC = x.TC,
                    BirthDate = x.BirthDate,
                    Roles = x.UserRoles.Select(y => new RoleDTO() { Id = y.RoleId, Name = y.Role.Name }).ToList()
                }).ToList();

            model.Users = users;

            var allRoles = _roleManager.Roles.Select(x => new RoleDTO() { Id = x.Id, Name = x.Name }).ToList();
            ViewBag.AllRoles = allRoles;
            ViewBag.RoleUserId = allRoles.Where(x => x.Name == "User").FirstOrDefault()?.Id;
            return View(model);
        }


    }
}
