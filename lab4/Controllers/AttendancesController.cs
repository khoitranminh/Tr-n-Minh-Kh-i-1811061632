﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using lab4.Models;
using Microsoft.AspNet.Identity;

namespace lab4.Controllers
{
    public class AttendancesController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Attend(Course attendanceDto)
        {
            var userID = User.Identity.GetUserId();
            BigSchoolContext context = new BigSchoolContext();
            if(context.Attendances.Any(p=>p.Attendee==userID && p.CourseID== attendanceDto.Id))
            {
                return BadRequest("The attendance already existsl");
            }
            var attendance = new Attendance() { CourseID = attendanceDto.Id, Attendee = User.Identity.GetUserId() };
            context.Attendances.Add(attendance);
            context.SaveChanges();
            return Ok();
        }
    }
}