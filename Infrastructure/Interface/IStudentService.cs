using Domain.Entities;
using Domain.Filters;
using Domain.Wrapper;

namespace Infrastructure.Services;

public interface IStudentService
{
    Task<Response<Student>> AddStudent(Student student);
    Task<PagedResponse<List<Student>>> GetStudents(PaginationFilter filter);
}