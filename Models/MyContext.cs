using Microsoft.EntityFrameworkCore;

namespace DenemeProject.Models
{
    public class MyContext : DbContext
    {

        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<MusteriKayit> MusteriKayits { get; set; }
        public static List<User> DataSource { get;  set; }
        public object MusteriKayit { get; internal set; }
    }



}

