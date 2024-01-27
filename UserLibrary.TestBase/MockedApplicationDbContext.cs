using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MockQueryable.NSubstitute;
using NSubstitute;

using UserLibrary.Application;
using UserLibrary.Domain.Entities;

namespace UserLibrary.TestBase
{
    public class MockedApplicationDbContext
    {
        public MockedApplicationDbContext()
        {
            Companies = new List<Company>() {
                new Company()
                {
                    Id = 1,
                    Bs = "asdf",
                    CatchPhrase = "yes",
                    Name = "Google"
                }
            };

            Users = new List<User>()
            {
                new User{
                    City = "Kalajoki",
                    CreatedUtc = DateTime.UtcNow,
                    ModifiedUtc = DateTime.UtcNow,
                    Email = "test@test.com",
                    Name = "Tester",
                    Phone = "123456789",
                    Street = "Kalatie 12",
                    Username = "tester",
                    Suite = "Jee",
                    Website = "www.google.com",
                    ZipCode = "12345",
                    Company = Companies[0],
                    CompanyId = Companies[0].Id,
                    Id = 1
                }
            };

            ApplicationDbContext = Substitute.For<IApplicationDbContext>();

            var userMock = Users.AsQueryable().BuildMockDbSet();
            var companiesMock = Companies.AsQueryable().BuildMockDbSet();

            ApplicationDbContext.Users.Returns(userMock);
            ApplicationDbContext.Companies.Returns(companiesMock);
        }

        public IApplicationDbContext ApplicationDbContext { get; set; }
        public List<Company> Companies { get; set; }
        public List<User> Users { get; set; }
    }
}