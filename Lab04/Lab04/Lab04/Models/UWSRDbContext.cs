using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Lab04.Models
{
    public class UWSRDbContext : DbContext
    {
        public DbSet<WSREF> WSREFs { get; set; }
        public DbSet<WSREFCOMMENT> WSREFComments { get; set; }

        public UWSRDbContext(DbContextOptions<UWSRDbContext> options)
        : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WSREFCOMMENT>()
                .HasOne(c => c.WSREF)
                .WithMany(w => w.Comments)
                .HasForeignKey(c => c.WSREFId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
