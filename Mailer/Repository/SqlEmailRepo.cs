using System.Collections.Generic;
using System.Threading.Tasks;
using Mailer.Models;
using Microsoft.EntityFrameworkCore;

namespace Mailer.Repository
{
    public class SqlEmailRepo : IEmailRepo
    {
        public DbContextEmail Context { get; set; }
        
        public SqlEmailRepo(DbContextEmail context)
        {
            Context = context;
        }
        
        /// <summary>
        /// Return all records from db
        /// </summary>
        /// <returns>
        /// List of records
        /// </returns>
        public async Task<IEnumerable<Email>> GetAllEmailsAsync()
        {
            var emails = await Context.Emails.ToListAsync();
            return emails;
        }

        /// <summary>
        /// Put new record to db
        /// </summary>
        /// <param name="email"></param>
        public async Task CreateEmailAsync(Email email)
        {
            await Context.Emails.AddAsync(email);
        }

        /// <summary>
        /// Save changes in db
        /// </summary>
        public void SaveChangesAsync()
        {
            Context.SaveChangesAsync();
        }
    }
}