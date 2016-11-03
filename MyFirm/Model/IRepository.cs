﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirm.Model
{
    public interface IRepository<T>
    {
        //  List<T> ReturnAllEmployeeAsList();
        IEnumerable<Employees> GetByID(int id);
        void Add(T entity);
        void Update(T entity);
        //  void Delete(T entity);
    }
}
