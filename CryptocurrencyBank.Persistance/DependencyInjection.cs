using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using CryptocurrencyBank.Application.Abstractions.DBContext;
using CryptocurrencyBank.Domain.Repositories;
using CryptocurrencyBank.Persistance.Repositories;

namespace CryptocurrencyBank.Persistance
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DBConnection"];
            services.AddDbContext<CryptocurrencyBankDBContext>(options =>
            {
                options.UseSqlite(connectionString);
            });
            services.AddScoped<IDBContext>(provider =>
                provider.GetService<CryptocurrencyBankDBContext>());

            services.AddScoped<IBalanceRepository, BalanceRepository>();
            services.AddScoped<IMoneyTransferRepository, MoneyTransferReposiroty>();

            return services;
        }
    }
}
