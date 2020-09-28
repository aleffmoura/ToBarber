using Totten.Solutions.ToBarber.Domain.Features.ProvidedServices;
using Totten.Solutions.ToBarber.Infra.Data.Base;

namespace Totten.Solutions.ToBarber.Infra.Data.Features.ProvidedServices
{
    public class ProvidedServiceRepository : BaseRepository<ProvidedService>, IProvidedServiceRepository
    {
        public ProvidedServiceRepository(ToBarberContext context) : base (context) { }


    }
}
