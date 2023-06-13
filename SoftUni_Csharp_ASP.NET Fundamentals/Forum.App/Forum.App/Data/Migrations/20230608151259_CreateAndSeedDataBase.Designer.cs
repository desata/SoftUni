﻿// <auto-generated />
using Forum.App.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Forum.App.Data.Migrations
{
    [DbContext(typeof(ForumAppDbContext))]
    [Migration("20230608151259_CreateAndSeedDataBase")]
    partial class CreateAndSeedDataBase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Forum.App.Data.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(1500)
                        .HasColumnType("nvarchar(1500)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam posuere massa mi, eu pulvinar est dapibus eleifend. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Nunc tempor sagittis tempus. Aenean sem nibh, tempor sed tortor et, aliquet tincidunt justo. Aenean non nunc eu leo finibus malesuada. Ut eleifend gravida lacus, a egestas turpis consectetur eget. Praesent pretium pulvinar tempor. Aenean at dictum erat. In nisi augue, consequat quis venenatis a, auctor eget sapien. Sed sed orci quis erat eleifend auctor nec sed nulla. Sed aliquam imperdiet tellus, at ultrices nisi viverra vel. Nulla aliquam imperdiet ante et semper.",
                            Title = "My first post"
                        },
                        new
                        {
                            Id = 2,
                            Content = "Donec egestas nunc quis risus scelerisque luctus. Mauris vitae mattis sem, sed sodales orci. Nullam feugiat justo at malesuada suscipit. Nulla facilisi. Proin faucibus dapibus elit, eget fermentum nibh blandit non. Quisque vel tortor vel erat tincidunt laoreet lobortis a est. Etiam bibendum est at semper tempus. Pellentesque suscipit sed dolor ut faucibus.",
                            Title = "My second post"
                        },
                        new
                        {
                            Id = 3,
                            Content = "Nullam feugiat justo at malesuada suscipit. Nulla facilisi. Proin faucibus dapibus elit, eget fermentum nibh blandit non. Quisque vel tortor vel erat tincidunt laoreet lobortis a est. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla at bibendum dui, non laoreet lectus. Morbi ut laoreet ex. Cras. ",
                            Title = "My third post"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
