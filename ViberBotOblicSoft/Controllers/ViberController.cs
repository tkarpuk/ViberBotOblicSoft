using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Viber.Bot;

namespace ViberBotOblicSoft.Controllers
{
    [Route("viber")]
    [ApiController]
    public class ViberController : ControllerBase
    {
        private readonly IViberBotClient _viberBotClient = new ViberBotClient("4f65a7b1a867e26a-e9a9edd6e15f09d7-4bb40951f40fc7a0");

        [HttpPost]
        public async Task<ActionResult> CommonPost(string Msg)
        {
            //var t = Msg?.Text;
            return await Task.FromResult(Ok("Test ok!"));
        }


        //[HttpPost]
        //public async Task<ActionResult> SendMessage([FromBody] TextMessage Msg)
        //{
        //    try
        //    {
        //        //var result = await _viberBotClient.SendTextMessageAsync(Msg);
        //        return Ok("Ok!");
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex);

        //    }
        //}

    }
}
