using Domain.Entities;
using Domain.Dtos;
using Domain.Filters;
using Domain.Wrapper;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class StudentService : IStudentService
{
    private readonly DataContext _context;

    public StudentService(DataContext context)
    {
        _context = context;
    }

    //add student
    public async Task<Response<Student>> AddStudent(Student student)
    {
        await _context.Students.AddAsync(student);
        await _context.SaveChangesAsync();
        return new Response<Student>(student);
    }

    public async Task<PagedResponse<List<Student>>> GetStudents(PaginationFilter filter)
    {
        var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

        var query = _context.Students.AsQueryable();

        var totalRecords = await query.CountAsync();
        var records = query.Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
            .Take(validFilter.PageSize).ToList();

        var students = await _context.Students.ToListAsync();
        return new PagedResponse<List<Student>>(records, totalRecords, validFilter.PageNumber, validFilter.PageSize);
    }
}