﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atlant.Model;
using Atlant.Repository;

namespace Atlant.Service
{
    public abstract class EntityService<T> : IEntityService<T> where T : Entity
    {
        IUnitOfWork _unitOfWork;
        IGenericRepository<T> _repository;

        public EntityService(IUnitOfWork unitOfWork, IGenericRepository<T> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }
        public void Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _repository.Add(entity);
            _unitOfWork.Commit();
        }

        public void Delete(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _repository.Delete(entity);
            _unitOfWork.Commit();
        }

        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _repository.Edit(entity);
            _unitOfWork.Commit();
        }
    }
}
