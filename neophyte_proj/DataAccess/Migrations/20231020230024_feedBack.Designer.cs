﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using neophyte_proj.DataAccess.Context;

#nullable disable

namespace neophyte_proj.DataAccess.Migrations
{
    [DbContext(typeof(NeophyteApplicationContext))]
    [Migration("20231020230024_feedBack")]
    partial class feedBack
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DataAccess.Models.IntermediateModels.BageStudent", b =>
                {
                    b.Property<int>("BageId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("CourseBageId")
                        .HasColumnType("int");

                    b.HasKey("BageId", "StudentId");

                    b.HasIndex("CourseBageId");

                    b.HasIndex("StudentId");

                    b.ToTable("BageStudent");
                });

            modelBuilder.Entity("neophyte_proj.DataAccess.Models.CourseModel.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CourseFinancialInfoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("neophyte_proj.DataAccess.Models.CourseModel.CourseBage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("CourseBags");
                });

            modelBuilder.Entity("neophyte_proj.DataAccess.Models.CourseModel.CourseFeedBack", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("Tittle")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("CourseFeedBacks");
                });

            modelBuilder.Entity("neophyte_proj.DataAccess.Models.CourseModel.CourseFinancialInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId")
                        .IsUnique();

                    b.ToTable("CourseFinancialInfos");
                });

            modelBuilder.Entity("neophyte_proj.DataAccess.Models.IntermediateModels.CourseStudent", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("CourseId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("CourseStudent");
                });

            modelBuilder.Entity("neophyte_proj.DataAccess.Models.IntermediateModels.CourseTeacher", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("CourseId", "TeacherId");

                    b.HasIndex("TeacherId");

                    b.ToTable("CourseTeacher");
                });

            modelBuilder.Entity("neophyte_proj.DataAccess.Models.StudentModel.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("StudentAccountInfoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("neophyte_proj.DataAccess.Models.StudentModel.StudentAccountInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("StudentId")
                        .IsUnique();

                    b.ToTable("StudentAccountInfos");
                });

            modelBuilder.Entity("neophyte_proj.DataAccess.Models.TeacherModel.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("TeacherAccountInfoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("neophyte_proj.DataAccess.Models.TeacherModel.TeacherAccountInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId")
                        .IsUnique();

                    b.ToTable("TeacherAccountInfos");
                });

            modelBuilder.Entity("neophyte_proj.DataAccess.Models.TeacherModel.TeacherFeedBack", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("Tittle")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("TeacherId");

                    b.ToTable("TeacherFeedBacks");
                });

            modelBuilder.Entity("DataAccess.Models.IntermediateModels.BageStudent", b =>
                {
                    b.HasOne("neophyte_proj.DataAccess.Models.CourseModel.CourseBage", "CourseBage")
                        .WithMany("BageStudent")
                        .HasForeignKey("CourseBageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("neophyte_proj.DataAccess.Models.StudentModel.Student", "Student")
                        .WithMany("BageStudent")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CourseBage");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("neophyte_proj.DataAccess.Models.CourseModel.Course", b =>
                {
                    b.OwnsOne("neophyte_proj.DataAccess.Models.CourseModel.CourseGeneralInfo", "CourseGeneralInfo", b1 =>
                        {
                            b1.Property<int>("CourseId")
                                .HasColumnType("int");

                            b1.Property<string>("Description")
                                .IsRequired()
                                .HasMaxLength(1000)
                                .HasColumnType("varchar(1000)");

                            b1.Property<int>("LessonsCount")
                                .HasColumnType("int");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(20)
                                .HasColumnType("varchar(20)");

                            b1.Property<int>("PlacesNumber")
                                .HasColumnType("int");

                            b1.Property<int>("Rate")
                                .HasColumnType("int");

                            b1.HasKey("CourseId");

                            b1.ToTable("Courses");

                            b1.WithOwner()
                                .HasForeignKey("CourseId");
                        });

                    b.Navigation("CourseGeneralInfo")
                        .IsRequired();
                });

            modelBuilder.Entity("neophyte_proj.DataAccess.Models.CourseModel.CourseBage", b =>
                {
                    b.HasOne("neophyte_proj.DataAccess.Models.CourseModel.Course", "Course")
                        .WithMany("CourseBages")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("neophyte_proj.DataAccess.Models.CourseModel.CourseFeedBack", b =>
                {
                    b.HasOne("neophyte_proj.DataAccess.Models.CourseModel.Course", "Course")
                        .WithMany("CourseFeedBacks")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("neophyte_proj.DataAccess.Models.StudentModel.Student", "Student")
                        .WithMany("CourseFeedBack")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("neophyte_proj.DataAccess.Models.CourseModel.CourseFinancialInfo", b =>
                {
                    b.HasOne("neophyte_proj.DataAccess.Models.CourseModel.Course", "Course")
                        .WithOne("CourseFinancialInfo")
                        .HasForeignKey("neophyte_proj.DataAccess.Models.CourseModel.CourseFinancialInfo", "CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("neophyte_proj.DataAccess.Models.IntermediateModels.CourseStudent", b =>
                {
                    b.HasOne("neophyte_proj.DataAccess.Models.CourseModel.Course", "Course")
                        .WithMany("CourseStudent")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("neophyte_proj.DataAccess.Models.StudentModel.Student", "Student")
                        .WithMany("CourseStudent")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("neophyte_proj.DataAccess.Models.IntermediateModels.CourseTeacher", b =>
                {
                    b.HasOne("neophyte_proj.DataAccess.Models.CourseModel.Course", "Course")
                        .WithMany("CourseTeacher")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("neophyte_proj.DataAccess.Models.TeacherModel.Teacher", "Teacher")
                        .WithMany("CourseTeacher")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("neophyte_proj.DataAccess.Models.StudentModel.Student", b =>
                {
                    b.OwnsOne("neophyte_proj.DataAccess.Models.StudentModel.StudentGeneralInfo", "StudentGeneralInfo", b1 =>
                        {
                            b1.Property<int>("StudentId")
                                .HasColumnType("int");

                            b1.Property<string>("AboutMe")
                                .IsRequired()
                                .HasMaxLength(1000)
                                .HasColumnType("varchar(1000)");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasMaxLength(20)
                                .HasColumnType("varchar(20)");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasMaxLength(20)
                                .HasColumnType("varchar(20)");

                            b1.Property<string>("MiddleName")
                                .IsRequired()
                                .HasMaxLength(20)
                                .HasColumnType("varchar(20)");

                            b1.HasKey("StudentId");

                            b1.ToTable("Students");

                            b1.WithOwner()
                                .HasForeignKey("StudentId");
                        });

                    b.Navigation("StudentGeneralInfo")
                        .IsRequired();
                });

            modelBuilder.Entity("neophyte_proj.DataAccess.Models.StudentModel.StudentAccountInfo", b =>
                {
                    b.HasOne("neophyte_proj.DataAccess.Models.StudentModel.Student", "Student")
                        .WithOne("StudentAccountInfo")
                        .HasForeignKey("neophyte_proj.DataAccess.Models.StudentModel.StudentAccountInfo", "StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("neophyte_proj.DataAccess.Models.TeacherModel.Teacher", b =>
                {
                    b.OwnsOne("neophyte_proj.DataAccess.Models.TeacherModel.TeacherGeneralInfo", "TeacherGeneralInfo", b1 =>
                        {
                            b1.Property<int>("TeacherId")
                                .HasColumnType("int");

                            b1.Property<string>("AboutMe")
                                .IsRequired()
                                .HasMaxLength(1000)
                                .HasColumnType("varchar(1000)");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasMaxLength(20)
                                .HasColumnType("varchar(20)");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasMaxLength(20)
                                .HasColumnType("varchar(20)");

                            b1.Property<string>("MiddleName")
                                .IsRequired()
                                .HasMaxLength(20)
                                .HasColumnType("varchar(20)");

                            b1.Property<int>("Rate")
                                .HasColumnType("int");

                            b1.HasKey("TeacherId");

                            b1.ToTable("Teachers");

                            b1.WithOwner()
                                .HasForeignKey("TeacherId");
                        });

                    b.Navigation("TeacherGeneralInfo")
                        .IsRequired();
                });

            modelBuilder.Entity("neophyte_proj.DataAccess.Models.TeacherModel.TeacherAccountInfo", b =>
                {
                    b.HasOne("neophyte_proj.DataAccess.Models.TeacherModel.Teacher", "Teacher")
                        .WithOne("TeacherAccountInfo")
                        .HasForeignKey("neophyte_proj.DataAccess.Models.TeacherModel.TeacherAccountInfo", "TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("neophyte_proj.DataAccess.Models.TeacherModel.TeacherFeedBack", b =>
                {
                    b.HasOne("neophyte_proj.DataAccess.Models.StudentModel.Student", "Student")
                        .WithMany("TeacherFeedBack")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("neophyte_proj.DataAccess.Models.TeacherModel.Teacher", "Teacher")
                        .WithMany("TeacherFeedBacks")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("neophyte_proj.DataAccess.Models.CourseModel.Course", b =>
                {
                    b.Navigation("CourseBages");

                    b.Navigation("CourseFeedBacks");

                    b.Navigation("CourseFinancialInfo")
                        .IsRequired();

                    b.Navigation("CourseStudent");

                    b.Navigation("CourseTeacher");
                });

            modelBuilder.Entity("neophyte_proj.DataAccess.Models.CourseModel.CourseBage", b =>
                {
                    b.Navigation("BageStudent");
                });

            modelBuilder.Entity("neophyte_proj.DataAccess.Models.StudentModel.Student", b =>
                {
                    b.Navigation("BageStudent");

                    b.Navigation("CourseFeedBack");

                    b.Navigation("CourseStudent");

                    b.Navigation("StudentAccountInfo")
                        .IsRequired();

                    b.Navigation("TeacherFeedBack");
                });

            modelBuilder.Entity("neophyte_proj.DataAccess.Models.TeacherModel.Teacher", b =>
                {
                    b.Navigation("CourseTeacher");

                    b.Navigation("TeacherAccountInfo")
                        .IsRequired();

                    b.Navigation("TeacherFeedBacks");
                });
#pragma warning restore 612, 618
        }
    }
}
