using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KittenGeneratorService.Application.SeedWork
{
    public interface IUnitOfWork
    {
        Task<int> CompleteAsync();
    }
}

