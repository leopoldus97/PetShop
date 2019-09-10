using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.ApplicationService;
using PetShop.Core.Entity;
using Type = PetShop.Core.Entity.Type;

namespace PetShop.UI.Rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetsController(IPetService service)
        {
            _petService = service;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Pet>> Get()
        {
            return _petService.GetPets();
        }

        // GET api/values/DOG
        [HttpGet("{type}")]
        public ActionResult<IEnumerable<Pet>> Get(Type type)
        {
            return _petService.GetPetByType(type);
        }

        // POST api/values
        [HttpPost]
        public ActionResult<ObjectResult> Post([FromBody] Pet pet)
        {
            try
            {
                return Ok(_petService.AddPet(pet));
            }
            catch (NullReferenceException e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/pets/5
        [HttpPut("{id}")]
        public ActionResult<Pet> Put(int id, [FromBody] Pet pet)
        {
            if (id < 1 && id != pet.ID)
            {
                return BadRequest("Parameter id and pet id must be the same!");
            }
            try
            {
                return Ok(_petService.UpdatePet(pet));
            }
            catch (NullReferenceException e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            try
            {
                return Ok(_petService.RemovePet(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}