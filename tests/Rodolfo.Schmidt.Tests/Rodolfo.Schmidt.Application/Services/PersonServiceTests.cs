using AutoMapper;
using Moq;
using Rodolfo.Schmidt.Application.Dto;
using Rodolfo.Schmidt.Application.Mapping;
using Rodolfo.Schmidt.Application.Services;
using Rodolfo.Schmidt.Domain.Entities;
using Rodolfo.Schmidt.Domain.Interfaces.Repositories;
using Rodolfo.Schmidt.Domain.Interfaces.UoW;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Rodolfo.Schmidt.Tests.Rodolfo.Schmidt.Application.Services
{
    public class PersonServiceTests
    {
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private Mock<IPersonRepository> _mockPersonRepository;
        private IMapper _mapper;

        public PersonServiceTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockPersonRepository = new Mock<IPersonRepository>();
            var mappingProfile = new MappingProfile();

            var config = new MapperConfiguration(mappingProfile);
            _mapper = new Mapper(config);
        }

        [Fact]
        public async Task CreatePerson_CreatingPerson_ReturningSuccessMessageAndTrue()
        {
            // arrange phase
            var person = new PersonDto { Age = 30, Name = "Rodolfo Schmidt" };
            _mockUnitOfWork.Setup(x => x.CommitAsync()).ReturnsAsync(true);

            // processing phase
            var service = new PersonService(_mapper, _mockPersonRepository.Object, _mockUnitOfWork.Object);

            var result = await service.CreatePerson(person);

            // assert phase
            Assert.True(result.Saved);
            Assert.Equal("Person has been created successfuly", result.Message);
        }

        [Fact]
        public async Task DeletePerson_DeletingPerson_ReturningSuccessMessageAndTrue()
        {
            // arrange phase
            _mockUnitOfWork.Setup(x => x.CommitAsync()).ReturnsAsync(true);

            // processing phase
            var service = new PersonService(_mapper, _mockPersonRepository.Object, _mockUnitOfWork.Object);

            var result = await service.DeletePerson(3);

            // assert phase
            Assert.True(result.Deleted);
            Assert.Equal("Person has been deleted successfuly", result.Message);
        }
        
        [Fact]
        public async Task GetPeople_GettingPeople_ReturningPeopleList()
        {
            // arrange phase
            _mockPersonRepository.Setup(x => x.GetAll()).ReturnsAsync(new List<Person> { new Person { Id = 1, Age = 30, Name = "Rodolfo Schmidt" } });

            // processing phase
            var service = new PersonService(_mapper, _mockPersonRepository.Object, _mockUnitOfWork.Object);

            var result = await service.GetPeople();

            // assert phase
            Assert.NotEmpty(result);
            Assert.IsType<List<Person>>(result);
        }

        [Fact]
        public async Task GetPersonById_GettingPerson_ReturningPerson()
        {
            // arrange phase
            _mockPersonRepository.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(new Person { Id = 1, Age = 30, Name = "Rodolfo Schmidt" });

            // processing phase
            var service = new PersonService(_mapper, _mockPersonRepository.Object, _mockUnitOfWork.Object);

            var result = await service.GetPersonById(1);

            // assert phase
            Assert.NotNull(result);
            Assert.Equal("Rodolfo Schmidt", result.Name);
            Assert.IsType<Person>(result);
        }

        [Fact]
        public async Task UpdatePerson_UpdatingPerson_ReturningSuccessMessageAndTrue()
        {
            // arrange phase
            _mockPersonRepository.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(new Person { Id = 1, Age = 30, Name = "Rodolfo Schmidt" });
            _mockUnitOfWork.Setup(x => x.CommitAsync()).ReturnsAsync(true);
            var person = new PersonDto { Age = 30, Name = "Rodolfo Schurhaus Schmidt" };

            // processing phase
            var service = new PersonService(_mapper, _mockPersonRepository.Object, _mockUnitOfWork.Object);

            var result = await service.UpdatePerson(person);

            // assert phase
            Assert.True(result.Updated);
            Assert.Equal("Rodolfo Schurhaus Schmidt", result.person.Name);
            Assert.Equal("Person has been updated successfuly", result.Message);
        }
    }
}
