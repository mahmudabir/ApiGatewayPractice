using Microsoft.AspNetCore.Mvc;
using TeacherApi.Models;

namespace TeacherApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeachersController : ControllerBase
{
    private static readonly List<Teacher> _teachers = new()
    {
        new Teacher
        {
            Id = 1,
            Name = "Dr. Smith",
            Subject = "Mathematics",
            YearsOfExperience = 10
        },
        new Teacher
        {
            Id = 2,
            Name = "Prof. Johnson",
            Subject = "History",
            YearsOfExperience = 15
        },
        new Teacher
        {
            Id = 3,
            Name = "Ms. Garcia",
            Subject = "Science",
            YearsOfExperience = 7
        }
    };

    private readonly ILogger<TeachersController> _logger;

    public TeachersController(ILogger<TeachersController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        _logger.LogInformation("Getting all teachers");
        return Ok(_teachers);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var teacher = _teachers.FirstOrDefault(t => t.Id == id);
        if (teacher == null)
        {
            return NotFound();
        }
        return Ok(teacher);
    }

    [HttpPost]
    public IActionResult Create(Teacher teacher)
    {
        if (teacher.Id == 0)
        {
            teacher.Id = _teachers.Max(t => t.Id) + 1;
        }
        else if (_teachers.Any(t => t.Id == teacher.Id))
        {
            return Conflict($"Teacher with ID {teacher.Id} already exists");
        }

        _teachers.Add(teacher);
        return CreatedAtAction(nameof(GetById), new
        {
            id = teacher.Id
        }, teacher);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Teacher teacher)
    {
        var existingTeacher = _teachers.FirstOrDefault(t => t.Id == id);
        if (existingTeacher == null)
        {
            return NotFound();
        }

        existingTeacher.Name = teacher.Name;
        existingTeacher.Subject = teacher.Subject;
        existingTeacher.YearsOfExperience = teacher.YearsOfExperience;

        return Ok(existingTeacher);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var teacher = _teachers.FirstOrDefault(t => t.Id == id);
        if (teacher == null)
        {
            return NotFound();
        }

        _teachers.Remove(teacher);
        return NoContent();
    }
}
