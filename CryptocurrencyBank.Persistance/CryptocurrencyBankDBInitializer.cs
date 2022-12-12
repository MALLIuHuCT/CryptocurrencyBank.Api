using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace CryptocurrencyBank.Persistance
{
    public class CryptocurrencyBankDBInitializer
    {
        public static void Initialize(CryptocurrencyBankDBContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
