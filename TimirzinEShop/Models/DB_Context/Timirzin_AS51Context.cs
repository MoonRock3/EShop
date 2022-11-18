using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TimirzinEShop.DB_Context
{
    public partial class Timirzin_AS51Context : DbContext
    {
        public Timirzin_AS51Context()
        {
        }

        public Timirzin_AS51Context(DbContextOptions<Timirzin_AS51Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Attribute> Attributes { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CategoryAttribute> CategoryAttributes { get; set; }
        public virtual DbSet<CategoryAttributesView> CategoryAttributesViews { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductAttribute> ProductAttributes { get; set; }
        public virtual DbSet<ProductAttributesView> ProductAttributesViews { get; set; }
        public virtual DbSet<ProductView> ProductViews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=ЕГОР-ПК;Initial Catalog=Timirzin_AS-51;Integrated Security=True");
                //optionsBuilder.UseSqlServer("Data Source = server46; Initial Catalog = Timirzin_AS-51; User ID = stud; Password = stud");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Attribute>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<CategoryAttribute>(entity =>
            {
                entity.HasOne(d => d.Attribute)
                    .WithMany(p => p.CategoryAttributes)
                    .HasForeignKey(d => d.AttributeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CategoryAttributes_CategoryAttributes");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.CategoryAttributes)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CategoryAttributes_Categories");
            });

            modelBuilder.Entity<CategoryAttributesView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("CategoryAttributesView");

                entity.Property(e => e.AttributeName).IsRequired();

                entity.Property(e => e.CategoryName).IsRequired();
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Brand).IsRequired();

                entity.Property(e => e.Country).IsRequired();

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Image).IsRequired();

                entity.Property(e => e.Model).IsRequired();

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_Products");
            });

            modelBuilder.Entity<ProductAttribute>(entity =>
            {
                entity.HasOne(d => d.Attribute)
                    .WithMany(p => p.ProductAttributes)
                    .HasForeignKey(d => d.AttributeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductAttributes_Attributes");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductAttributes)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductAttributes_Products");
            });

            modelBuilder.Entity<ProductAttributesView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ProductAttributesView");

                entity.Property(e => e.AttributeName).IsRequired();

                entity.Property(e => e.CategoryName).IsRequired();

                entity.Property(e => e.ProductBrand).IsRequired();

                entity.Property(e => e.ProductCountry).IsRequired();

                entity.Property(e => e.ProductDescription).IsRequired();

                entity.Property(e => e.ProductImage).IsRequired();

                entity.Property(e => e.ProductModel).IsRequired();
            });

            modelBuilder.Entity<ProductView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ProductView");

                entity.Property(e => e.Brand).IsRequired();

                entity.Property(e => e.CategoryName).IsRequired();

                entity.Property(e => e.Country).IsRequired();

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Image).IsRequired();

                entity.Property(e => e.Model).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
