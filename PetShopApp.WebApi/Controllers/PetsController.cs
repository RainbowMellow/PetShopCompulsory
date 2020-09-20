using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PetShop.Core.ApplicationServices;
using PetShop.Core.ApplicationServices.Impl;
using PetShop.Core.Entities;
using PetShop.Core.Validators;

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

        //// GET: api/<PetsController>
        //[HttpGet]
        //public ActionResult<IEnumerable<Pet>> Get()
        //{
        //    try
        //    {
        //        Response.StatusCode = 200;
        //        List<Pet> pets = _petService.GetPets();

        //        if(pets.Count == 0)
        //        {
        //            throw new InvalidOperationException("The list of pets is empty.");
        //        }
        //        else
        //        {
        //            return pets;
        //        }
                
        //    }
        //    catch(InvalidOperationException ex)
        //    {
        //        return StatusCode(500, ex.Message);
        //    }
        //    catch(Exception ex)
        //    {
        //        return StatusCode(500, ex.Message);
        //    }

        //}

        // GET api/<PetsController>/5
        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {
            try
            {
                Response.StatusCode = 200;
                return _petService.GetPet(id);
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

        // GET: api/<PetsController>
        [HttpGet]
        public ActionResult<IEnumerable<Pet>> Get(string prop, string dir)
        {
            try
            {
                Response.StatusCode = 200;

                if (string.IsNullOrEmpty(prop) && string.IsNullOrEmpty(dir))
                {
                    List<Pet> pets = _petService.GetPets();

                    if (pets.Count == 0)
                    {
                        throw new InvalidOperationException("The list of pets is empty.");
                    }
                    else
                    {
                        return pets;
                    }
                }
                else
                {
                    List<Pet> petsWithParam = _petService.GetPetsWithParameters(prop, dir);

                    if (petsWithParam.Count == 0)
                    {
                        throw new InvalidOperationException("The list of pets is empty.");
                    }
                    else
                    {
                        return petsWithParam;
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

        // POST api/<PetsController>
        [HttpPost]
        public ActionResult<Pet> Post([FromBody] Pet pet)
        {
            try
            {
                Pet createdPet = _petService.CreatePet(pet);
                Response.StatusCode = 201;
                return createdPet;
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

        // PUT api/<PetsController>/5
        [HttpPut("{id}")]
        public ActionResult<Pet> Put(int id, [FromBody] Pet pet)
        {
            try
            {
                pet.ID = id;
                Pet updatedPet = _petService.UpdatePet(pet);
                Response.StatusCode = 202;
                return updatedPet;
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

        // DELETE api/<PetsController>/5
        [HttpDelete("{id}")]
        public ActionResult<Pet> Delete(int id)
        {
            try
            {
                Pet deletedPet = _petService.DeletePet(id);
                Response.StatusCode = 202;
                return deletedPet;
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
