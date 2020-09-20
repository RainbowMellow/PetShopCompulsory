using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.ApplicationServices;
using PetShop.Core.Entities;
using PetShop.Core.Validators;
using PetShop.Core.Validators.Impl;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetShopApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        private readonly IOwnerService _ownerService;

        public OwnersController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        // GET: api/<OwnersController>
        [HttpGet]
        public ActionResult<IEnumerable<Owner>> Get()
        {
            try
            {
                Response.StatusCode = 200;
                List<Owner> owners = _ownerService.GetOwners();
                if (owners.Count == 0)
                {
                    throw new InvalidOperationException("The list of owners is empty.");
                }
                else
                {
                    return owners;
                }

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

        // GET api/<OwnersController>/5
        [HttpGet("{id}")]
        public ActionResult<Owner> Get(int id)
        {
            try
            {
                Response.StatusCode = 200;
                return _ownerService.GetOwner(id);
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


        // POST api/<OwnersController>
        [HttpPost]
        public ActionResult<Owner> Post([FromBody] Owner owner)
        {
            try
            {
                Owner createdOwner = _ownerService.CreateOwner(owner);
                Response.StatusCode = 201;
                return createdOwner;

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

        // PUT api/<OwnersController>/5
        [HttpPut("{id}")]
        public ActionResult<Owner> Put(int id, [FromBody] Owner owner)
        {
            try
            {
                owner.ID = id;
                Owner updatedOwner = _ownerService.UpdateOwner(owner);
                Response.StatusCode = 202;
                return updatedOwner;
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

        // DELETE api/<OwnersController>/5
        [HttpDelete("{id}")]
        public ActionResult<Owner> Delete(int id)
        {
            try
            {
                Owner deletedOwner = _ownerService.DeleteOwner(id);
                Response.StatusCode = 202;
                return deletedOwner;
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
