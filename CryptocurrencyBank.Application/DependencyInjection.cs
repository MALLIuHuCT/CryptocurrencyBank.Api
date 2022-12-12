﻿using CryptocurrencyBank.Application.Balances;
using CryptocurrencyBank.Application.MoneyTransfers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrencyBank.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<BalanceService>();
            services.AddScoped<MoneyTransferService>();
            return services;
        }
    }
}
