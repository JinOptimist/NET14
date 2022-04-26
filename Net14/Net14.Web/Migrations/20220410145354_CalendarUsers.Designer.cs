﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Net14.Web.EfStuff;

namespace Net14.Web.Migrations
{
    [DbContext(typeof(WebContext))]
    [Migration("20220410145354_CalendarUsers")]
    partial class CalendarUsers
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Net14.Web.EfStuff.DbModel.CalendarUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CalendarUsers");
                });

            modelBuilder.Entity("Net14.Web.EfStuff.DbModel.DaysNote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CalendarUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EventDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CalendarUserId");

                    b.ToTable("DaysNotes");
                });

            modelBuilder.Entity("Net14.Web.EfStuff.DbModel.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rate")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("Net14.Web.EfStuff.DbModel.ImageComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ImageId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.ToTable("ImageComments");
                });

            modelBuilder.Entity("Net14.Web.EfStuff.DbModel.SocialDbModels.FileSocial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("fileSocial");
                });

            modelBuilder.Entity("Net14.Web.EfStuff.DbModel.SocialDbModels.PostSocial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CommentOfUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfPosting")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Likes")
                        .HasColumnType("int");

                    b.Property<string>("TypePost")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Net14.Web.EfStuff.DbModel.SocialDbModels.SocialComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfPosting")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PostId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("SocialComments");
                });

            modelBuilder.Entity("Net14.Web.EfStuff.DbModel.SocialDbModels.UserSocial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserPhoto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("/images/Social/CalendarUser.jpg");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Net14.Web.EfStuff.DbModel.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Net14.Web.EfStuff.DbModel.DaysNote", b =>
                {
                    b.HasOne("Net14.Web.EfStuff.DbModel.CalendarUser", "CalendarUser")
                        .WithMany("DaysNotes")
                        .HasForeignKey("CalendarUserId");

                    b.Navigation("CalendarUser");
                });

            modelBuilder.Entity("Net14.Web.EfStuff.DbModel.ImageComment", b =>
                {
                    b.HasOne("Net14.Web.EfStuff.DbModel.Image", "Image")
                        .WithMany("Comments")
                        .HasForeignKey("ImageId");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("Net14.Web.EfStuff.DbModel.SocialDbModels.PostSocial", b =>
                {
                    b.HasOne("Net14.Web.EfStuff.DbModel.SocialDbModels.UserSocial", "CalendarUser")
                        .WithMany("Posts")
                        .HasForeignKey("UserId");

                    b.Navigation("CalendarUser");
                });

            modelBuilder.Entity("Net14.Web.EfStuff.DbModel.SocialDbModels.SocialComment", b =>
                {
                    b.HasOne("Net14.Web.EfStuff.DbModel.SocialDbModels.PostSocial", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId");

                    b.HasOne("Net14.Web.EfStuff.DbModel.SocialDbModels.UserSocial", "CalendarUser")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Post");

                    b.Navigation("CalendarUser");
                });

            modelBuilder.Entity("Net14.Web.EfStuff.DbModel.CalendarUser", b =>
                {
                    b.Navigation("DaysNotes");
                });

            modelBuilder.Entity("Net14.Web.EfStuff.DbModel.Image", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("Net14.Web.EfStuff.DbModel.SocialDbModels.PostSocial", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("Net14.Web.EfStuff.DbModel.SocialDbModels.UserSocial", b =>
                {
                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
