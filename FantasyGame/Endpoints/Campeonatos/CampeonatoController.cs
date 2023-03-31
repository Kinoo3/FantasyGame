using FantasyGame.Endpoints.Times;
using FantasyGame.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FantasyGame.Endpoints.Campeonatos
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampeonatoController : ControllerBase
    {
        private readonly CampeonatoBusinessRule _campeonatoBusinessRule;

        public CampeonatoController(CampeonatoBusinessRule campeonatoBusinessRule)
        {
            _campeonatoBusinessRule = campeonatoBusinessRule;
        }


        // GET: api/campeonato/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _campeonatoBusinessRule.GetCampeonatoById(id);
            if (result.OperationSucceeded())
                return Ok(result.GetResponse());
            return BadRequest(result.GetResponse());
        }

        [HttpGet]
        public async Task<IActionResult> GetPaginated([FromQuery] PaginatedSearchInputModel input)
        {
            var result = await _campeonatoBusinessRule.GetCampeonatosPaginated(input);
            if (result.OperationSucceeded())
                return Ok(result.GetResponse());
            return BadRequest(result.GetResponse());
        }

        // GET: api/Campeonato/
        [HttpGet("Recent")]
        public async Task<IActionResult> GetMostRecent()
        {
            var result = await _campeonatoBusinessRule.GetMostRecentCampeonato();
            if (result.OperationSucceeded())
                return Ok(result.GetResponse());
            return BadRequest(result.GetResponse());
        }

        // POST: api/campeonato/
        [HttpPost]
        public async Task<IActionResult> Post(CampeonatoInputModel input)
        {
            var result = await _campeonatoBusinessRule.RealizarCampeonato(input);
            if (result.OperationSucceeded())
                return Ok(result.GetResponse());
            return BadRequest(result.GetResponse());
        }
    }
}
