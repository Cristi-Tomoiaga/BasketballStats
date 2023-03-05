using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8.domain
{
    internal class Student : Entity<long>
    {
        public string Name { get; set; }

        public string School { get; set; }

        public Student(string name, string school)
        {
            Name = name;
            School = school;
        }

        public override bool Equals(object? obj)
        {
            return obj is Student student &&
                   Id == student.Id &&
                   Name == student.Name &&
                   School == student.School;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, School);
        }

        public override string? ToString()
        {
            return $"Id: {Id}, Name: {Name}, School: {School}";
        }
    }
}
