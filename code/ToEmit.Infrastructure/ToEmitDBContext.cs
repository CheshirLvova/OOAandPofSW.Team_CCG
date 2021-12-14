using System; 
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ToEmit.Domain;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ToEmit.Infrastructure
{
    public partial class ToEmitDBContext : DbContext
    {
        public ToEmitDBContext()
        {
        }

        public ToEmitDBContext(DbContextOptions<ToEmitDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Scores> Scores { get; set; }
        public virtual DbSet<Users> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Scores>(entity =>
            {
                entity.HasIndex(e => e.Username)
                    .HasName("UQ__Scores__536C85E4C4634DCE")
                    .IsUnique();

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.HasOne(d => d.UsernameNavigation)
                    .WithOne(p => p.Scores)
                    .HasPrincipalKey<Users>(p => p.Username)
                    .HasForeignKey<Scores>(d => d.Username)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Scores_Users");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasIndex(e => e.Username)
                    .HasName("UQ__Users__536C85E484A9D1CC")
                    .IsUnique();

                entity.Property(e => e.EmailAddres)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsFixedLength();

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
