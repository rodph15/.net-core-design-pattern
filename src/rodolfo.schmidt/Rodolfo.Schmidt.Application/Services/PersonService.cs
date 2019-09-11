using AutoMapper;
using Rodolfo.Schmidt.Application.Dto;
using Rodolfo.Schmidt.Application.Interfaces;
using Rodolfo.Schmidt.Domain.Entities;
using Rodolfo.Schmidt.Domain.Interfaces.Repositories;
using Rodolfo.Schmidt.Domain.Interfaces.UoW;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rodolfo.Schmidt.Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly IMapper _mapper;
        private readonly IPersonRepository _personRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PersonService(IMapper mapper, IPersonRepository personRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _personRepository = personRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<(bool Saved, string Message)> CreatePerson(PersonDto personDto)
        {

            _personRepository.Save(_mapper.Map<Person>(personDto));

            if (!await _unitOfWork.CommitAsync())
                return (false, "Trouble happened, try again later!");

            return (true, "Person has been created successfuly");

        }

        public async Task<(bool Deleted, string Message)> DeletePerson(int id)
        {
            var person = await _personRepository.GetById(id);

            _personRepository.Delete(person);

            if (!await _unitOfWork.CommitAsync())
                return (false, "Trouble happened, try again later!");

            return (true, "Person has been deleted successfuly");
        }

        public async Task<IEnumerable<Person>> GetPeople() => await _personRepository.GetAll();

        public async Task<Person> GetPersonById(int id) => await _personRepository.GetById(id);

        public async Task<(bool Updated, string Message, Person person)> UpdatePerson(PersonDto personDto)
        {
            var person = await _personRepository.GetById(personDto.Id);

            _mapper.Map(personDto, person);

            if (!await _unitOfWork.CommitAsync())
                return (false, "Trouble happened, try again later!", null);

            return (true, "Person has been updated successfuly", person);

        }
    }
}
