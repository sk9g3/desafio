using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using desafio.Models;

namespace desafio.Interfaces.Repositories
{
    public interface IGroupRepository : IRepositoryBase<Group>
    {
        Group FindById(int id);
    }
}