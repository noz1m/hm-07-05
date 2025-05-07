using System.Security.Cryptography.X509Certificates;
using Dapper;
using Domain.Entities;
using Infrastructure.Data;
using Npgsql;
namespace Infrastructure.Services;

public class GroupService
{
    private readonly DataContext context = new DataContext();

    public List<Groups> GetAllGroup()
    {
        using (var connection = context.GetDbConnection())
        {
            connection.Open();
            var sql = @$"select * from groups";
            var result = connection.Query<Groups>(sql).ToList();
            return result;
        }
    }
    public void CreateGroup(Groups groups)
    {
        using (var connection = context.GetDbConnection())
        {
            connection.Open();
            var sql = @$"insert into groups (name, courseid) values
                        ('group a', 1),
                        ('group b', 2),
                        ('group c', 3),
                        ('group d', 4),
                        ('group e', 5);";
            var result = connection.Execute(sql,groups);
            Console.WriteLine(result > 0 ? "Success" : "Failed");
        }
    }
    public void UpdateGroup(Groups groups)
    {
        using (var connection = context.GetDbConnection())
        {
            connection.Open();
            var sql = @$"update groups set Name = @name, CourseId = @CourseID where id = @id";
            var result = connection.Execute(sql, groups);
            Console.WriteLine(result > 0 ? "Success" : "Failed");
         }
    }
    public void DeleteGroup(int id)
    {
        using (var connection = context.GetDbConnection())
        {
            connection.Open();
            var sql = @$"delete from groups where id = @id";
            var result = connection.Execute(sql,id);
            Console.WriteLine(result > 0 ? "Success" : "Failed");
        }
    }
    public IEnumerable<Groups> GetGroupsByCourseIdAsync(int courseId)
    {
        using (var connection = context.GetDbConnection())
        {
            connection.Open();
            var sql = @$"select g.* from groups g join courses c on g.courseId = c.id
            where g.courseId = @CourseId";
            var result = connection.Query<Groups>(sql, new {CourseId = courseId}).ToList();
            return result;
        }
    }
    
}





