﻿// <auto-generated />
using System;
using MadPay724.Data.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MadPay724.Data.Migrations.MadpayMigrations
{
    [DbContext(typeof(MadpayDbContext))]
    partial class MadpayDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0-preview7.19362.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MadPay724.Data.Models.BankCard", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("BankName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<string>("ExpireDateMonth")
                        .IsRequired()
                        .HasMaxLength(2);

                    b.Property<string>("ExpireDateYear")
                        .IsRequired()
                        .HasMaxLength(2);

                    b.Property<string>("OwnerName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Shaba")
                        .HasMaxLength(50);

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("BankCards");
                });

            modelBuilder.Entity("MadPay724.Data.Models.Notification", b =>
                {
                    b.Property<string>("Id");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<bool>("EnterEmail");

                    b.Property<bool>("EnterSms");

                    b.Property<bool>("EnterTelegram");

                    b.Property<bool>("ExitEmail");

                    b.Property<bool>("ExitSms");

                    b.Property<bool>("ExitTelegram");

                    b.Property<bool>("LoginEmail");

                    b.Property<bool>("LoginSms");

                    b.Property<bool>("LoginTelegram");

                    b.Property<bool>("TicketEmail");

                    b.Property<bool>("TicketSms");

                    b.Property<bool>("TicketTelegram");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("MadPay724.Data.Models.Photo", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("Alt")
                        .HasMaxLength(500);

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<bool>("IsMain");

                    b.Property<string>("PublicId");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(1000);

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("MadPay724.Data.Models.Role", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("MadPay724.Data.Models.Setting", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CloudinaryAPIKey")
                        .IsRequired();

                    b.Property<string>("CloudinaryAPISecret")
                        .IsRequired();

                    b.Property<string>("CloudinaryCloudName")
                        .IsRequired();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<bool>("UploadLocal");

                    b.HasKey("Id");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("MadPay724.Data.Models.Token", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ClientId")
                        .IsRequired();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<DateTime>("ExpireTime");

                    b.Property<string>("Ip")
                        .IsRequired();

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.Property<string>("Value")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Tokens");
                });

            modelBuilder.Entity("MadPay724.Data.Models.User", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<string>("City")
                        .HasMaxLength(100);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("Gender");

                    b.Property<bool>("IsAcive");

                    b.Property<DateTime>("LastActive");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("Status");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("MadPay724.Data.Models.UserRole", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("MadPay724.Data.Models.BankCard", b =>
                {
                    b.HasOne("MadPay724.Data.Models.User", "User")
                        .WithMany("BankCards")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MadPay724.Data.Models.Notification", b =>
                {
                    b.HasOne("MadPay724.Data.Models.User", "User")
                        .WithMany("Notification")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MadPay724.Data.Models.Photo", b =>
                {
                    b.HasOne("MadPay724.Data.Models.User", "User")
                        .WithMany("Photos")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MadPay724.Data.Models.Token", b =>
                {
                    b.HasOne("MadPay724.Data.Models.User", "User")
                        .WithMany("Token")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MadPay724.Data.Models.UserRole", b =>
                {
                    b.HasOne("MadPay724.Data.Models.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MadPay724.Data.Models.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("MadPay724.Data.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("MadPay724.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("MadPay724.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("MadPay724.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
