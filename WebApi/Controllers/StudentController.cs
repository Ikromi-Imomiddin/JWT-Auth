using Domain.Entities;
using Domain.Filters;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(AuthenticationSchemes = "Bearer")]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpPost]
    public async Task<Response<Student>> Create([FromBody] Student student)
    {
        Response<Student> result = new Response<Student>();
        for (var i = 1; i <= 150; i++)
        {
            //fill with random data
            var insert = new Student()
            {
                Firstname = "Firstname" + i,
                Lastname = "Lastname" + i,
                Email = "Email" + i + "@gmail.com",
                Phone = "Phone" + i,
            };
            result = await _studentService.AddStudent(insert);
        }
        return result;
    }


    [HttpGet]
    public async Task<PagedResponse<List<Student>>> Get([FromQuery] PaginationFilter filter)
    {
        return await _studentService.GetStudents(filter);
    }


}