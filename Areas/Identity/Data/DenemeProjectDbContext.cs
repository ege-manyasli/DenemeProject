using DenemeProject.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace DenemeProject.Data;

public class DenemeProjectDbContext : IdentityDbContext<IdentityUser>
{
    public DbSet<User> Users { get; set; }

    public DenemeProjectDbContext(DbContextOptions<DenemeProjectDbContext> options)
        : base(options)
    {
    }

    public DenemeProjectDbContext()
    {
    }

    public object MyEntities { get; internal set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
 
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }


}




