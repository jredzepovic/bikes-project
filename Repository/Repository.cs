using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using bikes_project.Models;
using Microsoft.Extensions.Logging;

namespace bikes_project.Data
{
    public partial class Repository<T> : IRepository<T> where T : class
    {
        private readonly ILogger _logger;
        private readonly DatabaseContext _context;
        private DbSet<T> _entities;

        public Repository(DatabaseContext context, ILogger logger)
        {
            this._logger = logger;
            this._context = context;
        }

        public virtual T GetById(int id)
        {
            return Entities.Find(id);
        }

        public virtual void Insert(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                Entities.Add(entity);
            }
            catch (Exception dbEx)
            {
                _logger.LogError(dbEx.Message);
            }
        }

        public virtual void Insert(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException(nameof(entities));

                foreach (var entity in entities)
                    Entities.Add(entity);
            }
            catch (Exception dbEx)
            {
                _logger.LogError(dbEx.Message);
            }
        }

        public virtual void Update(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));
            }
            catch (Exception dbEx)
            {
                _logger.LogError(dbEx.Message);
            }
        }

        public virtual void Update(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException(nameof(entities));
            }
            catch (Exception dbEx)
            {
                _logger.LogError(dbEx.Message);
            }
        }

        public virtual void Delete(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                Entities.Remove(entity);
            }
            catch (Exception dbEx)
            {
                _logger.LogError(dbEx.Message);
            }
        }

        public virtual void Delete(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException(nameof(entities));

                foreach (var entity in entities)
                    Entities.Remove(entity);
            }
            catch (Exception dbEx)
            {
                _logger.LogError(dbEx.Message);
            }
        }

        public virtual IQueryable<T> Table
        {
            get
            {
                return Entities;
            }
        }

        protected virtual DbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _context.Set<T>();
                return _entities;
            }
        }
    }
}
