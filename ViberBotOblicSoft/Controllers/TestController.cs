using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViberBotOblicSoft.Business.BotService;
using ViberBotOblicSoft.Configuration;
using ViberBotOblicSoft.Domain.Models;

namespace ViberBotOblicSoft.Controllers
{
    [Route("test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IBotService _botService;
        private readonly BotServiceConfiguration _configuration;

        public TestController(IBotService botService, IOptions<BotServiceConfiguration> configuration)
        {
            _botService = botService;
            _configuration = configuration.Value;
        }

        [HttpGet("{IMEI}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AggregateJorney))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AggregateJorney>> GetAggregateAsync(string IMEI)
        {
            if (string.IsNullOrWhiteSpace(IMEI))
                return BadRequest("Empty IMEI");

            return Ok(await _botService.GetAggregateJorneyAsync(IMEI));
        }

        [HttpGet("{IMEI}/Top")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Jorney>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTopListAsync(string IMEI)
        {
            if (string.IsNullOrWhiteSpace(IMEI))
                return BadRequest("Empty IMEI");

            return Ok(await _botService.GetListJorneyAsync(IMEI, _configuration.TopCount));
        }
    }
}
