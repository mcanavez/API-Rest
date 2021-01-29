using Microsoft.EntityFrameworkCore;
using RestWithASPNETMesaRadionica.Model.Base;
using RestWithASPNETMesaRadionica.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNETMesaRadionica.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {

        protected MySqlContext _context;
        private DbSet<T> _dataSet;

        public GenericRepository(MySqlContext context)
        {
            _context = context;
            _dataSet = _context.Set<T>();
        }

        public T Create(T item)
        {
            try
            {
                _dataSet.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Delete(long id)
        {

            var result = _dataSet.SingleOrDefault(p => p.Id.Equals(id));

            if (result != null)
            {
                try
                {
                    _dataSet.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool Exists(long id)
        {
            return _dataSet.Any(p => p.Id.Equals(id));
        }

        public T FindById(long id)
        {
           return  _dataSet.SingleOrDefault(p => p.Id.Equals(id));
        }

        public List<T> ReturnAll()
        {
            return _dataSet.ToList();
        }

        public T Update(T item)
        {

            var result = _dataSet.SingleOrDefault(p => p.Id.Equals(item.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(item);
                    _context.SaveChanges();
                    return result;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else { return null; }
        }

        public List<T> FindWithPagedSearch(string query)
        {
            return _dataSet.FromSqlRaw<T>(query).ToList();
        }

        public int GetCount(string query)
        {
            var result = "";
            using (var connection = _context.Database.GetDbConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    result = command.ExecuteScalar().ToString();
                }
            }
            return int.Parse(result);
        }
    }


}
    



