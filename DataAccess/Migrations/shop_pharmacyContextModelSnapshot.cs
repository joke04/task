﻿// <auto-generated />
using System;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(shop_pharmacyContext))]
    partial class shop_pharmacyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Models.Basket", b =>
                {
                    b.Property<int>("UserIdd")
                        .HasColumnType("int")
                        .HasColumnName("User_idd");

                    b.Property<int>("BasketNumber")
                        .HasColumnType("int")
                        .HasColumnName("Basket_number");

                    b.Property<int>("QuantityOfGoods")
                        .HasColumnType("int")
                        .HasColumnName("Quantity_of_goods");

                    b.HasKey("UserIdd", "BasketNumber")
                        .HasName("PK__basket__FEB6611CA7BADED3");

                    b.HasIndex("BasketNumber");

                    b.ToTable("basket", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Category", b =>
                {
                    b.Property<int>("IdCategories")
                        .HasColumnType("int")
                        .HasColumnName("Id_categories");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Category_name");

                    b.HasKey("IdCategories")
                        .HasName("PK__categori__26BE28451999F963");

                    b.ToTable("categories", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Filter", b =>
                {
                    b.Property<int>("IdCategories")
                        .HasColumnType("int")
                        .HasColumnName("Id_categories");

                    b.Property<bool>("AvailabilityOfDiscounts")
                        .HasColumnType("bit")
                        .HasColumnName("availability_of_discounts");

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("brand_name");

                    b.Property<int?>("Discounts")
                        .HasColumnType("int")
                        .HasColumnName("discounts");

                    b.Property<string>("ExpirationDate")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("expiration_date");

                    b.Property<string>("Indications")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("indications");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(25,2)");

                    b.Property<string>("Producer")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("producer");

                    b.Property<bool>("ProductAvailability")
                        .HasColumnType("bit")
                        .HasColumnName("product_availability");

                    b.Property<int>("QuantityInPack")
                        .HasColumnType("int")
                        .HasColumnName("quantity_in_pack");

                    b.Property<string>("ReleaseForm")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("release_form");

                    b.Property<string>("VacationFromThePharmacy")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("vacation_from_the_pharmacy");

                    b.HasKey("IdCategories")
                        .HasName("PK__filter__26BE284572D39914");

                    b.ToTable("filter", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Ordering", b =>
                {
                    b.Property<int>("OrderNumber")
                        .HasColumnType("int")
                        .HasColumnName("Order_Number");

                    b.Property<int>("UserIdd")
                        .HasColumnType("int")
                        .HasColumnName("User_idd");

                    b.Property<int>("NumberProduct")
                        .HasColumnType("int")
                        .HasColumnName("Number_product");

                    b.Property<DateTime>("DateAndTimeReferences")
                        .HasColumnType("datetime")
                        .HasColumnName("Date_and_Time_references");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Statuss")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("OrderNumber", "UserIdd", "NumberProduct")
                        .HasName("PK__ordering__B8CE9334EB26F932");

                    b.HasIndex("NumberProduct");

                    b.HasIndex("UserIdd");

                    b.ToTable("ordering", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Product", b =>
                {
                    b.Property<int>("NumberProduct")
                        .HasColumnType("int")
                        .HasColumnName("Number_product");

                    b.Property<int>("Article")
                        .HasColumnType("int");

                    b.Property<int>("IdCategories")
                        .HasColumnType("int")
                        .HasColumnName("Id_categories");

                    b.Property<string>("Namee")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Product_description");

                    b.Property<decimal>("ProductPrice")
                        .HasColumnType("decimal(25,2)")
                        .HasColumnName("Product_price");

                    b.HasKey("NumberProduct")
                        .HasName("PK__product__AA6BD16A70238426");

                    b.HasIndex("IdCategories");

                    b.ToTable("product", (string)null);
                });

            modelBuilder.Entity("Domain.Models.SavedAddress", b =>
                {
                    b.Property<int>("UserIdd")
                        .HasColumnType("int")
                        .HasColumnName("User_idd");

                    b.Property<string>("AddressName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Address_name");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Construction")
                        .HasColumnType("int");

                    b.Property<int>("Flat")
                        .HasColumnType("int");

                    b.Property<int>("House")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UserIdd", "AddressName")
                        .HasName("PK__saved_ad__DF1AA3D460CBA106");

                    b.ToTable("saved_address", (string)null);
                });

            modelBuilder.Entity("Domain.Models.User", b =>
                {
                    b.Property<int>("UserNumber")
                        .HasColumnType("int")
                        .HasColumnName("User_number");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("date");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Last_name");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Namee")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("Phone_number");

                    b.HasKey("UserNumber")
                        .HasName("PK__users__A949FB8D906C53FF");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Basket", b =>
                {
                    b.HasOne("Domain.Models.Product", "BasketNumberNavigation")
                        .WithMany("Baskets")
                        .HasForeignKey("BasketNumber")
                        .IsRequired()
                        .HasConstraintName("FK__basket__Basket_n__44FF419A");

                    b.HasOne("Domain.Models.User", "UserIddNavigation")
                        .WithMany("Baskets")
                        .HasForeignKey("UserIdd")
                        .IsRequired()
                        .HasConstraintName("FK__basket__User_idd__440B1D61");

                    b.Navigation("BasketNumberNavigation");

                    b.Navigation("UserIddNavigation");
                });

            modelBuilder.Entity("Domain.Models.Filter", b =>
                {
                    b.HasOne("Domain.Models.Category", "IdCategoriesNavigation")
                        .WithOne("Filter")
                        .HasForeignKey("Domain.Models.Filter", "IdCategories")
                        .IsRequired()
                        .HasConstraintName("FK__filter__Id_categ__3E52440B");

                    b.Navigation("IdCategoriesNavigation");
                });

            modelBuilder.Entity("Domain.Models.Ordering", b =>
                {
                    b.HasOne("Domain.Models.Product", "NumberProductNavigation")
                        .WithMany("Orderings")
                        .HasForeignKey("NumberProduct")
                        .IsRequired()
                        .HasConstraintName("FK__ordering__Number__48CFD27E");

                    b.HasOne("Domain.Models.User", "UserIddNavigation")
                        .WithMany("Orderings")
                        .HasForeignKey("UserIdd")
                        .IsRequired()
                        .HasConstraintName("FK__ordering__User_i__47DBAE45");

                    b.Navigation("NumberProductNavigation");

                    b.Navigation("UserIddNavigation");
                });

            modelBuilder.Entity("Domain.Models.Product", b =>
                {
                    b.HasOne("Domain.Models.Category", "IdCategoriesNavigation")
                        .WithMany("Products")
                        .HasForeignKey("IdCategories")
                        .IsRequired()
                        .HasConstraintName("FK__product__Id_cate__3B75D760");

                    b.Navigation("IdCategoriesNavigation");
                });

            modelBuilder.Entity("Domain.Models.SavedAddress", b =>
                {
                    b.HasOne("Domain.Models.User", "UserIddNavigation")
                        .WithMany("SavedAddresses")
                        .HasForeignKey("UserIdd")
                        .IsRequired()
                        .HasConstraintName("FK__saved_add__User___412EB0B6");

                    b.Navigation("UserIddNavigation");
                });

            modelBuilder.Entity("Domain.Models.Category", b =>
                {
                    b.Navigation("Filter");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("Domain.Models.Product", b =>
                {
                    b.Navigation("Baskets");

                    b.Navigation("Orderings");
                });

            modelBuilder.Entity("Domain.Models.User", b =>
                {
                    b.Navigation("Baskets");

                    b.Navigation("Orderings");

                    b.Navigation("SavedAddresses");
                });
#pragma warning restore 612, 618
        }
    }
}