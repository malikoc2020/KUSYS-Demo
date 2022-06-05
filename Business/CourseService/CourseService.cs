using Business.DTO;
using Domain.Entities;
using EFCore.Repository.Repository;
using EFCore.Repository.UnitOfWork;

namespace Business.CourseService
{
    public class CourseService : ICourseService
    {
        private readonly IRepository<Course> repository;
        private readonly IUnitOfWork unitOfWork;
        public CourseService(IRepository<Course> repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }
        public IQueryable<Course> Courses()
        {
            return repository.GetAll();
        }
        public ReturnObjectDTO GetCourse(int id)
        {
            var Course = Courses().FirstOrDefault(x => x.Id == id);
            return new ReturnObjectDTO() { data = Course, successMessage = "İşlem Başarılı" };
        }
        public ReturnObjectDTO GetAllCourses()
        {
            var Courses = repository.GetAll().ToList();
            return new ReturnObjectDTO() { data = Courses };
        }
        public ReturnObjectDTO AddCourse(CourseDTO Course)
        {
            try
            {
                var CourseEntity = new Course()
                {
                    CourseCode = Course.CourseCode,
                    Name = Course.Name,
                    DateCreated = DateTime.Now,
                    IsActive = true
                };

                repository.Add(CourseEntity);
                unitOfWork.Commit();

                Course.Id = CourseEntity.Id;
                return new ReturnObjectDTO() { data = Course, successMessage = "İşlem Başarılı" };
            }
            catch (Exception)
            {
                return new ReturnObjectDTO() { isSuccess = false, errorMessage = "İşlem BAŞARISIZ." };
            }
        }
        public ReturnObjectDTO UpdateCourse(int id, CourseDTO Course, string updatedBy = "")
        {
            if (id != Course.Id)
            {
                return new ReturnObjectDTO() { isSuccess = false, errorMessage = "İşlem BAŞARISIZ. Güncellenecek Kayıt Bilgisi Bulunamadı." };
            }

            var entity = repository.GetById(id);// GetCourse(id);
            if (entity == null)
            {
                return new ReturnObjectDTO() { isSuccess = false, errorMessage = "İşlem BAŞARISIZ. Güncellenecek Kayıt Bilgisi Bulunamadı.(2)" };
            }

            entity.CourseCode = Course.CourseCode;
            entity.Name = Course.Name;
            try
            {
                repository.Update(entity);
                unitOfWork.Commit();
                return new ReturnObjectDTO() { data = Course, successMessage = "İşlem Başarılı" };
            }
            catch (Exception)
            {
                return new ReturnObjectDTO() { isSuccess = false, errorMessage = "İşlem BAŞARISIZ." };
            }
        }
        public ReturnObjectDTO DeleteCourse(int id, string updatedBy = "")
        {
            var entity = repository.GetById(id);//GetCourse(id);
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
