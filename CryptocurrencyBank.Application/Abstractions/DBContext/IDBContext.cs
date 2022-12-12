using CryptocurrencyBank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrencyBank.Application.Abstractions.DBContext
{
    public interface IDBContext
    {
        DbSet<Balance> Balances { get; set; }
        DbSet<MoneyTransfer> MoneyTransfers { get; set; }
        Task SaveAsync();
    }
}
