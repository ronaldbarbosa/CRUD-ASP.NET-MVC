using Microsoft.EntityFrameworkCore;
using frontend_com_aspnet_mvc.Models;

namespace frontend_com_aspnet_mvc.Context
{
    public class ContactsContext : DbContext
    {
        public ContactsContext(DbContextOptions<ContactsContext> options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }        
    }
}