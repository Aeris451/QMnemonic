using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QMnemonic.Domain.Entities;
using QMnemonic.Infrastructure.Identity;

namespace QMnemonic.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{

    public DbSet<ApplicationRole> IdentityRoles { get; set; }
    public DbSet<ApplicationUserRole> IdentityUserRoles { get; set; }
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }

    
    public DbSet<Course> Courses { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Quiz> Quizzes { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Answer> Answers { get; set; }
    public DbSet<Reading> Readings { get; set; }
    public DbSet<Text> Texts { get; set; }
    public DbSet<Language> Languages {get; set;}

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        

    }
}
