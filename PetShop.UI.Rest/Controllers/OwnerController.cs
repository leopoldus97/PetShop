﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.ApplicationService;
using PetShop.Core.Entity;

namespace PetShop.UI.Rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _ownerService;

        public OwnerController(IOwnerService service)
        {
            _ownerService = service;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Owner>> Get()
        {
            return _ownerService.GetOwners();
        }

        [HttpGet("{id}")]
        public ActionResult<Owner> Get(int id)
        {
            try
            {
                return _ownerService.GetOwnerById(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST api/values
        [HttpPost]
        public ActionResult<ObjectResult> Post([FromBody] Owner owner)
        {
            try
            {
                return Ok(_ownerService.AddOwner(owner));
            }
            catch (NullReferenceException e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<Owner> Put(int id, [FromBody] Owner owner)
        {
            if (id < 1 || id != owner.ID)
            {
                return BadRequest("Parameter id and pet id must be the same!");
            }
            try
            {
                return Ok(_ownerService.UpdateOwner(owner));
            }
            catch (NullReferenceException e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id, [FromBody] Owner owner)
        {
            if (id < 1 || id != owner.ID)
            {
                return BadRequest("Parameter id and owner id must be the same!");
            }
            try
            {
                return Ok(_ownerService.RemoveOwner(owner.ID));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}