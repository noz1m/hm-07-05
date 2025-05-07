using System.ComponentModel;
using Dapper;
using Domain.Entities;
using Domain.DTO;
using Infrastructure.Data;
using Infrastructure.Interface;
using Npgsql;
namespace Infrastructure.Services;

public class StudentService : IStudentService
{
    private readonly DataContext context = new DataContext();

    public List<Students> GetAllStudents()
    {
        using (var connection = context.GetDbConnection())
        {
            connection.Open();
            var sql = @$"select * from students";
            var result = connection.Query<Students>(sql).ToList();
            return result;
        }
    }
    public void CreateStudents(Students students)
    {
        using (var connection = context.GetDbConnection())
        {
            connection.Open();
            var sql = @$"insert into students (fullname, groupId, mentorId) values
                        ('john doe', 1, 1),
                        ('jane roe', 2, 2),
                        ('mike black', 3, 3),
                        ('lisa green', 4, 4),
                        ('tom blue', 5, 5); ";
            var result = connection.Execute(sql, students);
            Console.WriteLine(result > 0 ? "Success" : "Failed");
        }
    }
    public void UpdateStudents(Students students)
    {
        using (var connection = context.GetDbConnection())
        {
            connection.Open();
            var sql = @$"update students set fullName = @fullName, groupId = @groupId, mentorId = @mentorId where id = @id";
            var result = connection.Execute(sql, students);
            Console.WriteLine(result > 0 ? "Success" : "Failed");
        }
    }
    public void DeleteStudent(int id)
    {
        using (var connection = context.GetDbConnection())
        {
            connection.Open();
            var sql = @$"delete from students where id = @id";
            var result = connection.Execute(sql, id);
            Console.WriteLine(result > 0 ? "Success" : "Failed");
        }
    }
    public IEnumerable<Students> GetStudentsByMentorName(string mentorName)
    {
        using (var connection = context.GetDbConnection())
        {
            var sql = @"select s.* from students s join mentors m on s.mentorId = m.id
            where m.fullname = @MentorName";
            var result = connection.Query<Students>(sql, new { MentorName = mentorName }).ToList();
            return result;
        }
    }
    public bool StudentExistsByEmailAsync(string email)
    {
        using (var connection = context.GetDbConnection())
        {
            var sql = @"select * from students where Email = @email";
            var result = connection.QueryFirstOrDefault(sql, new { Email = email });
            return result;
        }
    }
    public int UpdateStudentEmailAsync(int studentId, string newEmail)
    {
        using (var connection = context.GetDbConnection())
        {
            var sql = @"update students set Email = @newEmail where id = studentId";
            var result = connection.Execute(sql, new { Email = newEmail, id = studentId });
            return result;
        }
    }
    public void DeleteGroupWithStudents(int groupId)
    {
        using (var connection = context.GetDbConnection())
        {
            var sql = @"delete from students where groupId = @GroupId";
            var result = connection.Execute(sql, new { GroupId = groupId });
        }
    }
    public List<Students> GetStudentsWithoutMentors()
    {
        using (var connection = context.GetDbConnection())
        {
            var sql = @"select * students where mentorId = null";
            var result = connection.Query<Students>(sql).ToList();
            return result;
        }
    }
    public List<GroupWithStudentCountDTO> GetStudentCountByGroup()
    {
        using (var connection = context.GetDbConnection())
        {
            var sql = @"select g.id, g.name, count(*) from groups g join students s on g.id = s.groupId group by g.id, g.name order by count(*) desc";
            var result = connection.Query<GroupWithStudentCountDTO>(sql).ToList();
            return result;
        }
    }
}
