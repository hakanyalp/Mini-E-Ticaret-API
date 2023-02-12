﻿using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities.Common;
using ETicaretAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace ETicaretAPI.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly ETicaretAPIDBContext _context;

        public ReadRepository(ETicaretAPIDBContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll()
            => Table;

        public IQueryable<T> GetWhere(System.Linq.Expressions.Expression<Func<T, bool>> method)
            => Table.Where(method);

        public async Task<T> GetSingleAsync(System.Linq.Expressions.Expression<Func<T, bool>> method)
            => await Table.FirstOrDefaultAsync(method);

        public async Task<T> GetByIdAsync(string id)
            => await Table.FindAsync(Guid.Parse(id));
            //=> await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));    // Generic Repository ile alternatifi

    }
}
