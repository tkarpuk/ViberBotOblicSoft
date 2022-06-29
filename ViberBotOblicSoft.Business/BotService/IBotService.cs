using System.Collections.Generic;
using System.Threading.Tasks;
using ViberBotOblicSoft.Domain.Models;

namespace ViberBotOblicSoft.Business.BotService
{
    public interface IBotService
    {
        Task<List<Jorney>> GetListJorneyAsync(string IMEI, int TopCount);

        Task<AggregateJorney> GetAggregateJorneyAsync(string IMEI);
    }
}
