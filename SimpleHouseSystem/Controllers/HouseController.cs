﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleHouseSystem.Models;
using SimpleHouseSystem.Models.DTO;
using SimpleHouseSystem.Service;
using SimpleHouseSystem.Service.Interface;

namespace SimpleHouseSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseController : ControllerBase
    {
        private IHouseService _houseService;

        public HouseController(IHouseService houseService) 
        {
            _houseService = houseService;
        }

        // GET api/values
        [HttpGet]
        public List<HouseDto> test()
        {
            return _houseService.GetAllHouse();
        }

        // GET api/values/5
        public List<HouseDto> Get(int id)
        {
            return new List<HouseDto>();
        }

        // POST api/values
        public void Post([FromBody] string value)
        {

        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/values/5
        public void Delete(int id)
        {

        }
    }
}
