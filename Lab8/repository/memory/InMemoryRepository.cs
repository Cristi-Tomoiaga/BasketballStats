using Lab8.domain;
using Lab8.domain.validator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8.repository.memory
{
    internal class InMemoryRepository<ID, E> : IRepository<ID, E> where E : Entity<ID>
    {
        private readonly IDictionary<ID, E> entities = new Dictionary<ID, E>();
        private readonly IValidator<E> validator;

        public InMemoryRepository(IValidator<E> validator)
        {
            this.validator = validator;
        }

        public IEnumerable<E> FindAll()
        {
            return entities.Values;
        }

        public E? FindOne(ID id)
        {
            if(id == null) 
                throw new ArgumentNullException(nameof(id));

            if (entities.TryGetValue(id, out E? entity))
                return entity;

            return null;
        }

        public E? Save(E entity)
        {
            E? foundEntity = FindOne(entity.Id);

            if (foundEntity == null)
            {
                validator.Validate(entity);
                entities.Add(entity.Id, entity);

                return null;
            }

            return foundEntity;
        }
    }
}
