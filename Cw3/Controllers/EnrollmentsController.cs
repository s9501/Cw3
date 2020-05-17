using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Cw3.DAL;
using Cw3.Models;
using Cw3.Models.DTOs.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Cw3.Controllers
{
    [ApiController]
    [Route("api/enrollments")]
    public class EnrollmentsController : ControllerBase
    {
        private IStudentDbService _service;

        public EnrollmentsController(IStudentDbService service)
        {
            _service = service;
        }


        [HttpPost]
        public IActionResult EnrollStudent(EnrollStudentRequest request)
        {

            using (SqlConnection con = new SqlConnection(ConString))
            using (SqlCommand com = new SqlCommand())
            {
                com.Connection = con;
                con.Open();

                var tran = con.BeginTransaction();

                try
                {
                    com.CommandText = "SELECT * FROM studies WHERE name = @name";
                    com.Parameters.AddWithValue("name", request.Studies);

                    var dr = com.ExecuteReader();

                    if (!dr.Read())
                    {
                        tran.Rollback();
                    }
                    int IdStudies = (int)dr["IdStudies"];


                    com.CommandText = "INSERT INTO Student (IndexNumber, FirstName, LastName, BirthDate, idEnrollment) VALUES (IndexNumber, FirstName, LastName, BirthDate, (SELECT MAX(idEnrollment)+1 FROM Student)))"
                    com.Parameters.AddWithValue("index", request.IndexNumber);
                    com.ExecuteNonQuery();

                    tran.Commit();
                }
                catch (SqlException exc)
                {
                    tran.Rollback
                }
                
            }

            return Ok(response);
        }


    }
}