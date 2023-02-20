using CartSharp.Domain.Types;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using MyDoctor.Domain.Models;
using MyDoctor.Service.Data;
using MyDoctor.Service.Dto;
using MyDoctor.Service.Services;
using System.Collections.Generic;
using System.Security.Claims;

namespace MyDoctor.WebApp.Areas.Doctor
{
    public class DoctorHomeController : DoctorBaseController
    {
        private readonly DoctorService _doctorService;
        public DoctorHomeController(DoctorService doctorService)
        {
            _doctorService = doctorService;
        }
        [Authorize]
        [HttpGet]
        [ProducesResponseType(typeof(AppointmentDoctorDto),statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTodayAppointments()
        {
            var masterId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.Actor));
            var res = await _doctorService.GetTodayAppointmentsAsync(masterId);
            return Ok(res);
        }

        [Authorize]
        [HttpGet("history")]
        [ProducesResponseType(typeof(PatientAppointmentsDto), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAppointmentHistory()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var res = await _doctorService.GetAppointmentHistoryAsync(id);
            return Ok(res);
        }
    }
}