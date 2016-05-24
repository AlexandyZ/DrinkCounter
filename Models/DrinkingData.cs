
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrinkCounter.Models
{
    public class DrinkingData : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(256);
                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(256);
                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .HasColumnType("char");
            });

            modelBuilder.Entity<DrinkCount>(entity =>
            {
                entity.HasOne(d => d.UserInfo).WithMany(p => p.DrinkCount).HasForeignKey(d => d.UserId).OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.DrinkType).WithMany(p => p.DrinkCount).HasForeignKey(d => d.TypeId).OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<TeamMember>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.TeamId });
                entity.Property(e => e.Activated).HasDefaultValue(true);
                entity.HasOne(d => d.UserInfo).WithMany(p => p.TeamMember).HasForeignKey(d => d.UserId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(d => d.Team).WithMany(p => p.TeamMember).HasForeignKey(d => d.TeamId).OnDelete(DeleteBehavior.Restrict);
            });
        }
        public DbSet<DrinkType> DrinkTypes { get; set; }
        public DbSet<DrinkCategory> DrinkCategories { get; set; }
        public DbSet<DrinkCount> DrinkCounts { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
    }
}