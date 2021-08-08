﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Snippet.Data.DbContext;

namespace SnippetProject.Migrations
{
    [DbContext(typeof(SnippetDbContext))]
    [Migration("20210808095309_ResizedSnippet")]
    partial class ResizedSnippet
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Snippet.Data.Entities.LanguageEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExtraName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("Snippet.Data.Entities.SnippetEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<long>("LanguageId")
                        .HasColumnType("bigint");

                    b.Property<string>("Snippet")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(140)
                        .HasColumnType("nvarchar(140)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.HasIndex("UserId");

                    b.ToTable("SnippetPosts");
                });

            modelBuilder.Entity("Snippet.Data.Entities.TagEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Snippet.Data.Entities.UserEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SnippetEntityTagEntity", b =>
                {
                    b.Property<long>("SnippetPostsId")
                        .HasColumnType("bigint");

                    b.Property<long>("TagsId")
                        .HasColumnType("bigint");

                    b.HasKey("SnippetPostsId", "TagsId");

                    b.HasIndex("TagsId");

                    b.ToTable("SnippetEntityTagEntity");
                });

            modelBuilder.Entity("SnippetEntityUserEntity", b =>
                {
                    b.Property<long>("LikedPostsId")
                        .HasColumnType("bigint");

                    b.Property<long>("LikedUserId")
                        .HasColumnType("bigint");

                    b.HasKey("LikedPostsId", "LikedUserId");

                    b.HasIndex("LikedUserId");

                    b.ToTable("SnippetEntityUserEntity");
                });

            modelBuilder.Entity("Snippet.Data.Entities.SnippetEntity", b =>
                {
                    b.HasOne("Snippet.Data.Entities.LanguageEntity", "Language")
                        .WithMany("SnippetPosts")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Snippet.Data.Entities.UserEntity", "User")
                        .WithMany("OwnSnippet")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Language");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SnippetEntityTagEntity", b =>
                {
                    b.HasOne("Snippet.Data.Entities.SnippetEntity", null)
                        .WithMany()
                        .HasForeignKey("SnippetPostsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Snippet.Data.Entities.TagEntity", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SnippetEntityUserEntity", b =>
                {
                    b.HasOne("Snippet.Data.Entities.SnippetEntity", null)
                        .WithMany()
                        .HasForeignKey("LikedPostsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Snippet.Data.Entities.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("LikedUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Snippet.Data.Entities.LanguageEntity", b =>
                {
                    b.Navigation("SnippetPosts");
                });

            modelBuilder.Entity("Snippet.Data.Entities.UserEntity", b =>
                {
                    b.Navigation("OwnSnippet");
                });
#pragma warning restore 612, 618
        }
    }
}
