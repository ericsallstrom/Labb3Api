﻿// <auto-generated />
using System;
using Labb3Api_V2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Labb3Api_V2.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240422141411_InitCreate")]
    partial class InitCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Labb3Api_V2.Models.Hobby", b =>
                {
                    b.Property<int>("HobbyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HobbyId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.HasKey("HobbyId");

                    b.ToTable("Hobbies");
                });

            modelBuilder.Entity("Labb3Api_V2.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonId"));

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("PersonId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("Labb3Api_V2.Models.PersonHobby", b =>
                {
                    b.Property<int>("PersonHobbyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonHobbyId"));

                    b.Property<int>("FkHobbyId")
                        .HasColumnType("int");

                    b.Property<int>("FkPersonId")
                        .HasColumnType("int");

                    b.HasKey("PersonHobbyId");

                    b.HasIndex("FkHobbyId");

                    b.HasIndex("FkPersonId");

                    b.ToTable("PersonHobbies");
                });

            modelBuilder.Entity("Labb3Api_V2.Models.WebLink", b =>
                {
                    b.Property<int>("WebLinkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WebLinkId"));

                    b.Property<int>("FkHobbyId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("WebLinkId");

                    b.HasIndex("FkHobbyId");

                    b.ToTable("WebLinks");
                });

            modelBuilder.Entity("Labb3Api_V2.Models.PersonHobby", b =>
                {
                    b.HasOne("Labb3Api_V2.Models.Hobby", "Hobby")
                        .WithMany("PersonHobbies")
                        .HasForeignKey("FkHobbyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Labb3Api_V2.Models.Person", "Person")
                        .WithMany("PersonHobbies")
                        .HasForeignKey("FkPersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hobby");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Labb3Api_V2.Models.WebLink", b =>
                {
                    b.HasOne("Labb3Api_V2.Models.Hobby", "Hobby")
                        .WithMany("WebLinks")
                        .HasForeignKey("FkHobbyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hobby");
                });

            modelBuilder.Entity("Labb3Api_V2.Models.Hobby", b =>
                {
                    b.Navigation("PersonHobbies");

                    b.Navigation("WebLinks");
                });

            modelBuilder.Entity("Labb3Api_V2.Models.Person", b =>
                {
                    b.Navigation("PersonHobbies");
                });
#pragma warning restore 612, 618
        }
    }
}
