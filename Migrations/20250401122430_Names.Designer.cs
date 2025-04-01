﻿// <auto-generated />
using System;
using E_LearningPlatform.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace E_LearningPlatform.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20250401122430_Names")]
    partial class Names
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("E_LearningPlatform.Models.Answer", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("int")
                        .HasColumnName("StudentID");

                    b.Property<int>("ExamId")
                        .HasColumnType("int")
                        .HasColumnName("ExamID");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int")
                        .HasColumnName("QuestionID");

                    b.Property<string>("StudentAwnser")
                        .IsRequired()
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("char(1)")
                        .IsFixedLength();

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("ID")
                        .HasName("PK_Awnsers");

                    b.HasIndex("QuestionId");

                    b.HasIndex("StudentId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("E_LearningPlatform.Models.Course", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CourseID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.HasKey("ID");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("E_LearningPlatform.Models.Exam", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ExamID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int")
                        .HasColumnName("CourseID");

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<int>("ExamTime")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int")
                        .HasColumnName("TeacherID");

                    b.Property<int>("TotalPoints")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CourseId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("E_LearningPlatform.Models.ExamsQuestion", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<int>("ExamId")
                        .HasColumnType("int")
                        .HasColumnName("ExamID");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int")
                        .HasColumnName("QuestionID");

                    b.Property<decimal>("QuestionPoints")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("ID");

                    b.HasIndex("ExamId");

                    b.HasIndex("QuestionId");

                    b.ToTable("ExamsQuestions");
                });

            modelBuilder.Entity("E_LearningPlatform.Models.Question", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("QuestionID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int")
                        .HasColumnName("CourseID");

                    b.Property<string>("QuestionAnswer")
                        .IsRequired()
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("char(1)")
                        .IsFixedLength();

                    b.Property<string>("QuestionInfo")
                        .IsRequired()
                        .HasMaxLength(700)
                        .IsUnicode(false)
                        .HasColumnType("varchar(700)");

                    b.HasKey("ID");

                    b.HasIndex("CourseId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("E_LearningPlatform.Models.StudentExam", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("ExamId")
                        .HasColumnType("int")
                        .HasColumnName("ExamID");

                    b.Property<int>("StudentId")
                        .HasColumnType("int")
                        .HasColumnName("StudentID");

                    b.Property<DateTime>("TimeToSubmit")
                        .HasColumnType("datetime");

                    b.HasKey("ID")
                        .HasName("PK_StudentCourses");

                    b.HasIndex("ExamId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentExams");
                });

            modelBuilder.Entity("E_LearningPlatform.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("TeacherDegree")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("ID");

                    b.HasIndex(new[] { "Email" }, "UQ_Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("E_LearningPlatform.Models.Answer", b =>
                {
                    b.HasOne("E_LearningPlatform.Models.Exam", "Exam")
                        .WithMany("Answers")
                        .HasForeignKey("ID")
                        .IsRequired()
                        .HasConstraintName("FK_Answers_Exams");

                    b.HasOne("E_LearningPlatform.Models.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .IsRequired()
                        .HasConstraintName("FK_Answers_Questions");

                    b.HasOne("E_LearningPlatform.Models.User", "Student")
                        .WithMany("Answers")
                        .HasForeignKey("StudentId")
                        .IsRequired()
                        .HasConstraintName("FK_Answers_Users");

                    b.Navigation("Exam");

                    b.Navigation("Question");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("E_LearningPlatform.Models.Exam", b =>
                {
                    b.HasOne("E_LearningPlatform.Models.Course", "Course")
                        .WithMany("Exams")
                        .HasForeignKey("CourseId")
                        .IsRequired()
                        .HasConstraintName("FK_Exams_Courses");

                    b.HasOne("E_LearningPlatform.Models.User", "Teacher")
                        .WithMany("Exams")
                        .HasForeignKey("TeacherId")
                        .IsRequired()
                        .HasConstraintName("FK_Exams_Users");

                    b.Navigation("Course");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("E_LearningPlatform.Models.ExamsQuestion", b =>
                {
                    b.HasOne("E_LearningPlatform.Models.Exam", "Exam")
                        .WithMany("ExamsQuestions")
                        .HasForeignKey("ExamId")
                        .IsRequired()
                        .HasConstraintName("FK_ExamsQuestions_Exams");

                    b.HasOne("E_LearningPlatform.Models.Question", "Question")
                        .WithMany("ExamsQuestions")
                        .HasForeignKey("QuestionId")
                        .IsRequired()
                        .HasConstraintName("FK_ExamsQuestions_Questions");

                    b.Navigation("Exam");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("E_LearningPlatform.Models.Question", b =>
                {
                    b.HasOne("E_LearningPlatform.Models.Course", "Course")
                        .WithMany("Questions")
                        .HasForeignKey("CourseId")
                        .IsRequired()
                        .HasConstraintName("FK_Questions_Courses");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("E_LearningPlatform.Models.StudentExam", b =>
                {
                    b.HasOne("E_LearningPlatform.Models.Exam", "Exam")
                        .WithMany("StudentExams")
                        .HasForeignKey("ExamId")
                        .IsRequired()
                        .HasConstraintName("FK_StudentExams_Exams");

                    b.HasOne("E_LearningPlatform.Models.User", "Student")
                        .WithMany("StudentExams")
                        .HasForeignKey("StudentId")
                        .IsRequired()
                        .HasConstraintName("FK_StudentExams_Users");

                    b.Navigation("Exam");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("E_LearningPlatform.Models.Course", b =>
                {
                    b.Navigation("Exams");

                    b.Navigation("Questions");
                });

            modelBuilder.Entity("E_LearningPlatform.Models.Exam", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("ExamsQuestions");

                    b.Navigation("StudentExams");
                });

            modelBuilder.Entity("E_LearningPlatform.Models.Question", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("ExamsQuestions");
                });

            modelBuilder.Entity("E_LearningPlatform.Models.User", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("Exams");

                    b.Navigation("StudentExams");
                });
#pragma warning restore 612, 618
        }
    }
}
