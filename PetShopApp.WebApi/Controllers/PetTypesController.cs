using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.ApplicationServices;
using PetShop.Core.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetShopApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetTypesController : ControllerBase
    {
        private readonly IPetTypeService _petTypeService;

        public PetTypesController(IPetTypeService petTypeService)
        {
            _petTypeService = petTypeService;
        }

        // GET: api/<PetsController>
        [HttpGet]
        public ActionResult<IEnumerable<PetType>> Get(string prop, string dir)
        {
            try
            {
                Response.StatusCode = 200;

                if (string.IsNullOrEmpty(prop) && string.IsNullOrEmpty(dir))
                {
                    List<PetType> petTypes = _petTypeService.GetPetTypes();

                    if (petTypes.Count == 0)
                    {
                        throw new InvalidOperationException("The list of Pet Types is empty.");
                    }
                    else
                    {
                        return petTypes;
                    }
                }
                else
                {
                    List<PetType> petTypesWithParam = _petTypeService.GetPetTypesWithParameters(prop, dir);

                    if (petTypesWithParam.Count == 0)
                    {
                        throw new InvalidOperationException("The list of Pet Types is empty.");
                    }
                    else
                    {
                        return petTypesWithParam;
                    }
                }

            }
            catch (ArgumentException ex)
            {
                return StatusCode(500, ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(500, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        // GET api/<PetTypesController>/5
        [HttpGet("{id}")]
        public ActionResult<PetType> Get(int id)
        {
            try
            {
                Response.StatusCode = 200;
                return _petTypeService.GetPetType(id);
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<PetTypesController>
        [HttpPost]
        public ActionResult<PetType> Post([FromBody] PetType petType)
        {
            try
            {
                PetType createdPetType = _petTypeService.CreatePetType(petType);
                Response.StatusCode = 201;
                return createdPetType;
            }
            catch (ArgumentException ex)
            {
                return StatusCode(500, ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Something went wrong");
            }
        }

        // PUT api/<PetTypesController>/5
        [HttpPut("{id}")]
        public ActionResult<PetType> Put(int id, [FromBody] PetType petType)
        {
            try
            {
                petType.ID = id;
                PetType updatedPetType = _petTypeService.UpdatePetType(petType);
                Response.StatusCode = 202;
                return updatedPetType;
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }
            catch (ArgumentException ex)
            {
                return StatusCode(500, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);

            }
        }

        // DELETE api/<PetTypesController>/5
        [HttpDelete("{id}")]
        public ActionResult<PetType> Delete(int id)
        {
            try
            {
                PetType deletedPetType = _petTypeService.DeletePetType(id);
                Response.StatusCode = 202;
                return deletedPetType;
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
