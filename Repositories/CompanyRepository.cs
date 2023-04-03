using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using desafio.Interfaces.Repositories;
using desafio.Interfaces.Services;
using desafio.Models;

namespace desafio.Repositories
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(string filename = "company", string defaultFolder = "Data") : base(filename, defaultFolder)
        {
        }

        public Company FindById(string id) => FindAll().FirstOrDefault(company => company.id.Equals(id));


    }
}