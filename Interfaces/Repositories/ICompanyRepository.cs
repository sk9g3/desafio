using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using desafio.Models;

namespace desafio.Interfaces.Repositories
{
    public interface ICompanyRepository : IRepositoryBase<Company>
    {
        Company FindById(string id);
    }
}