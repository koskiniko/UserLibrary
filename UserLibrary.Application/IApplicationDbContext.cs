using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLibrary.Domain.Entities;

namespace UserLibrary.Application
{
    /// <summary>
    /// Application Database context
    /// </summary>
    public interface IApplicationDbContext
    {
        /// <summary>
        /// Persisted companies
        /// </summary>
        public DbSet<Company> Companies { get; set; }

        /// <summary>
        /// Persisted users
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Save changes asynchronously
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}