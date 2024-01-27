using Microsoft.EntityFrameworkCore;
using UserLibrary.Application;
using UserLibrary.Domain.Entities;

namespace UserLibrary.Infrastructure
{
    /// <summary>
    /// User library database context
    /// </summary>
    public class UserLibraryDbContext : DbContext, IApplicationDbContext
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="options"></param>
        public UserLibraryDbContext(DbContextOptions<UserLibraryDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// Company entities
        /// </summary>
        public DbSet<Company> Companies { get; set; }

        /// <summary>
        /// User entities
        /// </summary>
        public DbSet<User> Users { get; set; }
    }
}