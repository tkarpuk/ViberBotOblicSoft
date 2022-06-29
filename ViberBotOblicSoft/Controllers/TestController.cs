using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViberBotOblicSoft.Business.BotService;
using ViberBotOblicSoft.Domain.Models;

namespace ViberBotOblicSoft.Controllers
{
    [Route("test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IBotService _botService;
        private readonly ILogger<IBotService> _logger;

        public TestController(IBotService botService, ILogger<IBotService> logger)
        {
            _botService = botService;
            _logger = logger;
        }

        [HttpGet("{IMEI}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AggregateJorney))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AggregateJorney>> GetAggregateAsync(string IMEI)
        {
            if (string.IsNullOrWhiteSpace(IMEI))
                return BadRequest("Empty IMEI");

            try
            {
                return Ok(await _botService.GetAggregateJorneyAsync(IMEI));
            }
            catch (Exception e)
            {
                _logger.LogError($"====>\nException: {e.Message}\n Inner: {e.InnerException?.Message}\n<====");
                return StatusCode(500);
            }          
        }

        [HttpGet("{IMEI}/Top")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Jorney>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTopListAsync(string IMEI)
        {
            if (string.IsNullOrWhiteSpace(IMEI))
                return BadRequest("Empty IMEI");

            try
            {
                return Ok(await _botService.GetListJorneyAsync(IMEI, 10)); // TODO: from configuration
            }
            catch (Exception e)
            {
                _logger.LogError($"====>\nException: {e.Message}\n Inner: {e.InnerException?.Message}\n<====");
                return StatusCode(500);
            }
        }
    }
}
