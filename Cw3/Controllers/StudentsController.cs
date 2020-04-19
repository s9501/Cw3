using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw3.DAL;
using Cw3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cw3.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly IDbService _dbService;
        public StudentsController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public IActionResult GetStudents(string orderBy)
        {
            return Ok(_dbService.GetStudents());
        }

        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            student.IndexNumber = $"s{new Random().Next(1, 20000)}";
            return Ok(student);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id)
        {
            if (id > 0)
            {
                return Ok("Aktualizacja dokonczona");
            }
            else
                return Ok("Brak studenta o podanym id");

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            if (id > 0)
            {
                return Ok("Usuwanie ukonczone");
            }
            else
                return Ok("Brak studenta o podanym id");


        }

    }
}