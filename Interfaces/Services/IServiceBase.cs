using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using desafio.Helpers;
using desafio.Models.Abstract;

namespace desafio.Interfaces.Services
{
    public interface IServiceBase<T> where T : Entity
    {
        StatusData FindAll();
        StatusData Save(List<T> entities);
        StatusData Save(T entity);
    }
}