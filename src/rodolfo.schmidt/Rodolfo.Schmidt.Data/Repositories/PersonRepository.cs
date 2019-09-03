using Rodolfo.Schmidt.Data.Context;
using Rodolfo.Schmidt.Domain.Entities;
using Rodolfo.Schmidt.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rodolfo.Schmidt.Data.Repositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(RodolfoSchmidtDbContext dbContext) : base(dbContext)
        {
        }

        public void DoDeletePerson(Person person)
        {
            Delete(person);
        }

        public void DoSavePerson(Person person)
        {
            Save(person);
        }

        public async Task<IEnumerable<Person>> GetPeople() => await GetAll();

        public async Task<Person> GetPersonById(int id) => await GetById(id);
    }
}
