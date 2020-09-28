using System;
using System.Linq;
using System.Threading.Tasks;
using Totten.Solutions.ToBarber.Domain.Features.ProvidedServices;
using Totten.Solutions.ToBarber.Infra.CrossCutting.Structs;

namespace Totten.Solutions.ToBarber.Infra.Data.Features.ProvidedServices
{
    public class ProvidedServiceRepository : IProvidedServiceRepository
    {
        public Task<Result<Exception, ProvidedService>> CreateAsync(ProvidedService entity)
        {
            throw new NotImplementedException();
        }

        public Result<Exception, IQueryable<ProvidedService>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Result<Exception, ProvidedService>> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<Exception, Unit>> UpdateAsync(ProvidedService entity)
        {
            throw new NotImplementedException();
        }
    }
}
