using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleWebApiAspNetCore.Models;
using SampleWebApiAspNetCore.Repositories;

namespace SampleWebApiAspNetCore.Controllers
{
    //[Route("api/[controller]")]
    public class CourseController : Controller
    {
        private ICoursesRepository courses;
        public CourseController(sakilaContext context)
        {
            courses = new CoursesRepository(context);
        }

        //GET api/records
       
        [HttpGet()]
        public IActionResult Get()
        {
            return Ok(courses.GetCourse());
        }


    }
}
