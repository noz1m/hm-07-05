using Domain.DTO;
using Domain.DTO;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Services;
namespace Infrastructure.Interface;

public interface ICourseService
{
    public List<Courses> GetAllCourses();
    public void CreateCourse(Courses courses);
    public void UpdateCourse(Courses courses);
    public void DeleteCourse(int id);
}