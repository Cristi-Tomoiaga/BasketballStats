using Lab8.domain;
using Lab8.domain.validator;
using Lab8.repository.memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8.repository.file
{
    public delegate E CreateEntity<E>(string line);

    internal abstract class InFileRepository<ID, E> : InMemoryRepository<ID, E> where E : Entity<ID>
    {
        private readonly string filename;
        private readonly CreateEntity<E> createEntity;

        public InFileRepository(IValidator<E> validator, string filename, CreateEntity<E> createEntity) : base(validator)
        {
            this.filename = filename;
            this.createEntity = createEntity;
            LoadFromFile();
        }

        private void LoadFromFile()
        {
            using(StreamReader reader = new StreamReader(filename))
            {
                string? line;
                while((line = reader.ReadLine()) != null)
                {
                    E entity = createEntity(line);
                    this.Save(entity);
                }
            }
        } 
    }
}
