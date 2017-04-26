﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WebApplication1.Extensions;

namespace WebApplication1.Repositories
{
    public abstract class Repository<TEntity> where TEntity : new()
    {
        protected DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        protected DbContext Context
        {
            get
            {
                return this._context;
            }
        }

        protected IEnumerable<TEntity> ToList(IDbCommand command)
        {
            using (var record = command.ExecuteReader())
            {
                List<TEntity> items = new List<TEntity>();
                while (record.Read())
                {

                    items.Add(Map<TEntity>(record));
                }
                return items;
            }
        }

        protected TEntity Map<tEntity>(IDataRecord record)
        {
            var objT = Activator.CreateInstance<TEntity>();
            foreach (var property in typeof(TEntity).GetProperties())
            {
                if (record.HasColumn(property.Name) && !record.IsDBNull(record.GetOrdinal(property.Name)))
                    property.SetValue(objT, record[property.Name]);
            }
            return objT;
        }

        public IList<TEntity> GetAll()
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = @"SELECT * FROM " + typeof(TEntity).Name.ToString();
                //command.ExecuteReader();
                return ToList(command).ToList() ;
            }
        }


        public abstract TEntity Insert(TEntity tentity);
        public abstract TEntity Update(TEntity tentity);
        public abstract TEntity Delete(TEntity tentity);


    }
}