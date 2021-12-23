using System.Linq;
using Microsoft.EntityFrameworkCore;
using Singleton.Models;

namespace Singleton.Services
{
    public class Transient
    {
        private readonly SingletonContext context;

        public Transient(SingletonContext context)
        {
            this.context = context;
        }

        public TransientServiceData[] GetData()
        {
            return this.context.Data
                .AsNoTracking()
                .ToArray();
        }
    }
}