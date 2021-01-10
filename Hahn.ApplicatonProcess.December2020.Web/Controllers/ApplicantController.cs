using Hahn.ApplicatonProcess.December2020.Domain.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;

namespace Applicant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private readonly ILogger<ApplicantController> _logger;
        private readonly IApplicantDAO _applicantDAO;

        public ApplicantController(ILogger<ApplicantController> logger, IApplicantDAO applicantDAO)
        {
            _logger = logger;
            _applicantDAO = applicantDAO;
        }

        [HttpPost()]
        public async Task<IActionResult> Create(Hahn.ApplicatonProcess.December2020.Domain.Model.Applicant applicant)
        {
            if (applicant == null)
                return BadRequest("Applicant not passed");

            var createdApplicant = await _applicantDAO.CreateApplicant(applicant);

            if (createdApplicant != null)
            {
                //return new CreatedAtActionResult("GetApplicant", "Applicant", new { createdApplicant.ID }, createdApplicant);
                return Ok(createdApplicant);
            }
            else
            {
                return BadRequest("Error occured please try again.");
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if ( id == 0)
                return BadRequest("Id must not be empty");

            var applicant = await _applicantDAO.GetApplicantById(id);

            if (applicant == null)
            {
                return NotFound($"Applicant with Id {id} doesn't exit");
            }

            return Ok(applicant);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var allApplicant = _applicantDAO.GetAll();

            if (allApplicant.Count != 0)
                return Ok(allApplicant);

            return NotFound("No applicant exit yet.");
        }

        [HttpPut]
        public async Task<IActionResult> Update(Hahn.ApplicatonProcess.December2020.Domain.Model.Applicant applicant)
        {
            if (applicant == null)
                return BadRequest("Applicant not passed");

            var updatedApplicant = await _applicantDAO.UpdateApplicant(applicant);

            if (updatedApplicant == null)
                return BadRequest("Error occured please check the input data and try again.");

            return Ok(updatedApplicant);
        }
    }
}
