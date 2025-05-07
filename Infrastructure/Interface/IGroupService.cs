using Domain.DTO;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Services;
namespace Infrastructure.Interface;

public interface IGroupService
{
    public List<Groups> GetAllGroup();
    public void CreateGroup(Groups groups);
    public void UpdateGroup(Groups groups);
    public void DeleteGroup(int id);
}
