using AdminMicroservice.Model;
using AppointmentMicroservice.Model.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VaccinationMicroservice.Repository.IRepository;

namespace AdminMicroservice.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaccinationController : ControllerBase
    {

        private readonly IVaccinationRepository _npRepo;
        private readonly IMapper _mapper;

        public VaccinationController(IVaccinationRepository npRepo, IMapper mapper)
        {
            _npRepo = npRepo;
            _mapper = mapper;
        }
        /// <summary>
        /// Get List of Vaccinations
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(400)]
        public IActionResult GetVaccinations()
        {
            var objList = _npRepo.GetVaccinations();
            var objDto = new List<VaccinationDto>();
            foreach (var item in objList)
            {
                objDto.Add(_mapper.Map<VaccinationDto>(item));
            }
            return Ok(objDto);
        }
        /// <summary>
        /// Get individual Vaccination
        /// </summary>
        /// <returns></returns>
        [HttpGet("{vaccinationId:int}", Name = "GetVaccination")]

        [ProducesResponseType(200, Type = typeof(VaccinationDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesDefaultResponseType]
        public IActionResult GetVaccination(int vaccinationId)
        {
            var obj = _npRepo.GetVaccination(vaccinationId);
            if (obj == null)
            {
                return NotFound();
            }

            var ObjDto = _mapper.Map<VaccinationDto>(obj);
            return Ok(ObjDto);
        }

        /// <summary>
        /// Create Vaccination
        /// </summary>
        /// <returns></returns>

        [Route("UserVaccinations")]
        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(500)]
        public IActionResult CreateVaccination([FromBody] VaccinationDto vaccinationDto)
        {
            if (vaccinationDto == null)
            {
                return BadRequest(ModelState);
            }

            var vaccinationObj = _mapper.Map<Vaccination>(vaccinationDto);

            if (!_npRepo.CreateVaccination(vaccinationObj))
            {
                ModelState.AddModelError("", $"Something went wrong when saving the record {vaccinationObj.Id}");
                return StatusCode(500, ModelState);
            }

            return Ok(vaccinationObj);
        }
        /// <summary>
        /// Delete Vaccination
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{vaccinationId:int}", Name = "DeleteVaccination")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public IActionResult DeleteVaccination(int vaccinationId)
        {


            if (!_npRepo.VaccinationExists(vaccinationId))
            {
                return NotFound();
            }

            var vaccinationObj = _npRepo.GetVaccination(vaccinationId);
            if (!_npRepo.DeleteVaccination(vaccinationObj))
            {
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
