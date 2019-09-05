using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rodolfo.Schmidt.Application.Dto;
using Rodolfo.Schmidt.Application.Interfaces;

namespace Rodolfo.Schmidt.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPeople()
        {

            try
            {
                var result = await _personService.GetPeople();

                if (!result.Any())
                    return NotFound();

                return Ok(result);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerson(int id)
        {
            try
            {
                var result = await _personService.GetPersonById(id);

                if (result == null)
                    return NotFound();

                return Ok(result);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> CreatePerson([FromBody] PersonDto personDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _personService.CreatePerson(personDto);

                    if (!result.Saved)
                        return BadRequest(result.Message);

                    return Ok(result.Message);

                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<IActionResult> UpdatePerson([FromBody] PersonDto personDto)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var person = await _personService.GetPersonById(personDto.Id);

                    if (person == null)
                        return NotFound();

                    var result = await _personService.UpdatePerson(personDto);

                    if (!result.Updated)
                        return BadRequest(result.Message);

                    return Ok(result.Message);

                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            try
            {
                var person = await _personService.GetPersonById(id);

                if (person == null)
                    return NotFound();

                var result = await _personService.DeletePerson(id);

                if (!result.Deleted)
                    return BadRequest(result.Message);

                return Ok(result.Message);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
