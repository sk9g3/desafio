using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using desafio.Models.Abstract;

namespace desafio.Interfaces.Repositories
{
    public interface IRepositoryBase<T> where T : Entity
    {
        List<T> FindAll();
        void Save(List<T> entities);
    }
}