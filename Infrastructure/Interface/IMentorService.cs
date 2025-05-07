using Domain.DTO;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Services;
namespace Infrastructure.Interface;

public interface IMentorService
{
    public List<Mentors> GetAllMentors();
    public void CreateMentors(Mentors mentors);
    public void UpdateMentors(Mentors mentors);
    public void DeleteMentors(int id);
}
