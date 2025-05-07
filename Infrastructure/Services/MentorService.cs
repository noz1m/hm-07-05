using Dapper;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Interface;
using Npgsql;
namespace Infrastructure.Services;

public class MentorService : IMentorService
{
    private readonly DataContext context = new DataContext();
    public List<Mentors> GetAllMentors()
    {
        using (var connection = context.GetDbConnection())
        {
            connection.Open();
            var sql = @$"select * from mentors";
            var result = connection.Query<Mentors>(sql).ToList();
            return result;
        }
    }
    public void CreateMentors(Mentors mentors)
    {
        using (var connection = context.GetDbConnection())
        {
            var sql = @$"insert into mentors (fullname, email) values
                        ('alice smith', 'alice@example.com'),
                        ('bob johnson', 'bob@example.com'),
                        ('carol davis', 'carol@example.com'),
                        ('david brown', 'david@example.com'),
                        ('eva white', 'eva@example.com');";
            var result = connection.Execute(sql, mentors);
            Console.WriteLine(result > 0 ? "Success" : "Failed");
        }
    }
    public void UpdateMentor(Mentors mentors)
    {
        using (var connection = context.GetDbConnection())
        {
            var sql = @$"update mentors set fullName = @fullName, Email = @Email where id = @id";
            var result = connection.Execute(sql, mentors);
            Console.WriteLine(result > 0 ? "Success" : "Failed");
        }
    }
    public void DeleteMentor(int id)
    {
        using (var connection = context.GetDbConnection())
        {
            var sql = @$"delete from mentors where id  = @id";
            var result = connection.Execute(sql, id);
            Console.WriteLine(result > 0 ? "Success" : "Failed");
        }
    }
    public List<Mentors> GetMentorsWithStudents()
    {
        using (var connection = context.GetDbConnection())
        {
            var sql = @"select m.id ,m.fullname, m.email, s.id, s.fullname from mentors m
            join students s on s.mentorId = m.id";
            var result = connection.Query<Mentors>(sql).ToList();
            return result;
        }
    }

}
