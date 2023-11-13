﻿// <auto-generated />
using System;
using BookLinks.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookLinks.Repositories.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231110123149_EditUser")]
    partial class EditUser
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("BookLinks.Repositories.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(10000)
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageContent")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("TEXT");

                    b.Property<string>("OriginalFileName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Rating")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Released")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Update")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("BookLinks.Repositories.Models.Link", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BookId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.ToTable("Links");
                });

            modelBuilder.Entity("BookLinks.Repositories.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("TEXT");

                    b.Property<string>("BrowserId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsBanned")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("LastLoginDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastLoginIP")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("TEXT");

                    b.Property<string>("PwdHash")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("TEXT");

                    b.Property<int>("Role")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Update")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BookLinks.Repositories.Models.Link", b =>
                {
                    b.HasOne("BookLinks.Repositories.Models.Book", "Book")
                        .WithMany("Links")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("BookLinks.Repositories.Models.Book", b =>
                {
                    b.Navigation("Links");
                });
#pragma warning restore 612, 618
        }
    }
}