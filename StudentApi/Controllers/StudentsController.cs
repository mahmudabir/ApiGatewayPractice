using Microsoft.AspNetCore.Mvc;
using StudentApi.Models;

namespace StudentApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private static readonly List<Student> _students = new()
    {
        new Student
        {
            Id = 1,
            Name = "John Doe",
            Age = 15,
            Grade = "10th"
        },
        new Student
        {
            Id = 2,
            Name = "Jane Smith",
            Age = 16,
            Grade = "11th"
        },
        new Student
        {
            Id = 3,
            Name = "Bob Johnson",
            Age = 14,
            Grade = "9th"
        }
    };

    private readonly ILogger<StudentsController> _logger;

    public StudentsController(ILogger<StudentsController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        _logger.LogInformation("Getting all students");
        return Ok(_students);
    }

    [HttpGet("test")]
    public IActionResult Test()
    {
        _logger.LogInformation("Getting all students");
        return Ok(_students);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var student = _students.FirstOrDefault(s => s.Id == id);
        if (student == null)
        {
            return NotFound();
        }
        return Ok(student);
    }

    [HttpPost]
    public IActionResult Create(Student student)
    {
        if (student.Id == 0)
        {
            student.Id = _students.Max(s => s.Id) + 1;
        }
        else if (_students.Any(s => s.Id == student.Id))
        {
            return Conflict($"Student with ID {student.Id} already exists");
        }

        _students.Add(student);
        return CreatedAtAction(nameof(GetById), new
        {
            id = student.Id
        }, student);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Student student)
    {
        var existingStudent = _students.FirstOrDefault(s => s.Id == id);
        if (existingStudent == null)
        {
            return NotFound();
        }

        existingStudent.Name = student.Name;
        existingStudent.Age = student.Age;
        existingStudent.Grade = student.Grade;

        return Ok(existingStudent);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var student = _students.FirstOrDefault(s => s.Id == id);
        if (student == null)
        {
            return NotFound();
        }

        _students.Remove(student);
        return NoContent();
    }
}
