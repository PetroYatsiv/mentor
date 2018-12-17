using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Forum.Data.Models
{
    public partial class forumDatabaseContext : DbContext
    {

        public virtual DbSet<Section> Section { get; set; }
        public virtual DbSet<Topic> Topic { get; set; }
        public virtual DbSet<SubSection> SubSection { get; set; }

        public forumDatabaseContext()
        {
        }

        public forumDatabaseContext(DbContextOptions<forumDatabaseContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=WS-LV-CP2922\\SQLEXPRESS;Database=forumDatabase;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Section>(entity =>
            {
                entity.Property(e => e.SectionDescription)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Topic>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.Topic)
                    .HasForeignKey(d => d.SectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Topic_Section");
            });
        }
    }
}
