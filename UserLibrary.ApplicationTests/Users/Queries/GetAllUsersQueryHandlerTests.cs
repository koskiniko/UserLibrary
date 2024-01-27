using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserLibrary.TestBase;

namespace UserLibrary.Application.Users.Queries.Tests
{
    [TestClass()]
    public class GetAllUsersQueryHandlerTests
    {
        private readonly MockedApplicationDbContext _mockedApplicationDbContext = new MockedApplicationDbContext();

        [TestMethod]
        public async Task Handle_GetAllUsers_ResultsAreFound()
        {
            var query = new GetAllUsersQueryHandler(_mockedApplicationDbContext.ApplicationDbContext);
            var result = await query.Handle(new GetAllUsersQuery(), default);

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Tester", result[0].Name);
            Assert.AreEqual("Google", result[0].Company?.Name);
        }

        [TestMethod]
        public async Task Handle_GetAllUsersWithFiltering_NoResults()
        {
            var query = new GetAllUsersQueryHandler(_mockedApplicationDbContext.ApplicationDbContext);
            var result = await query.Handle(new GetAllUsersQuery() { NameMustContain = "asd" }, default);

            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public async Task Handle_GetAllUsersWithIncludingFiltering_ResultsContainsOnlyFilteredItems()
        {
            _mockedApplicationDbContext.Users.Add(new Domain.Entities.User() { Name = "asdfqwe" });

            var query = new GetAllUsersQueryHandler(_mockedApplicationDbContext.ApplicationDbContext);
            var result = await query.Handle(new GetAllUsersQuery() { NameMustContain = "asd" }, default);

            Assert.AreEqual(1, result.Count);
        }
    }
}