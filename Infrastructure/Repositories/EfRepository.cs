﻿using ApplicationCore.Contracts.Repositories;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class EfRepository<T> : IRepository<T> where T : class
    { 
        protected readonly MovieShopDbContext _dbContext;

        public EfRepository(MovieShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<T> Add(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<T> Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async virtual Task<T> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<T> Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
