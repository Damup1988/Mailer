using Mailer.Models;
using Microsoft.EntityFrameworkCore;

namespace Mailer.Repository
{
    public class DbContextEmail : DbContext
    {
        public DbContextEmail(DbContextOptions<DbContextEmail> opt) : base(opt) {}

        public DbSet<Email> Emails { get; set; }
    }
}