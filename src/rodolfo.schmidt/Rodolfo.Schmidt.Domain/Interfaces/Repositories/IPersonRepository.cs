using Rodolfo.Schmidt.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rodolfo.Schmidt.Domain.Interfaces.Repositories
{
    public interface IPersonRepository : IRepository<Person>
    {
        Task<Person> GetPersonById(int id);
        Task<IEnumerable<Person>> GetPeople();
        void DoSavePerson(Person person);
        void DoDeletePerson(Person person);
    }
}
