using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        /*
        private readonly IDbService _dbService;
        public StudentsController(IDbService dbService)
        {
            _dbService = dbService;
        }
        */
        private const string ConString = "Data Source=db-mssql;Initial Catalog=s9501;Integrated Security=True";
        

        [HttpGet("{id}")]
        public IActionResult GetStudents(string id)
        {
            using (SqlConnection con = new SqlConnection(ConString))
            using (SqlCommand com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = "SELECT * FROM student WHERE indexNumber = @id";
                com.Parameters.AddWithValue("id", id);


                con.Open();
                var dr = com.ExecuteReader();

                if (dr.Read())
                {
                    var st = new Student();
                    st.IndexNumber = dr["IndexNumber"].ToString();
                    st.FirstName = dr["FirstName"].ToString();
                    st.LastName = dr["LastName"].ToString();
                    return Ok(st);
                }
            }

            return NotFound();
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