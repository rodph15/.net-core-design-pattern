using Rodolfo.Schmidt.Application.Dto;
using Rodolfo.Schmidt.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rodolfo.Schmidt.Application.Interfaces
{
    public interface IPersonService
    {
        Task<(bool Saved, string Message)> CreatePerson(PersonDto personDto);
        Task<(bool Updated, string Message, Person person)> UpdatePerson(PersonDto personDto);
        Task<(bool Deleted, string Message)> DeletePerson(int id);
        Task<Person> GetPersonById(int id);
        Task<IEnumerable<Person>> GetPeople();
    }
}
