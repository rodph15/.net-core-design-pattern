using Rodolfo.Schmidt.Data.Context;
using Rodolfo.Schmidt.Domain.Interfaces.UoW;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rodolfo.Schmidt.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RodolfoSchmidtDbContext _context;

        public UnitOfWork(RodolfoSchmidtDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CommitAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

    }
}
