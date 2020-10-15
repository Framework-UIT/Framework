using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Framework.Models;
#nullable disable

namespace Framework.Data
{
    public partial class FrameworkContext : DbContext
    {
        public FrameworkContext()
        {
        }

        public FrameworkContext(DbContextOptions<FrameworkContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Card> Cards { get; set; }
        public virtual DbSet<Cardset> Cardsets { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Usercard> Usercards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;port=3306;user=fw_admin;password=fw_admin;database=Framework", x => x.ServerVersion("10.4.11-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Card>(entity =>
            {
                entity.ToTable("card");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id")
                    .HasAnnotation("Relational:ColumnType", "int(11)");

                entity.Property(e => e.CategoryId)
                    .HasColumnType("int(11)")
                    .HasColumnName("category_id")
                    .HasAnnotation("Relational:ColumnType", "int(11)");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci")
                    .HasAnnotation("Relational:ColumnType", "text");

                entity.Property(e => e.ImgUrl)
                    .HasColumnType("text")
                    .HasColumnName("img_url")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci")
                    .HasAnnotation("Relational:ColumnType", "text");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasColumnName("name")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci")
                    .HasAnnotation("Relational:ColumnType", "varchar(100)");
            });

            modelBuilder.Entity<Cardset>(entity =>
            {
                entity.ToTable("cardset");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("id")
                    .HasAnnotation("Relational:ColumnType", "int(11)");

                entity.Property(e => e.CategoryId)
                    .HasColumnType("varchar(20)")
                    .HasColumnName("category_id")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci")
                    .HasAnnotation("Relational:ColumnType", "varchar(20)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasColumnName("name")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci")
                    .HasAnnotation("Relational:ColumnType", "varchar(20)");

                entity.Property(e => e.Quantity)
                    .HasColumnType("int(11)")
                    .HasColumnName("quantity")
                    .HasAnnotation("Relational:ColumnType", "int(11)");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("category");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci")
                    .HasAnnotation("Relational:ColumnType", "text");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id")
                    .HasAnnotation("Relational:ColumnType", "int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasColumnName("name")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci")
                    .HasAnnotation("Relational:ColumnType", "varchar(20)");
            });

            modelBuilder.Entity<Usercard>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("usercard");

                entity.Property(e => e.CardId)
                    .HasColumnType("int(11)")
                    .HasColumnName("card_id")
                    .HasAnnotation("Relational:ColumnType", "int(11)");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("user_id")
                    .HasAnnotation("Relational:ColumnType", "int(11)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
