using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViberBotOblicSoft.Data;
using ViberBotOblicSoft.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ViberBotOblicSoft.Business.BotService
{
    public class BotService : IBotService
    {
        private readonly ViberBotDbContext _db;
        private readonly int _timeBreake = 30; // TODO: change to parameter!

        public BotService(ViberBotDbContext dbContext) => _db = dbContext;

        public async Task<AggregateJorney> GetAggregateJorneyAsync(string IMEI)
        {
            var listJorney = await GetJorneysAsync(IMEI);

            return new AggregateJorney()
            {
                Count = listJorney.Count,
                Distance = listJorney.Sum(x => x.Distance),
                Time = listJorney.Sum(x => x.Time),
            };
        }

        public async Task<List<Jorney>> GetListJorneyAsync(string IMEI, int TopCount)
        {
            var listJorney = await GetJorneysAsync(IMEI);

            return listJorney.OrderByDescending(x => x.Distance)
                .Select((x, idx) => new Jorney() { Id = idx + 1, Distance = x.Distance, Time = x.Time })
                .Take(TopCount).ToList();
        }

        private async Task<List<Jorney>> GetJorneysAsync(string IMEI)
        {
            // EXECUTE @RC = [dbo].[GetJORNEY] @IMEI, @TIME_BREAKE
            var result = await _db.Set<Jorney>()
                .FromSqlInterpolated($"EXECUTE dbo.GetJORNEY {IMEI}, {_timeBreake}")
                .ToListAsync();

            if (!result.Any())
                throw new KeyNotFoundException($"Not found any resords for IMEI <{IMEI}>.");

            return result;
        }
    }
}
