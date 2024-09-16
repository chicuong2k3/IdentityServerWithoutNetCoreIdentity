﻿// <auto-generated />
using System;
using IdentityProvider.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IdentityProvider.Database.Migrations
{
    [DbContext(typeof(IdentityDbContext))]
    [Migration("20240915143628_AddUserLogin")]
    partial class AddUserLogin
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("IdentityProvider.Entites.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Active")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("SecurityCode")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("SecurityCodeExpirationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Subject")
                        .IsUnique();

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f5f4b3b3-3b6d-4b1e-8b3d-3b6d4b1e8b3d"),
                            Active = true,
                            ConcurrencyStamp = "f988317b-68fd-4642-bc9d-c929e957b8fd",
                            Email = "chicuong123@gmail.com",
                            Password = "AQAAAAIAAYagAAAAEIIxIqb+BIr8sVrz4ajEq6UmpP4grpHsH6rvpAi1jr0TebKi0BXhosbHY6GHlEckMA==",
                            SecurityCodeExpirationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Subject = "7bae0f06-1569-48b9-835e-a7b4f1f537c1",
                            UserName = "cuong"
                        },
                        new
                        {
                            Id = new Guid("f5f4b3b3-3b6d-4b1e-4a3d-3b6d4b1e2a6a"),
                            Active = true,
                            ConcurrencyStamp = "78f13507-9602-452c-a69f-2122ed938b29",
                            Email = "tandung@gmail.com",
                            Password = "AQAAAAIAAYagAAAAEB5Hd+NJ2VoB35V3X0vXYHi9Lfo0oaSMWHcOVFyUwtVGiafNpkFhCWnErV9p3V5+ig==",
                            SecurityCodeExpirationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Subject = "b9ebf3fd-e42c-4514-bfb4-6266bb5a55e7",
                            UserName = "dung"
                        });
                });

            modelBuilder.Entity("IdentityProvider.Entites.UserClaim", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims");

                    b.HasData(
                        new
                        {
                            Id = new Guid("adeda7a6-8336-4f6e-b9c9-4401e6144567"),
                            ConcurrencyStamp = "4075953c-f325-46aa-b6aa-12b09904a8fe",
                            Type = "given_name",
                            UserId = new Guid("f5f4b3b3-3b6d-4b1e-8b3d-3b6d4b1e8b3d"),
                            Value = "Cường"
                        },
                        new
                        {
                            Id = new Guid("c121fd73-ec4c-4182-b5a0-de483b1c017b"),
                            ConcurrencyStamp = "da12ad88-48ba-49b3-b316-da833d777e52",
                            Type = "family_name",
                            UserId = new Guid("f5f4b3b3-3b6d-4b1e-8b3d-3b6d4b1e8b3d"),
                            Value = "Nguyễn"
                        },
                        new
                        {
                            Id = new Guid("26be2f78-e1cc-4033-9478-5b277dcbc322"),
                            ConcurrencyStamp = "d4b8ddb8-22f8-4d87-ba48-714cda184c3a",
                            Type = "role",
                            UserId = new Guid("f5f4b3b3-3b6d-4b1e-8b3d-3b6d4b1e8b3d"),
                            Value = "Admin"
                        },
                        new
                        {
                            Id = new Guid("8d4e2b9c-aab0-4ecb-acb5-f457212cb95a"),
                            ConcurrencyStamp = "18ce75d3-57a2-4132-8191-b29e64e1095f",
                            Type = "country",
                            UserId = new Guid("f5f4b3b3-3b6d-4b1e-8b3d-3b6d4b1e8b3d"),
                            Value = "cn"
                        },
                        new
                        {
                            Id = new Guid("08435fb2-6a0e-4b7d-88f4-130947397a67"),
                            ConcurrencyStamp = "671b72d2-8655-4fb0-9ed5-59826842871b",
                            Type = "given_name",
                            UserId = new Guid("f5f4b3b3-3b6d-4b1e-4a3d-3b6d4b1e2a6a"),
                            Value = "Dũng"
                        },
                        new
                        {
                            Id = new Guid("6f5b1f0b-b402-40a2-89c7-cd327d0a2d9f"),
                            ConcurrencyStamp = "a2c63b26-e66d-4a0a-b4cf-2a79ae041d73",
                            Type = "family_name",
                            UserId = new Guid("f5f4b3b3-3b6d-4b1e-4a3d-3b6d4b1e2a6a"),
                            Value = "Tấn"
                        },
                        new
                        {
                            Id = new Guid("5bf608d3-4e77-447d-a185-0dfa11d3c196"),
                            ConcurrencyStamp = "231f4c32-1e80-42a3-924c-d602a13119ab",
                            Type = "role",
                            UserId = new Guid("f5f4b3b3-3b6d-4b1e-4a3d-3b6d4b1e2a6a"),
                            Value = "Customer"
                        },
                        new
                        {
                            Id = new Guid("2ee539e3-1256-401f-9ba1-0810622fbb6b"),
                            ConcurrencyStamp = "448f0773-b75c-4491-bbf6-a3863bd83f45",
                            Type = "country",
                            UserId = new Guid("f5f4b3b3-3b6d-4b1e-4a3d-3b6d4b1e2a6a"),
                            Value = "vn"
                        });
                });

            modelBuilder.Entity("IdentityProvider.Entites.UserLogin", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Provider")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderIdentityKey")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("IdentityProvider.Entites.UserClaim", b =>
                {
                    b.HasOne("IdentityProvider.Entites.User", "User")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("IdentityProvider.Entites.UserLogin", b =>
                {
                    b.HasOne("IdentityProvider.Entites.User", "User")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("IdentityProvider.Entites.User", b =>
                {
                    b.Navigation("Claims");

                    b.Navigation("Logins");
                });
#pragma warning restore 612, 618
        }
    }
}
