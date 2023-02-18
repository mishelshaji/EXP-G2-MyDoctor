using CartSharp.Domain.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using MyDoctor.Domain.Models;
using MyDoctor.Service.Data;
using MyDoctor.Service.Dto;
using MyDoctor.Service.Services;
using System.Collections.Generic;

namespace MyDoctor.WebApp.Areas.Doctor
{
    public class DoctorHomeController : DoctorBaseController
    {
        private readonly DoctorService _doctorService;
        public DoctorHomeController(DoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTodayAppointments(int id)
        {
            var todayAppointments = await _doctorService.GetTodayAppointments(id);
            return Ok(todayAppointments);
        }

    }
}