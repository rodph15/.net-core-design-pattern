using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rodolfo.Schmidt.Domain.Interfaces.UoW
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync();
    }
}
