﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Repository.IRepository
{
    public interface IRepository<T>
    {
        Task Add(T obj);
        Task<T> Get(Guid id);
        Task<List<T>> GetAll();
        Task Update(T obj);
        Task Remove(Guid id);
    }
}
