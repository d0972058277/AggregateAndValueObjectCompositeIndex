﻿// <auto-generated />
using System;
using AggregateAndValueObjectCompositeIndex;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AggregateAndValueObjectCompositeIndex.Migrations
{
    [DbContext(typeof(ExampleDbContext))]
    [Migration("20221004055416_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AggregateAndValueObjectCompositeIndex.DomainModels.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("varchar(16)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("varchar(16)");

                    b.HasKey("Id");

                    b.ToTable("Account", (string)null);
                });

            modelBuilder.Entity("AggregateAndValueObjectCompositeIndex.DomainModels.Account", b =>
                {
                    b.OwnsOne("AggregateAndValueObjectCompositeIndex.DomainModels.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("AccountId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(16)
                                .HasColumnType("varchar(16)")
                                .HasColumnName("Email");

                            b1.HasKey("AccountId");

                            b1.ToTable("Account");

                            b1.WithOwner()
                                .HasForeignKey("AccountId");
                        });

                    b.Navigation("Email")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}