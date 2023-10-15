﻿// <auto-generated />
using System;
using System.Collections.Generic;
using IbgeApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IbgeApi.Migrations
{
    [DbContext(typeof(IbgeDbContext))]
    [Migration("20231015123843_v1")]
    partial class v1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0-rc.2.23480.1");

            modelBuilder.Entity("IbgeApi.Models.UserModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.ComplexProperty<Dictionary<string, object>>("Email", "IbgeApi.Models.UserModel.Email#Email", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("EmailAddress")
                                .IsRequired()
                                .HasMaxLength(80)
                                .HasColumnType("nvarchar");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("Name", "IbgeApi.Models.UserModel.Name#Name", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasMaxLength(80)
                                .HasColumnType("nvarchar");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("PasswordHash", "IbgeApi.Models.UserModel.PasswordHash#PasswordHash", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Hash")
                                .IsRequired()
                                .HasMaxLength(80)
                                .HasColumnType("nvarchar");
                        });

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
