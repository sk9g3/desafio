using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using desafio.Interfaces.Repositories;
using desafio.Models;

namespace desafio.Repositories
{
    public class GroupRepository : RepositoryBase<Group>, IGroupRepository
    {
        public GroupRepository(string filename = "group", string defaultFolder = "Data") : base(filename, defaultFolder)
        {
        }

        public Group FindById(int id) => FindAll().FirstOrDefault(group => group.id.Equals(id));

    }
}