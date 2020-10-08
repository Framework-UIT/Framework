using System;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Framework.Models
{
    public partial class FrameworkContext : DbContext
    {
        public DbSet<Card> Cards { get; set; }
        public FrameworkContext()
        {
        }

        public FrameworkContext(DbContextOptions<FrameworkContext> options)
            : base(options)
        {
        }
        public IConfiguration Configuration { get; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(Configuration.GetConnectionString("FrameworkConnection"), x => x.ServerVersion("10.4.11-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
