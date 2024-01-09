using Microsoft.EntityFrameworkCore;
using Phone_Book.Models;

namespace Phone_Book.DAL
{
    public class ContactsDBContext : DbContext
    {
        public ContactsDBContext(DbContextOptions options) : base(options)
        {
        }
     public DbSet<Contact> Contacts {get; set; }

    }
}
