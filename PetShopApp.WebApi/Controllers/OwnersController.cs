using System;
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
                return _ownerService.GetOwners();
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
                return _ownerService.GetOwner(id);
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
                return StatusCode(201, "Owner was created");

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);

            }

        }

        // PUT api/<OwnersController>/5
        [HttpPut("{id}")]
        public ActionResult<string> Put(int id, [FromBody] Owner owner)
        {
            try
            {
                owner.ID = id;
                _ownerService.UpdateOwner(owner);
                return StatusCode(200, "Owner was updated!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);

            }
        }

        // DELETE api/<OwnersController>/5
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            try
            {
                _ownerService.DeleteOwner(id);
                return StatusCode(200, "Owner was deleted!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}
