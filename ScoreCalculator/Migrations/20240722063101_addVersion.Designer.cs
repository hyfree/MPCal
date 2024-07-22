﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ScoreCalculator.DataBase;

#nullable disable

namespace ScoreCalculator.Migrations
{
    [DbContext(typeof(SQLLite3Context))]
    [Migration("20240722063101_addVersion")]
    partial class addVersion
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("ScoreCalculator.Models.Entity.KnowledgeEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Feature")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("SecurityDimensionEnum")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Tag")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TestStatus")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ZhiBiao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("KnowledgeEntity");
                });

            modelBuilder.Entity("ScoreCalculator.Models.Entity.RecordEntryEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("A")
                        .HasColumnType("INTEGER");

                    b.Property<double?>("CePingDanYuanDeFen")
                        .HasColumnType("REAL");

                    b.Property<bool>("D")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<bool?>("EnabledAutomatic")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Exposures")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Feature")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Index")
                        .HasColumnType("TEXT");

                    b.Property<bool>("K")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("NK")
                        .HasColumnType("INTEGER");

                    b.Property<long>("ProjectId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Question")
                        .HasColumnType("TEXT");

                    b.Property<int>("RA")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RK")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Remark")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Score")
                        .HasColumnType("REAL");

                    b.Property<int>("SecurityDimension")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Suggest")
                        .HasColumnType("TEXT");

                    b.Property<string>("TestObjectName")
                        .HasColumnType("TEXT");

                    b.Property<int>("TestStatus")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double?>("ZheHeFenShu")
                        .HasColumnType("REAL");

                    b.Property<string>("ZhiBiao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("ZhiBiaoQuanZhong")
                        .HasColumnType("REAL");

                    b.Property<string>("ZhiBiaoYaoqQiu")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("RecordEntryEntity");
                });

            modelBuilder.Entity("ScoreCalculator.Models.Entity.SystemInfoEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("CompanyId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Level")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Provinces")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Score")
                        .HasColumnType("REAL");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("SystemInfoEntity");
                });
#pragma warning restore 612, 618
        }
    }
}
