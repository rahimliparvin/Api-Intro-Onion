using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _entities;
        public Repository(AppDbContext context)
        {
            _entities = _context.Set<T>();
        }

        public async Task CreateAsync(T entity)
        {
            if (entity == null) { throw new ArgumentNullException(nameof(entity)); }
            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            if (entity == null) { throw new ArgumentNullException(nameof(entity)); }

            _entities.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int? id)
        {
            T entity = await _entities.FindAsync(id);

            if (entity == null) { throw new NullReferenceException(); }

            return entity;
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
