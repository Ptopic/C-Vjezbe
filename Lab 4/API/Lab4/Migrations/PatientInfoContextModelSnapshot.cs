﻿// <auto-generated />
using System;
using Lab4.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Lab4.Migrations
{
    [DbContext(typeof(PatientInfoContext))]
    partial class PatientInfoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Lab4.Entities.Diagnosis", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("Diagnoses");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2f5541d0-e32e-4d85-a5ae-37ca9baf7d24"),
                            Description = "Neoplazme",
                            Title = "C00-D48"
                        },
                        new
                        {
                            Id = new Guid("8a3bc909-ffda-47af-8817-2ee9d80baee2"),
                            Description = "Bolesti krvi i krvotvornih organa i određeni poremećaji imunološkog sustava",
                            Title = "C50-D89"
                        },
                        new
                        {
                            Id = new Guid("576fd12d-6eda-44ae-8445-9bd7f5804981"),
                            Description = "Endokrine, nutricijske i metaboličke bolesti",
                            Title = "E00-E90"
                        },
                        new
                        {
                            Id = new Guid("84aff43b-017c-421e-846b-9b55ba1dc61d"),
                            Description = "Mentalni poremećaji i poremećaji ponašanja",
                            Title = "F00-F99"
                        },
                        new
                        {
                            Id = new Guid("c4164c91-408f-4f2c-9963-0f17f915fb32"),
                            Description = "Bolesti živčanog sustava",
                            Title = "G00-G99"
                        },
                        new
                        {
                            Id = new Guid("8abf961e-67e5-4c66-82cd-804e521f7e68"),
                            Description = "Bolesti oka i adneksa",
                            Title = "H00-H59"
                        });
                });

            modelBuilder.Entity("Lab4.Entities.Patient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DateOfAdmittance")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateOfDischarge")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("DiagnosisId")
                        .HasColumnType("uuid");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<bool>("IsDischarged")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<int>("PatientGender")
                        .HasColumnType("integer");

                    b.Property<int>("PatientInsurance")
                        .HasColumnType("integer");

                    b.Property<string>("PatientMbo")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("character varying(9)");

                    b.Property<string>("PatientOib")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("character varying(11)");

                    b.HasKey("Id");

                    b.HasIndex("DiagnosisId");

                    b.ToTable("Patients");

                    b.HasData(
                        new
                        {
                            Id = new Guid("cc3835ad-5937-4426-b8e3-8a1d0a27a495"),
                            DateOfAdmittance = new DateTime(2024, 4, 19, 22, 0, 0, 0, DateTimeKind.Utc),
                            DateOfBirth = new DateTime(2002, 10, 14, 22, 0, 0, 0, DateTimeKind.Utc),
                            DateOfDischarge = new DateTime(2024, 4, 24, 22, 0, 0, 0, DateTimeKind.Utc),
                            DiagnosisId = new Guid("8abf961e-67e5-4c66-82cd-804e521f7e68"),
                            FirstName = "Petar",
                            IsDischarged = true,
                            LastName = "Topić",
                            PatientGender = 0,
                            PatientInsurance = 1,
                            PatientMbo = "111111111",
                            PatientOib = "11111111111"
                        },
                        new
                        {
                            Id = new Guid("cc066571-162b-4c8b-b912-9394e7639c43"),
                            DateOfAdmittance = new DateTime(2024, 4, 14, 22, 0, 0, 0, DateTimeKind.Utc),
                            DateOfBirth = new DateTime(1999, 12, 31, 23, 0, 0, 0, DateTimeKind.Utc),
                            DateOfDischarge = new DateTime(2024, 4, 18, 22, 0, 0, 0, DateTimeKind.Utc),
                            DiagnosisId = new Guid("84aff43b-017c-421e-846b-9b55ba1dc61d"),
                            FirstName = "Ivo",
                            IsDischarged = true,
                            LastName = "Ivic",
                            PatientGender = 0,
                            PatientInsurance = 0,
                            PatientMbo = "222222222",
                            PatientOib = "22222222222"
                        });
                });

            modelBuilder.Entity("Lab4.Entities.Patient", b =>
                {
                    b.HasOne("Lab4.Entities.Diagnosis", "Diagnosis")
                        .WithMany("Patients")
                        .HasForeignKey("DiagnosisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Diagnosis");
                });

            modelBuilder.Entity("Lab4.Entities.Diagnosis", b =>
                {
                    b.Navigation("Patients");
                });
#pragma warning restore 612, 618
        }
    }
}
