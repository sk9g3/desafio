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
    public class CompanyService : ServiceBase<Company>, ICompanyService
    {
        private readonly ICompanyRepository companyRepository;
        public CompanyService(ICompanyRepository companyRepository) : base(companyRepository)
        {
            this.companyRepository = companyRepository;
        }

        public override StatusData Save(List<Company> companies)
        {
            const string statusAtivo = "ATIVO";
            const string statusInativo = "INATIVO";

            if (companies.Any(company => !string.Equals(company.status, statusAtivo) && !string.Equals(company.status, statusInativo)))
            {
                return new StatusData(HttpStatusCode.BadRequest, "‘status’ fornecido no body diferente de “ATIVO” ou “INATIVO”");
            }

            var savedIds = companyRepository.FindAll().Select(company => company.id);
            var idsToSave = companies.Select(company => company.id);

            if (savedIds.Intersect(idsToSave).Any())
            {
                return new StatusData(HttpStatusCode.BadRequest, $"id empresa ({string.Join(",", savedIds.Intersect(idsToSave))}) fornecido no body já existe no arquivo");
            }

            return base.Save(companies);
        }

        public StatusData Delete(string id)
        {
            const string statusInativo = "INATIVO";

            var companies = companyRepository.FindAll();
            var company = companies.FirstOrDefault(company => company.id.Equals(id));
            if (company == null)
            {
                return new StatusData(HttpStatusCode.BadRequest, $"Não encontrado.");
            }
            company.status = statusInativo;
            companyRepository.Save(companies);
            return new StatusData(HttpStatusCode.OK);

        }

        public StatusData SaveCost(string companyId, Cost cost)
        {
            try
            {
                var company = companyRepository.FindById(companyId);
                if (company == null)
                {
                    return new StatusData(HttpStatusCode.NotFound, $"Não encontrado.");
                }
                var savedCost = company.custos.FirstOrDefault(savedCost => savedCost.id_type == cost.id_type && savedCost.ano == cost.ano);
                if (savedCost != null)
                {
                    company.custos.Remove(savedCost);
                }
                company.custos.Add(cost);

                return Save(company);
            }
            catch
            {
                return new StatusData(HttpStatusCode.InternalServerError, "Ocorreu um erro, tente novamente mais tarde.");
            }
        }

        public StatusData FindById(string id)
        {
            try
            {
                var company = companyRepository.FindById(id);

                if (company == null)
                {
                    return new StatusData(HttpStatusCode.NotFound, $"Não encontrado.");
                }
                return new StatusData(HttpStatusCode.OK, company);
            }
            catch
            {
                return new StatusData(HttpStatusCode.InternalServerError, "Ocorreu um erro, tente novamente mais tarde.");
            }

        }
    }
}