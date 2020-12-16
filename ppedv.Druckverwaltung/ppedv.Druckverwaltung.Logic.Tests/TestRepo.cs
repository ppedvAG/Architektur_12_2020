using ppedv.Druckverwaltung.Model;
using ppedv.Druckverwaltung.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ppedv.Druckverwaltung.Logic.Tests
{
    class TestRepo : IRepository
    {
        public void Add<T>(T entity) where T : Model.Entity
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T entity) where T : Model.Entity
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll<T>() where T : Model.Entity
        {
            throw new NotImplementedException();
        }

        public T GetById<T>(int id) where T : Model.Entity
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Query<T>() where T : Model.Entity
        {
            if (typeof(T) == typeof(Druckauftrag))
                return new List<Druckauftrag>().Cast<T>().AsQueryable();

            throw new NotImplementedException();
        }

        public int Save()
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T entity) where T : Model.Entity
        {
            throw new NotImplementedException();
        }
    }
}
