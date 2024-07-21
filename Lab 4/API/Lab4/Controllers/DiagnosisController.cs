using AutoMapper;
using Lab4.Models;
using Lab4.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Lab4.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiagnosisController : ControllerBase
    {
        private readonly IPatientInfoRepository _patientInfoRepository;

        private readonly IMapper _mapper;

        public DiagnosisController(IPatientInfoRepository patientInfoRepository, IMapper mapper)
        {
            _patientInfoRepository = patientInfoRepository ?? throw new ArgumentNullException(nameof(patientInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiagnosisDto>>> GetDiagnosisList()
        {
            var diagnosesList = await _patientInfoRepository.GetDiagnosesListAsync();

            return Ok(_mapper.Map<IEnumerable<DiagnosisDto>>(diagnosesList));
        }

        [HttpGet("{diagnosisId}")]
        public async Task<ActionResult<DiagnosisDto?>> GetDiagnosis(Guid diagnosisId)
        {
            var diagnosis = await _patientInfoRepository.GetDiagnosisAsync(diagnosisId);

            if (diagnosis is null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<DiagnosisDto>(diagnosis));
        }
    }
}
