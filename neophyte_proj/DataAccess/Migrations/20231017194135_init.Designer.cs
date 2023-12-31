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
    [Migration("20231017194135_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("neophyte_proj.Models.CourseModel.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CourseFinancialInfoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("neophyte_proj.Models.CourseModel.CourseBage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("CourseBags");
                });

            modelBuilder.Entity("neophyte_proj.Models.CourseModel.CourseFeedBack", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<bool>("IsAuthorStudent")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Tittle")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("CourseFeedBacks");
                });

            modelBuilder.Entity("neophyte_proj.Models.CourseModel.CourseFinancialInfo", b =>
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

            modelBuilder.Entity("neophyte_proj.Models.IntermediateModels.CourseStudent", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("CourseId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("CourseStudent");
                });

            modelBuilder.Entity("neophyte_proj.Models.IntermediateModels.CourseTeacher", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("CourseId", "TeacherId");

                    b.HasIndex("TeacherId");

                    b.ToTable("CourseTeacher");
                });

            modelBuilder.Entity("neophyte_proj.Models.StudentModel.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("StudentAccountInfoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("neophyte_proj.Models.StudentModel.StudentAccountInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("StudentId")
                        .IsUnique();

                    b.ToTable("StudentAccountInfos");
                });

            modelBuilder.Entity("neophyte_proj.Models.TeacherModel.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("TeacherAccountInfoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("neophyte_proj.Models.TeacherModel.TeacherAccountInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId")
                        .IsUnique();

                    b.ToTable("TeacherAccountInfos");
                });

            modelBuilder.Entity("neophyte_proj.Models.TeacherModel.TeacherFeedBack", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Tittle")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("TeacherFeedBacks");
                });

            modelBuilder.Entity("neophyte_proj.Models.CourseModel.Course", b =>
                {
                    b.OwnsOne("neophyte_proj.Models.CourseModel.CourseGeneralInfo", "CourseGeneralInfo", b1 =>
                        {
                            b1.Property<int>("CourseId")
                                .HasColumnType("int");

                            b1.Property<string>("Description")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<int>("LessonsCount")
                                .HasColumnType("int");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("longtext");

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

            modelBuilder.Entity("neophyte_proj.Models.CourseModel.CourseBage", b =>
                {
                    b.HasOne("neophyte_proj.Models.CourseModel.Course", "Course")
                        .WithMany("CourseBages")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("neophyte_proj.Models.StudentModel.Student", "Student")
                        .WithMany("CourseBages")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("neophyte_proj.Models.CourseModel.CourseFeedBack", b =>
                {
                    b.HasOne("neophyte_proj.Models.CourseModel.Course", "Course")
                        .WithMany("CourseFeedBacks")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("neophyte_proj.Models.CourseModel.CourseFinancialInfo", b =>
                {
                    b.HasOne("neophyte_proj.Models.CourseModel.Course", "Course")
                        .WithOne("CourseFinancialInfo")
                        .HasForeignKey("neophyte_proj.Models.CourseModel.CourseFinancialInfo", "CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("neophyte_proj.Models.IntermediateModels.CourseStudent", b =>
                {
                    b.HasOne("neophyte_proj.Models.CourseModel.Course", "Course")
                        .WithMany("CourseStudent")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("neophyte_proj.Models.StudentModel.Student", "Student")
                        .WithMany("CourseStudent")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("neophyte_proj.Models.IntermediateModels.CourseTeacher", b =>
                {
                    b.HasOne("neophyte_proj.Models.CourseModel.Course", "Course")
                        .WithMany("CourseTeacher")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("neophyte_proj.Models.TeacherModel.Teacher", "Teacher")
                        .WithMany("CourseTeacher")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("neophyte_proj.Models.StudentModel.Student", b =>
                {
                    b.OwnsOne("neophyte_proj.Models.StudentModel.StudentGeneralInfo", "StudentGeneralInfo", b1 =>
                        {
                            b1.Property<int>("StudentId")
                                .HasColumnType("int");

                            b1.Property<string>("AboutMe")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<string>("MiddleName")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.HasKey("StudentId");

                            b1.ToTable("Students");

                            b1.WithOwner()
                                .HasForeignKey("StudentId");
                        });

                    b.Navigation("StudentGeneralInfo")
                        .IsRequired();
                });

            modelBuilder.Entity("neophyte_proj.Models.StudentModel.StudentAccountInfo", b =>
                {
                    b.HasOne("neophyte_proj.Models.StudentModel.Student", "Student")
                        .WithOne("StudentAccountInfo")
                        .HasForeignKey("neophyte_proj.Models.StudentModel.StudentAccountInfo", "StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("neophyte_proj.Models.TeacherModel.Teacher", b =>
                {
                    b.OwnsOne("neophyte_proj.Models.TeacherModel.TeacherGeneralInfo", "TeacherGeneralInfo", b1 =>
                        {
                            b1.Property<int>("TeacherId")
                                .HasColumnType("int");

                            b1.Property<string>("AboutMe")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<string>("MiddleName")
                                .IsRequired()
                                .HasColumnType("longtext");

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

            modelBuilder.Entity("neophyte_proj.Models.TeacherModel.TeacherAccountInfo", b =>
                {
                    b.HasOne("neophyte_proj.Models.TeacherModel.Teacher", "Teacher")
                        .WithOne("TeacherAccountInfo")
                        .HasForeignKey("neophyte_proj.Models.TeacherModel.TeacherAccountInfo", "TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("neophyte_proj.Models.TeacherModel.TeacherFeedBack", b =>
                {
                    b.HasOne("neophyte_proj.Models.TeacherModel.Teacher", "Teacher")
                        .WithMany("TeacherFeedBacks")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("neophyte_proj.Models.CourseModel.Course", b =>
                {
                    b.Navigation("CourseBages");

                    b.Navigation("CourseFeedBacks");

                    b.Navigation("CourseFinancialInfo")
                        .IsRequired();

                    b.Navigation("CourseStudent");

                    b.Navigation("CourseTeacher");
                });

            modelBuilder.Entity("neophyte_proj.Models.StudentModel.Student", b =>
                {
                    b.Navigation("CourseBages");

                    b.Navigation("CourseStudent");

                    b.Navigation("StudentAccountInfo")
                        .IsRequired();
                });

            modelBuilder.Entity("neophyte_proj.Models.TeacherModel.Teacher", b =>
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
