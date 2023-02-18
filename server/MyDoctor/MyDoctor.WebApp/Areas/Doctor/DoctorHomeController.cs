using CartSharp.Domain.Types;
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

        [HttpGet]
        [ProducesResponseType(typeof(AppointmentDoctorDto),statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTodayAppointments(int id)
        {
            var res = await _doctorService.GetTodayAppointmentsAsync(id);
            return Ok(res);
        }

        [HttpGet("Appointments")]
        [ProducesResponseType(typeof(AppointmentDoctorDto),statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetDoctorAppointments(int id)
        {
            var res = await _doctorService.GetDoctorAppointmentsAsync(id);
            return Ok(res);
        }

        [HttpGet("PatientDetails")]
        [ProducesResponseType(typeof(PatientDetailsDto), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPatientDetails(int id)
        {
            var res = await _doctorService.GetPatientDetailsAsync(id);
            return Ok(res);
        }

        [HttpPut("Prescription")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdatePrescriptionAsync(int id, PrescriptionDto dto)
        {
            var res = await _doctorService.UpdatePrescriptionAsync(id, dto);
            return Ok(res);
        }

    }
}