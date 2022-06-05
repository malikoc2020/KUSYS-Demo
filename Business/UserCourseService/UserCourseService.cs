using Business.DTO;
using Domain.Entities;
using EFCore.Repository.Repository;
using EFCore.Repository.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Business.UserCourseService
{
    public class UserCourseService : IUserCourseService
    {
        private readonly IRepository<UserCourse> repository;
        private readonly IUnitOfWork unitOfWork;
        public UserCourseService(IRepository<UserCourse> repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }
        public IQueryable<UserCourse> UserCourses()
        {
            return repository.GetAll();
        }
        public ReturnObjectDTO GetUserCourse(int id)
        {
            var UserCourse = UserCourses().FirstOrDefault(x => x.Id == id);
            return new ReturnObjectDTO() { data = UserCourse, successMessage = "İşlem Başarılı" };
        }
        public ReturnObjectDTO GetAllUserCourses()
        {
            var UserCourses = repository.GetAll().ToList();
            return new ReturnObjectDTO() { data = UserCourses };
        }
        public ReturnObjectDTO AddUserCourse(UserCourseDTO UserCourse)
        {
            try
            {
                var UserCourseEntity = new UserCourse()
                {
                    UserId = UserCourse.UserId,
                    CourseId = UserCourse.CourseId,
                    DateCreated = DateTime.Now,
                    IsActive = true
                };

                repository.Add(UserCourseEntity);
                unitOfWork.Commit();

                //UserCourse.Id = UserCourseEntity.Id;

                var res = UserCourses().Include(x=>x.Course).Where(x=>x.Id == UserCourseEntity.Id).Select(x=>new UserCourseDTO() {Id = x.Id,  CourseId = x.CourseId, UserId = x.UserId, Course = new CourseDTO() {Id = x.Course.Id, CourseCode = x.Course.CourseCode, Name = x.Course.Name } }).FirstOrDefault();

                return new ReturnObjectDTO() { data = res, successMessage = "İşlem Başarılı" };
            }
            catch (Exception)
            {
                return new ReturnObjectDTO() { isSuccess = false, errorMessage = "İşlem BAŞARISIZ." };
            }
        }
        public ReturnObjectDTO UpdateUserCourse(int id, UserCourseDTO UserCourse, string updatedBy = "")
        {
            if (id != UserCourse.Id)
            {
                return new ReturnObjectDTO() { isSuccess = false, errorMessage = "İşlem BAŞARISIZ. Güncellenecek Kayıt Bilgisi Bulunamadı." };
            }

            var entity = repository.GetById(id);// GetUserCourse(id);
            if (entity == null)
            {
                return new ReturnObjectDTO() { isSuccess = false, errorMessage = "İşlem BAŞARISIZ. Güncellenecek Kayıt Bilgisi Bulunamadı.(2)" };
            }

            entity.UserId = UserCourse.UserId;
            entity.CourseId = UserCourse.CourseId;
            try
            {
                repository.Update(entity);
                unitOfWork.Commit();

                var res = UserCourses().Include(x => x.Course).Where(x => x.Id == entity.Id).Select(x => new UserCourseDTO() { Id = x.Id, CourseId = x.CourseId, UserId = x.UserId, Course = new CourseDTO() { Id = x.Course.Id, CourseCode = x.Course.CourseCode, Name = x.Course.Name } }).FirstOrDefault();

                return new ReturnObjectDTO() { data = res, successMessage = "İşlem Başarılı" };
            }
            catch (Exception)
            {
                return new ReturnObjectDTO() { isSuccess = false, errorMessage = "İşlem BAŞARISIZ." };
            }
        }
        public ReturnObjectDTO DeleteUserCourse(int id, string updatedBy = "")
        {
            var entity = repository.GetById(id);//GetUserCourse(id);
            if (entity == null)
            {
                return new ReturnObjectDTO() { isSuccess = false, errorMessage = "İşlem BAŞARISIZ. Silinecek Kayıt Bilgisi Bulunamadı.(2)" };
            }

            try
            {
                repository.Delete(entity);
                unitOfWork.Commit();
                return new ReturnObjectDTO() { successMessage = "İşlem Başarılı" };
            }
            catch (Exception)
            {
                return new ReturnObjectDTO() { isSuccess = false, errorMessage = "İşlem BAŞARISIZ." };
            }

        }

    }
}
