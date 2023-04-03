using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using desafio.Helpers;
using desafio.Interfaces.Repositories;
using desafio.Interfaces.Services;
using desafio.Models;

namespace desafio.Services
{
    public class GroupService : ServiceBase<Group>, IGroupSerivce
    {
        private readonly IGroupRepository groupRepository;
        private readonly ICompanyRepository companyRepository;
        public GroupService(IGroupRepository groupRepository,
                            ICompanyRepository companyRepository) : base(groupRepository)
        {
            this.groupRepository = groupRepository;
            this.companyRepository = companyRepository;
        }

        public StatusData FindAllCompany(string date)
        {
            try
            {
                var groups = groupRepository.FindAll().Where(group => DateTime.Parse(group.date_ingestion) <= DateTime.Parse(date)).SelectMany(group => group.companys);
                if (!groups.Any())
                {
                    return new StatusData(HttpStatusCode.NotFound, "Não encontrado.");
                }
                var companies = companyRepository.FindAll().Where(company => groups.Contains(company.id));
                return new StatusData(HttpStatusCode.OK, companies);
            }
            catch
            {
                return new StatusData(HttpStatusCode.InternalServerError, "Ocorreu um erro, tente novamente mais tarde.");
            }
        }

        public StatusData FindById(int id)
        {
            try
            {
                var company = groupRepository.FindById(id);

                if (company == null)
                {
                    return new StatusData(HttpStatusCode.NotFound, "Não encontrado.");
                }
                return new StatusData(HttpStatusCode.OK, company);
            }
            catch
            {
                return new StatusData(HttpStatusCode.InternalServerError, "Ocorreu um erro, tente novamente mais tarde.");
            }
        }

        public override StatusData Save(Group group)
        {
            var savedIds = groupRepository.FindAll().Select(group => group.id);

            if (savedIds.Contains(group.id))
            {
                return new StatusData(HttpStatusCode.BadRequest, $"id grupo fornecido no body já existe no arquivo");
            }

            return base.Save(group);
        }

        // public void Delete(string id)
        // {
        //     var company = groupRepository.FindAll().FirstOrDefault(company => company.id.Equals(id));
        //     if (company == null)
        //     {
        //         //ERRO
        //     }
        //     var savedCompany = groupRepository.FindAll();
        //     savedCompany.Remove(company);
        //     groupRepository.Save(savedCompany);
        // }


        // public StatusData FindById(int id)
        // {
        //     try
        //     {
        //         var company = groupRepository.FindById(id);

        //         if (company == null)
        //         {
        //             return new StatusData(HttpStatusCode.BadRequest, $"Não encontrado.");
        //         }
        //         return new StatusData(HttpStatusCode.OK, company);
        //     }
        //     catch
        //     {
        //         return new StatusData(HttpStatusCode.NotFound, "Ocorreu um erro, tente novamente mais tarde.");
        //     }

        // }
    }
}