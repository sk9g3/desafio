using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using desafio.Helpers;
using desafio.Models;
using desafio.Models.Abstract;

namespace desafio.Interfaces.Services
{
    public interface ICompanyService : IServiceBase<Company>
    {
        StatusData FindById(string id);
        StatusData SaveCost(string companyId, Cost cost);
        StatusData Delete(string id);
    }
}