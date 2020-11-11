using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Framework.Models
{
    public partial class prod_frameworkContext : DbContext
    {
        public prod_frameworkContext()
        {
        }

        public prod_frameworkContext(DbContextOptions<prod_frameworkContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Card> Card { get; set; }
        public virtual DbSet<CardSet> CardSet { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Favorite> Favorite { get; set; }
        public virtual DbSet<Set> Set { get; set; }
        public virtual DbSet<Test> Test { get; set; }
        public virtual DbSet<TestResult> TestResult { get; set; }
        public virtual DbSet<TestType> TestType { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserCard> UserCard { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;database=prod_framework", x => x.ServerVersion("10.4.11-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Card>(entity =>
            {
                entity.ToTable("card");

                entity.HasIndex(e => e.CategoryId)
                    .HasName("CategoryID");

                entity.HasIndex(e => e.UserId)
                    .HasName("card_ibfk_2");

                entity.Property(e => e.CardId)
                    .HasColumnName("CardID")
                    .HasColumnType("int(5)");

                entity.Property(e => e.CategoryId)
                    .HasColumnName("CategoryID")
                    .HasColumnType("int(5)");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ImgUrl)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Pronun)
                    .HasColumnName("pronun")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .HasColumnType("int(5)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Card)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("card_ibfk_2");
            });

            modelBuilder.Entity<CardSet>(entity =>
            {
                entity.ToTable("card_set");

                entity.HasIndex(e => e.CardId)
                    .HasName("cardset_ibfk_1");

                entity.HasIndex(e => e.SetId)
                    .HasName("cardset_ibfk_2");

                entity.Property(e => e.CardSetId)
                    .HasColumnName("CardSetID")
                    .HasColumnType("int(5)");

                entity.Property(e => e.CardId)
                    .HasColumnName("CardID")
                    .HasColumnType("int(5)");

                entity.Property(e => e.SetId)
                    .HasColumnName("SetID")
                    .HasColumnType("int(5)");

                entity.HasOne(d => d.Card)
                    .WithMany(p => p.CardSet)
                    .HasForeignKey(d => d.CardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cardset_ibfk_1");

                entity.HasOne(d => d.Set)
                    .WithMany(p => p.CardSet)
                    .HasForeignKey(d => d.SetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cardset_ibfk_2");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");

                entity.Property(e => e.CategoryId)
                    .HasColumnName("CategoryID")
                    .HasColumnType("int(5)");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(1000)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Favorite>(entity =>
            {
                entity.ToTable("favorite");

                entity.HasIndex(e => e.SetId)
                    .HasName("SetID");

                entity.HasIndex(e => new { e.UserId, e.SetId })
                    .HasName("UserID")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.Property(e => e.FavoriteId)
                    .HasColumnName("FavoriteID")
                    .HasColumnType("int(5)");

                entity.Property(e => e.SetId)
                    .HasColumnName("SetID")
                    .HasColumnType("int(5)");

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .HasColumnType("int(5)");
            });

            modelBuilder.Entity<Set>(entity =>
            {
                entity.ToTable("set");

                entity.HasIndex(e => e.UserId)
                    .HasName("UserID");

                entity.Property(e => e.SetId)
                    .HasColumnName("SetID")
                    .HasColumnType("int(5)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Quantity).HasColumnType("int(10)");

                entity.Property(e => e.SetName)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .HasColumnType("int(5)");
            });

            modelBuilder.Entity<Test>(entity =>
            {
                entity.ToTable("test");

                entity.HasIndex(e => e.SetId)
                    .HasName("test_ibfk_2");

                entity.HasIndex(e => e.TypeId)
                    .HasName("test_ibfk_1");

                entity.Property(e => e.TestId)
                    .HasColumnName("TestID")
                    .HasColumnType("int(5)");

                entity.Property(e => e.SetId)
                    .HasColumnName("SetID")
                    .HasColumnType("int(5)");

                entity.Property(e => e.TypeId)
                    .HasColumnName("TypeID")
                    .HasColumnType("int(5)");

                entity.HasOne(d => d.Set)
                    .WithMany(p => p.Test)
                    .HasForeignKey(d => d.SetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("test_ibfk_2");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Test)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("test_ibfk_1");
            });

            modelBuilder.Entity<TestResult>(entity =>
            {
                entity.ToTable("test_result");

                entity.HasIndex(e => e.SetId)
                    .HasName("SetID");

                entity.HasIndex(e => e.TestId)
                    .HasName("TestID");

                entity.HasIndex(e => e.UserId)
                    .HasName("UserID");

                entity.Property(e => e.TestResultId)
                    .HasColumnName("TestResultID")
                    .HasColumnType("int(5)");

                entity.Property(e => e.Score).HasColumnType("int(50)");

                entity.Property(e => e.SetId)
                    .HasColumnName("SetID")
                    .HasColumnType("int(5)");

                entity.Property(e => e.TakenAt).HasColumnType("datetime");

                entity.Property(e => e.TestId)
                    .HasColumnName("TestID")
                    .HasColumnType("int(5)");

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .HasColumnType("int(5)");
            });

            modelBuilder.Entity<TestType>(entity =>
            {
                entity.HasKey(e => e.TypeId)
                    .HasName("PRIMARY");

                entity.ToTable("test_type");

                entity.Property(e => e.TypeId)
                    .HasColumnName("TypeID")
                    .HasColumnType("int(5)");

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .HasColumnType("int(5)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasColumnType("blob");

                entity.Property(e => e.PasswordSalt)
                    .IsRequired()
                    .HasColumnType("blob");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<UserCard>(entity =>
            {
                entity.ToTable("user_card");

                entity.HasIndex(e => e.CardId)
                    .HasName("usercard_ibfk_2");

                entity.HasIndex(e => e.UserId)
                    .HasName("usercard_ibfk_1");

                entity.Property(e => e.UserCardId)
                    .HasColumnName("UserCardID")
                    .HasColumnType("int(5)");

                entity.Property(e => e.CardId)
                    .HasColumnName("CardID")
                    .HasColumnType("int(5)");

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .HasColumnType("int(5)");

                entity.HasOne(d => d.Card)
                    .WithMany(p => p.UserCard)
                    .HasForeignKey(d => d.CardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("usercard_ibfk_2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserCard)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("usercard_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
