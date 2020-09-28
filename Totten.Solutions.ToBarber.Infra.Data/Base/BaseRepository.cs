using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Totten.Solutions.ToBarber.Domain.Base;
using Totten.Solutions.ToBarber.Infra.CrossCutting.Structs;

namespace Totten.Solutions.ToBarber.Infra.Data.Base
{
    public class BaseRepository<E> : IRepository<E> where E : Entity, new()
    {
        protected ToBarberContext _context;

        public BaseRepository(ToBarberContext context)
            => _context = context;

        public async Task<Result<Exception, E>> CreateAsync(E entity)
        {
            entity.CreatedAt = DateTime.Now;
            entity.Version++;

            var entityToReturn = await _context.AddAsync(entity);

            return entityToReturn.Entity;
        }

        public Result<Exception, IQueryable<E>> GetAll()
            => Result.Run(() => _context.Set<E>().AsNoTracking());

        public async Task<Result<Exception, E>> GetByIdAsync(Guid id)
            => await _context.Set<E>().FindAsync(id);

        public async Task<Result<Exception, Unit>> UpdateAsync(E entity)
        {
            entity.UpdatedIn = DateTime.Now;
            entity.Version++;

            _context.Entry(entity).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return Unit.Successful;
        }
    }
}
