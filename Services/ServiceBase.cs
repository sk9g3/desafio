using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using desafio.Helpers;
using desafio.Interfaces.Repositories;
using desafio.Interfaces.Services;
using desafio.Models.Abstract;

namespace desafio.Services
{
    public class ServiceBase<T> : IServiceBase<T> where T : Entity
    {
        private readonly IRepositoryBase<T> baseRepository;

        public ServiceBase(IRepositoryBase<T> baseRepository)
        {
            this.baseRepository = baseRepository;
        }

        public StatusData FindAll()
        {
            try
            {
                var entities = baseRepository.FindAll();
                if (entities.Any())
                    return new StatusData(HttpStatusCode.OK, entities);
                else
                    return new StatusData(HttpStatusCode.NotFound, "Não foi encontrado nenhum resultado.");
            }
            catch
            {
                return new StatusData(HttpStatusCode.NotFound, "Ocorreu um erro, tente novamente mais tarde.");
            }
        }

        public virtual StatusData Save(List<T> entities)
        {
            try
            {
                var savedIds = baseRepository.FindAll();
                savedIds.AddRange(entities);

                baseRepository.Save(savedIds);
                return new StatusData(HttpStatusCode.OK);

            }
            catch
            {
                return new StatusData(HttpStatusCode.InternalServerError, "Ocorreu um erro, tente novamente mais tarde.");
            }
        }

        public virtual StatusData Save(T entity)
        {
            try
            {
                var savedIds = baseRepository.FindAll();
                savedIds.Add(entity);

                baseRepository.Save(savedIds);
                return new StatusData(HttpStatusCode.OK);
            }
            catch
            {
                return new StatusData(HttpStatusCode.NotFound, "Ocorreu um erro, tente novamente mais tarde.");
            }
        }
    }
}