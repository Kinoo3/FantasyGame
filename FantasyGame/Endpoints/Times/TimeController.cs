﻿using FantasyGame.Endpoints.Times;
using FantasyGame.Models;
using Microsoft.AspNetCore.Mvc;

namespace FantasyGame.Controllers.Times
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeController : ControllerBase
    {
        private readonly TimeBusinessRule _timeBusinessRule;

        public TimeController(TimeBusinessRule timeBusinessRule)
        {
            _timeBusinessRule = timeBusinessRule;  
        }


        // GET: api/time/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _timeBusinessRule.GetTimeById(id);
            if(result.OperationSucceeded())
            {
                return Ok(result.GetResponse());
            }
            return BadRequest(result.GetResponse());
        }


        // GET: api/time/?pagina=1&tamanhopagina=10  params opcionais
        [HttpGet]
        public async Task<IActionResult> GetPaginated([FromQuery]PaginatedSearchInputModel input)
        {
            var result = await _timeBusinessRule.GetTimes(input);
            if (result.OperationSucceeded())
                return Ok(result.GetResponse());
            return BadRequest(result.GetResponse());
        }


        // POST: api/time/
        [HttpPost]
        public async Task<IActionResult> Post(TimeInputModel input)
        {
            var result = await _timeBusinessRule.CreateTime(input);

            if (result.OperationSucceeded())
                return Ok(result.GetResponse());
            return BadRequest(result.GetResponse());
        }


        // PUT: api/time/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(TimeInputModel input, int id)
        {
            var result = await _timeBusinessRule.UpdateTime(input, id);

            if (result.OperationSucceeded())
                return Ok();
            return BadRequest(result.GetResponse());
        }


        // DELETE: api/time/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _timeBusinessRule.DeleteTime(id);
            if (result.OperationSucceeded())
                return Ok();
            return BadRequest(result.GetResponse());
        }
    }
}
