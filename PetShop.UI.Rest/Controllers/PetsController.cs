using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.ApplicationService;
using PetShop.Core.DomainService.Filtering;
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

        [HttpGet]
        public ActionResult<IEnumerable<Pet>> GetSorting([FromQuery] Filter filter)
        {
            return Ok(_petService.GetPetsFiltered(filter).ToList());
        }

        // GET api/pets/DOG
        [HttpGet]
        [Route("Type")]
        public ActionResult<IEnumerable<Pet>> Type([FromQuery]Type type)
        {
            return _petService.GetPetByType(type);
        }

        // GET api/pets/1
        [HttpGet("{id}")]
        public ActionResult<Pet> GetById(int id)
        {
            try
            {
                return _petService.GetPetById(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/values/DOG
        [HttpGet]
        [Route("Top")]
        public ActionResult<IEnumerable<Pet>> Top()
        {
            return _petService.TopFiveCheapest();
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Pet> Post([FromBody] Pet pet)
        {
            try
            {
                return _petService.AddPet(pet);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/pets/5
        [HttpPut("{id}")]
        public ActionResult<Pet> Put(int id, [FromBody] Pet pet)
        {
            if (id < 1 || id != pet.ID)
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

        // DELETE api/values
        [HttpDelete]
        public ActionResult<bool> Delete([FromBody] Pet pet)
        {
            try
            {
                return Ok(_petService.RemovePet(pet.ID));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}