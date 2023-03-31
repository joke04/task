using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccess.Models
{
    public partial class shop_pharmacyContext : DbContext
    {
        public shop_pharmacyContext()
        {
        }

        public shop_pharmacyContext(DbContextOptions<shop_pharmacyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Basket> Baskets { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Filter> Filters { get; set; } = null!;
        public virtual DbSet<Ordering> Orderings { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<SavedAddress> SavedAddresses { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Basket>(entity =>
            {
                entity.HasKey(e => new { e.UserIdd, e.BasketNumber })
                    .HasName("PK__basket__FEB6611CA7BADED3");

                entity.ToTable("basket");

                entity.Property(e => e.UserIdd).HasColumnName("User_idd");

                entity.Property(e => e.BasketNumber).HasColumnName("Basket_number");

                entity.Property(e => e.QuantityOfGoods).HasColumnName("Quantity_of_goods");

                entity.HasOne(d => d.BasketNumberNavigation)
                    .WithMany(p => p.Baskets)
                    .HasForeignKey(d => d.BasketNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__basket__Basket_n__44FF419A");

                entity.HasOne(d => d.UserIddNavigation)
                    .WithMany(p => p.Baskets)
                    .HasForeignKey(d => d.UserIdd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__basket__User_idd__440B1D61");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.IdCategories)
                    .HasName("PK__categori__26BE28451999F963");

                entity.ToTable("categories");

                entity.Property(e => e.IdCategories)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_categories");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(50)
                    .HasColumnName("Category_name");
            });

            modelBuilder.Entity<Filter>(entity =>
            {
                entity.HasKey(e => e.IdCategories)
                    .HasName("PK__filter__26BE284572D39914");

                entity.ToTable("filter");

                entity.Property(e => e.IdCategories)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_categories");

                entity.Property(e => e.AvailabilityOfDiscounts).HasColumnName("availability_of_discounts");

                entity.Property(e => e.BrandName)
                    .HasMaxLength(25)
                    .HasColumnName("brand_name");

                entity.Property(e => e.Discounts).HasColumnName("discounts");

                entity.Property(e => e.ExpirationDate)
                    .HasMaxLength(25)
                    .HasColumnName("expiration_date");

                entity.Property(e => e.Indications)
                    .HasMaxLength(50)
                    .HasColumnName("indications");

                entity.Property(e => e.Price).HasColumnType("decimal(25, 2)");

                entity.Property(e => e.Producer)
                    .HasMaxLength(20)
                    .HasColumnName("producer");

                entity.Property(e => e.ProductAvailability).HasColumnName("product_availability");

                entity.Property(e => e.QuantityInPack).HasColumnName("quantity_in_pack");

                entity.Property(e => e.ReleaseForm)
                    .HasMaxLength(50)
                    .HasColumnName("release_form");

                entity.Property(e => e.VacationFromThePharmacy)
                    .HasMaxLength(20)
                    .HasColumnName("vacation_from_the_pharmacy");

                entity.HasOne(d => d.IdCategoriesNavigation)
                    .WithOne(p => p.Filter)
                    .HasForeignKey<Filter>(d => d.IdCategories)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__filter__Id_categ__3E52440B");
            });

            modelBuilder.Entity<Ordering>(entity =>
            {
                entity.HasKey(e => new { e.OrderNumber, e.UserIdd, e.NumberProduct })
                    .HasName("PK__ordering__B8CE9334EB26F932");

                entity.ToTable("ordering");

                entity.Property(e => e.OrderNumber).HasColumnName("Order_Number");

                entity.Property(e => e.UserIdd).HasColumnName("User_idd");

                entity.Property(e => e.NumberProduct).HasColumnName("Number_product");

                entity.Property(e => e.DateAndTimeReferences)
                    .HasColumnType("datetime")
                    .HasColumnName("Date_and_Time_references");

                entity.Property(e => e.Statuss).HasMaxLength(50);

                entity.HasOne(d => d.NumberProductNavigation)
                    .WithMany(p => p.Orderings)
                    .HasForeignKey(d => d.NumberProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ordering__Number__48CFD27E");

                entity.HasOne(d => d.UserIddNavigation)
                    .WithMany(p => p.Orderings)
                    .HasForeignKey(d => d.UserIdd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ordering__User_i__47DBAE45");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.NumberProduct)
                    .HasName("PK__product__AA6BD16A70238426");

                entity.ToTable("product");

                entity.Property(e => e.NumberProduct)
                    .ValueGeneratedNever()
                    .HasColumnName("Number_product");

                entity.Property(e => e.IdCategories).HasColumnName("Id_categories");

                entity.Property(e => e.Namee).HasMaxLength(50);

                entity.Property(e => e.ProductDescription)
                    .HasMaxLength(50)
                    .HasColumnName("Product_description");

                entity.Property(e => e.ProductPrice)
                    .HasColumnType("decimal(25, 2)")
                    .HasColumnName("Product_price");

                entity.HasOne(d => d.IdCategoriesNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.IdCategories)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__product__Id_cate__3B75D760");
            });

            modelBuilder.Entity<SavedAddress>(entity =>
            {
                entity.HasKey(e => new { e.UserIdd, e.AddressName })
                    .HasName("PK__saved_ad__DF1AA3D460CBA106");

                entity.ToTable("saved_address");

                entity.Property(e => e.UserIdd).HasColumnName("User_idd");

                entity.Property(e => e.AddressName)
                    .HasMaxLength(100)
                    .HasColumnName("Address_name");

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Street).HasMaxLength(50);

                entity.HasOne(d => d.UserIddNavigation)
                    .WithMany(p => p.SavedAddresses)
                    .HasForeignKey(d => d.UserIdd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__saved_add__User___412EB0B6");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserNumber)
                    .HasName("PK__users__A949FB8D906C53FF");

                entity.ToTable("users");

                entity.Property(e => e.UserNumber)
                    .ValueGeneratedNever()
                    .HasColumnName("User_number");

                entity.Property(e => e.Birthdate).HasColumnType("date");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("Last_name");

                entity.Property(e => e.Mail).HasMaxLength(50);

                entity.Property(e => e.Namee).HasMaxLength(50);

                entity.Property(e => e.Nickname).HasMaxLength(50);

                entity.Property(e => e.Patronymic).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(25)
                    .HasColumnName("Phone_number");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
