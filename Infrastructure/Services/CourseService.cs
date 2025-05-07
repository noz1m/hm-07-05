using Dapper;
using Domain.Entities;
using Infrastructure.Data;
using Npgsql;
namespace Infrastructure.Services;

public class CourseService
{
    private readonly DataContext context = new DataContext();

    public List<Courses> GetAllCourses()
    {
        using (var connection = context.GetDbConnection())
        {
            connection.Open();
            var sql = @$"select * courses";
            var result = connection.Query<Courses>(sql).ToList();
            return result;
        }
    }
    public void CreateCourse(Courses courses)
    {
        using (var connection = context.GetDbConnection())
        {
            connection.Open();
            var sql = @$"insert into courses (name, duration) values
                        ('web development', 6),
                        ('data science', 9),
                        ('cyber security', 8),
                        ('mobile apps', 7),
                        ('game design', 10);";
            var result = connection.Execute(sql, courses);
            Console.WriteLine(result > 0 ? "Success" : "Failed");
        }
    }
    public void UpdateCourse(Courses courses)
    {
        using (var connection = context.GetDbConnection())
        {
            connection.Open();
            var sql = @$"update courses set name = @name, duration = @duration where id = @id";
            var result = connection.Execute(sql, courses);
            Console.WriteLine(result > 0 ? "Success" : "Failed");
        }
    }
    public void DeleteCourse(Courses courses)
    {
        using (var connection = context.GetDbConnection())
        {
            connection.Open();
            var sql = @$"delete from courses where courses id = @id";
            var result = connection.Execute(sql, courses);
            Console.WriteLine(result > 0 ? "Success" : "Failed");
        }
    }
    public List<Courses> GetCoursesWithoutGroups()
    {
        using (var connection = context.GetDbConnection())
        {
            var sql = @"select * from courses where id not in (select courseId from groups g join courses c on g.courseId = c.id)";
            var result = connection.Query<Courses>(sql).ToList();
            return result;
        }
    }
    public int DeleteStudentsByGroup(int groupId)
    {
        using (var connection = context.GetDbConnection())
        {
            var sql = $"delete from students where groupId = @GroupID";
            var result = connection.Execute(sql, new {GroupId = groupId});
            return result;
        }
    }
}
