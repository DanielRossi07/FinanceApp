﻿// <auto-generated />
using System;
using Finance.Infra.Data.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Finance.Infra.Data.EF.Migrations
{
    [DbContext(typeof(FinanceDbContext))]
    [Migration("20250120020625_AlterTransactionSourceType")]
    partial class AlterTransactionSourceType
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.36")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Finance.Domain.Entity.BankAccount", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("BankAccount", (string)null);
                });

            modelBuilder.Entity("Finance.Domain.Entity.TransactionCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("TransactionCategory", (string)null);
                });

            modelBuilder.Entity("Finance.Domain.SeedWork.TransactionSource", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("BankAccountId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("BankAccountId");

                    b.ToTable("TransactionSource", (string)null);

                    b.HasDiscriminator<string>("Type");
                });

            modelBuilder.Entity("Finance.Domain.Entity.Billet", b =>
                {
                    b.HasBaseType("Finance.Domain.SeedWork.TransactionSource");

                    b.HasDiscriminator().HasValue("Billet");
                });

            modelBuilder.Entity("Finance.Domain.Entity.Card", b =>
                {
                    b.HasBaseType("Finance.Domain.SeedWork.TransactionSource");

                    b.HasDiscriminator().HasValue("Card");
                });

            modelBuilder.Entity("Finance.Domain.Entity.Default", b =>
                {
                    b.HasBaseType("Finance.Domain.SeedWork.TransactionSource");

                    b.HasDiscriminator().HasValue("Default");
                });

            modelBuilder.Entity("Finance.Domain.Entity.Pix", b =>
                {
                    b.HasBaseType("Finance.Domain.SeedWork.TransactionSource");

                    b.HasDiscriminator().HasValue("Pix");
                });

            modelBuilder.Entity("Finance.Domain.Entity.Transfer", b =>
                {
                    b.HasBaseType("Finance.Domain.SeedWork.TransactionSource");

                    b.HasDiscriminator().HasValue("Transfer");
                });

            modelBuilder.Entity("Finance.Domain.SeedWork.TransactionSource", b =>
                {
                    b.HasOne("Finance.Domain.Entity.BankAccount", "BankAccount")
                        .WithMany()
                        .HasForeignKey("BankAccountId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("BankAccount");
                });
#pragma warning restore 612, 618
        }
    }
}
