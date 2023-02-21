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
        private readonly DoctorProfileService _doctorProfileService;

        public DoctorHomeController(DoctorService doctorService,
                                     DoctorProfileService doctorProfileService)
        {
            _doctorService = doctorService;
            _doctorProfileService = doctorProfileService;
        }
        [Authorize]
        [HttpGet]
        [ProducesResponseType(typeof(AppointmentDoctorDto), statusCode: StatusCodes.Status200OK)]
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

        [HttpGet("Profile")]
        [ProducesResponseType(typeof(DoctorProfileDto), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var id = Convert.ToInt32(User.FindFirstValue(ClaimTypes.Actor));
            var res = await _doctorProfileService.ViewDoctorProfileAsync(id);
            return Ok(res);
        }
            

        [HttpPut("Profile")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> DoctorProfile(DoctorProfileDto dto)
        {
            var id = Convert.ToInt32(User.FindFirstValue(ClaimTypes.Actor));
            var res = await _doctorProfileService.EditDoctorProfileAsync(id, dto);
            return Ok(res);
        }
    }
}