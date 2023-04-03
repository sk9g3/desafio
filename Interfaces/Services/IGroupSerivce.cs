using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using desafio.Helpers;
using desafio.Models;
using desafio.Models.Abstract;

namespace desafio.Interfaces.Services
{
    public interface IGroupSerivce : IServiceBase<Group>
    {
        StatusData FindById(int id);
        StatusData FindAllCompany(string date);
    }
}