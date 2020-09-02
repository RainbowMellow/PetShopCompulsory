using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.ApplicationServices;
using PetShop.Core.ApplicationServices.Impl;
using PetShop.Core.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetShopApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetsController(IPetService petService)
        {
            _petService = petService;
        }

        
        // GET: api/<PetsController>
        [HttpGet]
        public ActionResult<IEnumerable<Pet>> Get()
        {
            try
            {
                return _petService.GetPets();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<PetsController>/5
        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {
            try
            {
                return _petService.GetPet(id);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }


        // POST api/<PetsController>
        [HttpPost]
        public ActionResult<Pet> Post([FromBody] Pet pet)
        {
            try
            {
                Pet createdPet = _petService.CreatePet(pet);
                return StatusCode(201, "Pet was created");
                
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
                
            }
            
        }

        // PUT api/<PetsController>/5
        [HttpPut("{id}")]
        public ActionResult<string> Put(int id, [FromBody] Pet pet)
        {
            try
            {
                pet.ID = id;
                _petService.UpdatePet(pet);
                return StatusCode(200, "Pet was updated!");
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
               
            }
        }

        // DELETE api/<PetsController>/5
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            try
            {
                _petService.DeletePet(id);
                return StatusCode(200, "Pet was deleted!");
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }
    }
}
