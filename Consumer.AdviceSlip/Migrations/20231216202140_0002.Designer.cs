﻿// <auto-generated />
using Consumer.AdviceSlip.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Consumer.AdviceSlip.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231216202140_0002")]
    partial class _0002
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Consumer.AdviceSlip.Models.Slip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Advice")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AdviceSlipId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Slip");
                });
#pragma warning restore 612, 618
        }
    }
}
