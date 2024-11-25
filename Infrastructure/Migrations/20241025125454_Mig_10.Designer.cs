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
    [Migration("20241025125454_Mig_10")]
    partial class Mig_10
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
                            Id = "23094857-c0e3-4a58-b830-b7267b57c837",
                            CreatedTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "admin@admin.com",
                            FullName = "Admin",
                            PasswordHash = "08f1f7234e2b64b3a2b3383659bd693b2365d16c9c9061899b646744e67819352bc623b196ca1794b3d170f9b973567a0f81f78ab55c00d7b9aa6674fcd28f05",
                            Role = "admin",
                            SecretKey = "ec370c894dd14637932425f80608539225.10.2024165454",
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

                    b.Property<string>("Map")
                        .HasColumnType("longtext");

                    b.Property<string>("PartnerLogo")
                        .HasColumnType("longtext");

                    b.Property<string>("SlugUrl")
                        .HasColumnType("longtext");

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
