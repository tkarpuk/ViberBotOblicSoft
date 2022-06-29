using Microsoft.Extensions.DependencyInjection;
using ViberBotOblicSoft.Business.BotService;

namespace ViberBotOblicSoft.Infrastructure
{
    public static class ServiceCollectionExtension
    {
        public static void AddViberBotServices(this IServiceCollection services)
        {
            services.AddTransient<IBotService, BotService>();
        }
    }
}
