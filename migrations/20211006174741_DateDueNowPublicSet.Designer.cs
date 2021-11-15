﻿// <auto-generated />
using System;
using BookCatalog.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookCatalogMvc.Migrations
{
    [DbContext(typeof(BookCatalogContext))]
    [Migration("20211006174741_DateDueNowPublicSet")]
    partial class DateDueNowPublicSet
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookCatalogMvc.Models.Author", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("BookCatalogMvc.Models.Book", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorID")
                        .HasColumnType("int");

                    b.Property<int?>("BorrowedByID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DueInDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("YearPublished")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AuthorID");

                    b.HasIndex("BorrowedByID");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("BookCatalogMvc.Models.LibraryUser", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("FinesPaid")
                        .HasColumnType("float");

                    b.Property<double>("FinesTotal")
                        .HasColumnType("float");

                    b.Property<bool>("IsGoldMember")
                        .HasColumnType("bit");

                    b.Property<int>("MaxBooksAllowed")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumBooksOut")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("LibraryUsers");
                });

            modelBuilder.Entity("BookCatalogMvc.Models.RecordOfLoan", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateBorrowed")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateDue")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateReturned")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsReturned")
                        .HasColumnType("bit");

                    b.Property<int>("LibraryUserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("BookID");

                    b.HasIndex("LibraryUserID");

                    b.ToTable("LoanRecords");
                });

            modelBuilder.Entity("BookCatalogMvc.Models.Book", b =>
                {
                    b.HasOne("BookCatalogMvc.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookCatalogMvc.Models.LibraryUser", "BorrowedBy")
                        .WithMany()
                        .HasForeignKey("BorrowedByID");
                });

            modelBuilder.Entity("BookCatalogMvc.Models.RecordOfLoan", b =>
                {
                    b.HasOne("BookCatalogMvc.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookCatalogMvc.Models.LibraryUser", "LibraryUser")
                        .WithMany("Records")
                        .HasForeignKey("LibraryUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
