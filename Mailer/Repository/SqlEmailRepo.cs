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
        
        public async Task<IEnumerable<Email>> GetAllEmailsAsync()
        {
            var emails = await Context.Emails.ToListAsync();
            return emails;
        }

        public async Task CreateEmailAsync(Email email)
        {
            await Context.Emails.AddAsync(email);
        }

        public void SaveChangesAsync()
        {
            Context.SaveChangesAsync();
        }
    }
}