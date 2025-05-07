using Domain.DTO;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Interface;
using Infrastructure.Services;
using Npgsql;

CourseService courseService = new CourseService();
courseService.GetAllCourses();

GroupService groupService = new GroupService();
groupService.GetAllGroup();

StudentService studentService = new StudentService();
studentService.GetAllStudents();

MentorService mentorService = new MentorService();
mentorService.GetAllMentors();

