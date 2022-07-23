using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RecipeAPI.RepDB.RecipeDB
{
    public partial class RecipeDBContext : DbContext
    {
        public RecipeDBContext()
        {
        }

        public RecipeDBContext(DbContextOptions<RecipeDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblCatalogRecipe> TblCatalogRecipes { get; set; } = null!;
        public virtual DbSet<TblCategory> TblCategories { get; set; } = null!;
        public virtual DbSet<TblСomponent> TblСomponents { get; set; } = null!;

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblCatalogRecipe>(entity =>
            {
                entity.ToTable("tblCatalogRecipe");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateAddRecipe)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NameRecipe)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserNameAdd)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cat)
                    .WithMany(p => p.TblCatalogRecipes)
                    .HasForeignKey(d => d.CatId)
                    .HasConstraintName("FK_tblCatalogRecipe_tblCategory");
            });

            modelBuilder.Entity<TblCategory>(entity =>
            {
                entity.ToTable("tblCategory");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CatName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblСomponent>(entity =>
            {
                entity.ToTable("tblСomponent");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Comment)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ComponentName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Rec)
                    .WithMany(p => p.TblСomponents)
                    .HasForeignKey(d => d.RecId)
                    .HasConstraintName("FK_tblСomponent_tblCatalogRecipe");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
