using Domain.DTO;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Services;
namespace Infrastructure.Interface;

public interface IStudentService
{
    public List<Students> GetAllStudents();
    public void CreateStudents(Students students);
    public void UpdateStudents(Students students);
    public void DeleteStudent(Students students);
}
