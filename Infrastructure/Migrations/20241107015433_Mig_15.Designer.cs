﻿// <auto-generated />
using System;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241107015433_Mig_15")]
    partial class Mig_15
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.About", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("EventCount")
                        .HasColumnType("longtext");

                    b.Property<string>("PartnerCount")
                        .HasColumnType("longtext");

                    b.Property<string>("PartnerLogo")
                        .HasColumnType("longtext");

                    b.Property<string>("SlugUrl")
                        .HasColumnType("longtext");

                    b.Property<string>("SpeakerCount")
                        .HasColumnType("longtext");

                    b.Property<string>("TicketCount")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Abouts");
                });

            modelBuilder.Entity("Domain.Entities.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("FullName")
                        .HasColumnType("longtext");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("Role")
                        .HasColumnType("longtext");

                    b.Property<string>("SecretKey")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("AppUser");

                    b.HasData(
                        new
                        {
                            Id = "f995b871-5fb0-40c7-80e4-a160053ee1bd",
                            CreatedTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "admin@admin.com",
                            FullName = "Admin",
                            PasswordHash = "02fcc34667f101d0b25647c493723a12042aa94fa2cd45e1b2f1c5ef0a7c7b62219b2926451c8f27d1748b514ac06fb1fb69bd8831e7d4406296e3714504c668",
                            Role = "admin",
                            SecretKey = "8bf3a808f96a49be97ec9a3da8b5564d07.11.2024055431",
                            UpdatedTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Domain.Entities.Blog", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("CategoryId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Clock")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FileCode")
                        .HasColumnType("longtext");

                    b.Property<string>("SlugUrl")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("Domain.Entities.Category", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("SlugUrl")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Domain.Entities.Contact", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("FullName")
                        .HasColumnType("longtext");

                    b.Property<bool?>("IsReading")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Message")
                        .HasColumnType("longtext");

                    b.Property<string>("Phone")
                        .HasColumnType("longtext");

                    b.Property<string>("Subject")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("Domain.Entities.Event", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Clock")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("EventDay")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FileCode")
                        .HasColumnType("longtext");

                    b.Property<string>("Link")
                        .HasColumnType("longtext");

                    b.Property<string>("Map")
                        .HasColumnType("longtext");

                    b.Property<string>("PartnerLogo")
                        .HasColumnType("longtext");

                    b.Property<string>("SlugUrl")
                        .HasColumnType("longtext");

                    b.Property<int?>("TicketType")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Domain.Entities.EventCategory", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("CategoryId")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("EventId")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("EventId");

                    b.ToTable("EventCategories");
                });

            modelBuilder.Entity("Domain.Entities.Language", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Code")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("Domain.Entities.Languages.AboutLanguage", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("AboutId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Answer")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Language_Code")
                        .HasColumnType("longtext");

                    b.Property<string>("Question")
                        .HasColumnType("longtext");

                    b.Property<string>("SeoDesc")
                        .HasColumnType("longtext");

                    b.Property<string>("SeoKey")
                        .HasColumnType("longtext");

                    b.Property<string>("SeoTitle")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("AboutId");

                    b.ToTable("AboutLanguages");
                });

            modelBuilder.Entity("Domain.Entities.Languages.BlogLanguage", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("BlogId")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Language_Code")
                        .HasColumnType("longtext");

                    b.Property<string>("SeoDesc")
                        .HasColumnType("longtext");

                    b.Property<string>("SeoKey")
                        .HasColumnType("longtext");

                    b.Property<string>("SeoTitle")
                        .HasColumnType("longtext");

                    b.Property<string>("Text")
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("BlogId");

                    b.ToTable("BlogLanguages");
                });

            modelBuilder.Entity("Domain.Entities.Languages.CategoryLanguage", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("CategoryId")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Language_Code")
                        .HasColumnType("longtext");

                    b.Property<string>("SeoDesc")
                        .HasColumnType("longtext");

                    b.Property<string>("SeoKey")
                        .HasColumnType("longtext");

                    b.Property<string>("SeoTitle")
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("CategoryLanguages");
                });

            modelBuilder.Entity("Domain.Entities.Languages.EventLanguage", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Address")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("EventId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Language_Code")
                        .HasColumnType("longtext");

                    b.Property<string>("Price")
                        .HasColumnType("longtext");

                    b.Property<string>("SeoDesc")
                        .HasColumnType("longtext");

                    b.Property<string>("SeoKey")
                        .HasColumnType("longtext");

                    b.Property<string>("SeoTitle")
                        .HasColumnType("longtext");

                    b.Property<string>("Text")
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("EventLanguages");
                });

            modelBuilder.Entity("Domain.Entities.Languages.SliderLanguage", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Language_Code")
                        .HasColumnType("longtext");

                    b.Property<string>("SeoDesc")
                        .HasColumnType("longtext");

                    b.Property<string>("SeoKey")
                        .HasColumnType("longtext");

                    b.Property<string>("SeoTitle")
                        .HasColumnType("longtext");

                    b.Property<string>("SliderId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("SliderId");

                    b.ToTable("SliderLanguages");
                });

            modelBuilder.Entity("Domain.Entities.Languages.SpeakerLanguage", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FullName")
                        .HasColumnType("longtext");

                    b.Property<string>("Language_Code")
                        .HasColumnType("longtext");

                    b.Property<string>("Postion")
                        .HasColumnType("longtext");

                    b.Property<string>("SeoDesc")
                        .HasColumnType("longtext");

                    b.Property<string>("SeoKey")
                        .HasColumnType("longtext");

                    b.Property<string>("SeoTitle")
                        .HasColumnType("longtext");

                    b.Property<string>("SpeakerId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Text")
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("SpeakerId");

                    b.ToTable("SpeakerLanguages");
                });

            modelBuilder.Entity("Domain.Entities.Photo", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FileCode")
                        .HasColumnType("longtext");

                    b.Property<string>("ProductId")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("Domain.Entities.Slider", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FileCode")
                        .HasColumnType("longtext");

                    b.Property<string>("Link")
                        .HasColumnType("longtext");

                    b.Property<string>("SlugUrl")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Sliders");
                });

            modelBuilder.Entity("Domain.Entities.Speaker", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Facebook")
                        .HasColumnType("longtext");

                    b.Property<string>("FileCode")
                        .HasColumnType("longtext");

                    b.Property<string>("Instagram")
                        .HasColumnType("longtext");

                    b.Property<string>("Linkedin")
                        .HasColumnType("longtext");

                    b.Property<string>("SlugUrl")
                        .HasColumnType("longtext");

                    b.Property<string>("Twitter")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Speakers");
                });

            modelBuilder.Entity("Domain.Entities.SpeakerEvent", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("EventId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("SpeakerId")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("SpeakerId");

                    b.ToTable("SpeakerEvents");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<string>("Surname")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Blog", b =>
                {
                    b.HasOne("Domain.Entities.Category", "Category")
                        .WithMany("Blogs")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Domain.Entities.EventCategory", b =>
                {
                    b.HasOne("Domain.Entities.Category", "Category")
                        .WithMany("EventCategories")
                        .HasForeignKey("CategoryId");

                    b.HasOne("Domain.Entities.Event", "Event")
                        .WithMany("EventCategories")
                        .HasForeignKey("EventId");

                    b.Navigation("Category");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("Domain.Entities.Languages.AboutLanguage", b =>
                {
                    b.HasOne("Domain.Entities.About", "About")
                        .WithMany("AboutLanguages")
                        .HasForeignKey("AboutId");

                    b.Navigation("About");
                });

            modelBuilder.Entity("Domain.Entities.Languages.BlogLanguage", b =>
                {
                    b.HasOne("Domain.Entities.Blog", "Blog")
                        .WithMany("BlogLanguages")
                        .HasForeignKey("BlogId");

                    b.Navigation("Blog");
                });

            modelBuilder.Entity("Domain.Entities.Languages.CategoryLanguage", b =>
                {
                    b.HasOne("Domain.Entities.Category", "Category")
                        .WithMany("CategoryLanguages")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Domain.Entities.Languages.EventLanguage", b =>
                {
                    b.HasOne("Domain.Entities.Event", "Event")
                        .WithMany("EventLanguages")
                        .HasForeignKey("EventId");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("Domain.Entities.Languages.SliderLanguage", b =>
                {
                    b.HasOne("Domain.Entities.Slider", "Slider")
                        .WithMany("SliderLanguages")
                        .HasForeignKey("SliderId");

                    b.Navigation("Slider");
                });

            modelBuilder.Entity("Domain.Entities.Languages.SpeakerLanguage", b =>
                {
                    b.HasOne("Domain.Entities.Speaker", "Speaker")
                        .WithMany("SpeakerLanguages")
                        .HasForeignKey("SpeakerId");

                    b.Navigation("Speaker");
                });

            modelBuilder.Entity("Domain.Entities.SpeakerEvent", b =>
                {
                    b.HasOne("Domain.Entities.Event", "Event")
                        .WithMany("SpeakerEvents")
                        .HasForeignKey("EventId");

                    b.HasOne("Domain.Entities.Speaker", "Speaker")
                        .WithMany("SpeakerEvents")
                        .HasForeignKey("SpeakerId");

                    b.Navigation("Event");

                    b.Navigation("Speaker");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.About", b =>
                {
                    b.Navigation("AboutLanguages");
                });

            modelBuilder.Entity("Domain.Entities.Blog", b =>
                {
                    b.Navigation("BlogLanguages");
                });

            modelBuilder.Entity("Domain.Entities.Category", b =>
                {
                    b.Navigation("Blogs");

                    b.Navigation("CategoryLanguages");

                    b.Navigation("EventCategories");
                });

            modelBuilder.Entity("Domain.Entities.Event", b =>
                {
                    b.Navigation("EventCategories");

                    b.Navigation("EventLanguages");

                    b.Navigation("SpeakerEvents");
                });

            modelBuilder.Entity("Domain.Entities.Slider", b =>
                {
                    b.Navigation("SliderLanguages");
                });

            modelBuilder.Entity("Domain.Entities.Speaker", b =>
                {
                    b.Navigation("SpeakerEvents");

                    b.Navigation("SpeakerLanguages");
                });
#pragma warning restore 612, 618
        }
    }
}
