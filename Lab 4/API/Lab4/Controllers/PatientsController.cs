using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Lab4.Data;
using Lab4.Entities;
using Lab4.Models;
using Lab4.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lab4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : Controller
    {
        private readonly IPatientInfoRepository _patientInfoRepository;
        private readonly IMapper _mapper;

        public PatientsController(IPatientInfoRepository patientInfoRepository, IMapper mapper)
        {
            _patientInfoRepository = patientInfoRepository ?? throw new ArgumentNullException(nameof(patientInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientDto>>> GetPatients()
        {
            var patients = await _patientInfoRepository.GetPatientsAsync();
            var results = new List<PatientDto>();

            foreach (var patient in patients)
            {
                results.Add(_mapper.Map<PatientDto>(patient));
            }

            return Ok(results);
        }

        [HttpGet("{patientId}", Name = "GetPatients")]
        public async Task<ActionResult<PatientDto>> GetPatient(Guid patientId)
        {
            var patient = await _patientInfoRepository.GetPatientAsync(patientId);

            if (patient is null)
            {
                return NotFound();
            }

            var patientForReturn = _mapper.Map<PatientDto>(patient);

            return Ok(patientForReturn);
        }

        [HttpPost]
        public async Task<ActionResult<PatientDto>> CreatePatient(PatientCreationDto patient)
        {
            var finalPatient = _mapper.Map<Patient>(patient);
            await _patientInfoRepository.AddPatientAsync(finalPatient);
            await _patientInfoRepository.SaveChangesAsync();

            return Ok(_mapper.Map<PatientDto>(finalPatient));
        }

        [HttpPut("{patientId}")]
        public async Task<ActionResult> UpdatePatient(Guid patientId, PatientCreationDto patient)
        {
            if (!await _patientInfoRepository.PatientExistsAsync(patientId))
            {
                return NotFound();
            }

            var patientFromDatabase = await _patientInfoRepository.GetPatientAsync(patientId);

            if (patientFromDatabase == null)
            {
                return NotFound();
            }

            var updatedPatient = _mapper.Map<Patient>(patient);

            if (await _patientInfoRepository.GetDiagnosisAsync(updatedPatient.DiagnosisId) == null)
            {
                return BadRequest("Diagnosis not found");
            }

            patientFromDatabase.FirstName = updatedPatient.FirstName;
            patientFromDatabase.LastName = updatedPatient.LastName;
            patientFromDatabase.PatientGender = updatedPatient.PatientGender;
            patientFromDatabase.PatientOib = updatedPatient.PatientOib;
            patientFromDatabase.PatientMbo = updatedPatient.PatientMbo;
            patientFromDatabase.DateOfBirth = updatedPatient.DateOfBirth;
            patientFromDatabase.DateOfAdmittance = updatedPatient.DateOfAdmittance;
            patientFromDatabase.DateOfDischarge = updatedPatient.DateOfDischarge;
            patientFromDatabase.DiagnosisId = updatedPatient.DiagnosisId;
            patientFromDatabase.IsDischarged = updatedPatient.IsDischarged;
            patientFromDatabase.PatientInsurance = updatedPatient.PatientInsurance;

            await _patientInfoRepository.SaveChangesAsync();

            return Ok(_mapper.Map<PatientDto>(patientFromDatabase));
        }

        [HttpDelete("{patientId}")]
        public async Task<ActionResult> DeletePatient(Guid patientId)
        {
            if (!await _patientInfoRepository.PatientExistsAsync(patientId))
            {
                return NotFound();
            }

            var patient = await _patientInfoRepository.GetPatientAsync(patientId);

            if (patient == null)
            {
                return NotFound();
            }

            _patientInfoRepository.DeletePatient(patient);
            await _patientInfoRepository.SaveChangesAsync();

            return Ok($"You successfully deleted patient: {patient.FirstName} {patient.LastName} with MBO: {patient.PatientMbo}");
        }

        [HttpGet("admitted")]
        public async Task<ActionResult<IEnumerable<PatientDto>>> GetAllAdmittedPatients()
        {
            var patients = await _patientInfoRepository.GetAllAdmittedPatients();
            var results = new List<PatientDto>();

            foreach (var patient in patients)
            {
                results.Add(_mapper.Map<PatientDto>(patient));
            }

            return Ok(results);
        }

        [HttpPost("admint/{patientId}")]
        public async Task<ActionResult> AdmitPatient(Guid patientId)
        {
            if (!await _patientInfoRepository.PatientExistsAsync(patientId))
            {
                return NotFound();
            }

            var patientFromDatabase = await _patientInfoRepository.GetPatientAsync(patientId);

            if (patientFromDatabase == null)
            {
                return NotFound();
            }

            if (patientFromDatabase.IsDischarged == false)
            {
                return BadRequest("Patient already admitted");
            }


            patientFromDatabase.DateOfAdmittance = DateTime.UtcNow;
            patientFromDatabase.IsDischarged = false;

            await _patientInfoRepository.SaveChangesAsync();

            return Ok("Patient admitted");
        }

        [HttpGet("discharged")]
        public async Task<ActionResult<IEnumerable<PatientDto>>> GetAllDischargedPatients()
        {
            var patients = await _patientInfoRepository.GetAllDischargedPatients();
            var results = new List<PatientDto>();

            foreach (var patient in patients)
            {
                results.Add(_mapper.Map<PatientDto>(patient));
            }

            return Ok(results);
        }

        [HttpPost("discharge/{patientId}")]
        public async Task<ActionResult> DischargePatient(Guid patientId)
        {
            if (!await _patientInfoRepository.PatientExistsAsync(patientId))
            {
                return NotFound();
            }

            var patientFromDatabase = await _patientInfoRepository.GetPatientAsync(patientId);

            if (patientFromDatabase == null)
            {
                return NotFound();
            }

            if(patientFromDatabase.IsDischarged == true)
            {
                return BadRequest("Patient already discharged");
            }


            patientFromDatabase.DateOfDischarge = DateTime.UtcNow;
            patientFromDatabase.IsDischarged = true;

            await _patientInfoRepository.SaveChangesAsync();

            return Ok("Patient discharged");
        }
    }
}

