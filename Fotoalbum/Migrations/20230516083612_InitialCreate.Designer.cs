﻿// <auto-generated />
using Fotoalbum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Fotoalbum.Migrations
{
    [DbContext(typeof(PhotoalbumContext))]
    [Migration("20230516083612_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CategoryPhotoEntry", b =>
                {
                    b.Property<int>("CategoriesId")
                        .HasColumnType("int");

                    b.Property<int>("PhotoEntriesId")
                        .HasColumnType("int");

                    b.HasKey("CategoriesId", "PhotoEntriesId");

                    b.HasIndex("PhotoEntriesId");

                    b.ToTable("CategoryPhotoEntry");
                });

            modelBuilder.Entity("Fotoalbum.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("last_name");

                    b.HasKey("Id");

                    b.ToTable("authors");
                });

            modelBuilder.Entity("Fotoalbum.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("categories");
                });

            modelBuilder.Entity("Fotoalbum.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("Data")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("data_bytes");

                    b.HasKey("Id");

                    b.ToTable("images");
                });

            modelBuilder.Entity("Fotoalbum.Models.PhotoEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("int")
                        .HasColumnName("author_id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<int>("ImageId")
                        .HasColumnType("int")
                        .HasColumnName("image_id");

                    b.Property<bool>("IsVisible")
                        .HasColumnType("bit")
                        .HasColumnName("is_visible");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("ImageId");

                    b.ToTable("photos");
                });

            modelBuilder.Entity("CategoryPhotoEntry", b =>
                {
                    b.HasOne("Fotoalbum.Models.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fotoalbum.Models.PhotoEntry", null)
                        .WithMany()
                        .HasForeignKey("PhotoEntriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Fotoalbum.Models.PhotoEntry", b =>
                {
                    b.HasOne("Fotoalbum.Models.Author", "Author")
                        .WithMany("PhotoEntries")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fotoalbum.Models.Image", "Image")
                        .WithMany("PhotoEntries")
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("Fotoalbum.Models.Author", b =>
                {
                    b.Navigation("PhotoEntries");
                });

            modelBuilder.Entity("Fotoalbum.Models.Image", b =>
                {
                    b.Navigation("PhotoEntries");
                });
#pragma warning restore 612, 618
        }
    }
}
