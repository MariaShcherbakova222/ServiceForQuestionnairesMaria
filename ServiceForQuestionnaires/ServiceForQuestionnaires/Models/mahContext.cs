using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ServiceForQuestionnaires.Models
{
    public partial class mahContext : DbContext
    {
        public mahContext()
        {
        }

        public mahContext(DbContextOptions<mahContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Answer> Answers { get; set; } = null!;
        public virtual DbSet<Interview> Interviews { get; set; } = null!;
        public virtual DbSet<Question> Questions { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>(entity =>
            {
                entity.ToTable("Answer");

                entity.Property(e => e.AnswerId).ValueGeneratedNever();

                entity.Property(e => e.Deleted)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DeletedByUserId).HasColumnName("DeletedByUserID");

                entity.Property(e => e.QuestionId).HasColumnName("QuestionID");

                entity.Property(e => e.Texxt)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.AnswerNavigation)
                    .WithOne(p => p.Answer)
                    .HasForeignKey<Answer>(d => d.AnswerId)
                    .HasConstraintName("FK__Answer__AnswerId__3F466844");
            });

            modelBuilder.Entity<Interview>(entity =>
            {
                entity.ToTable("Interview");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AnswerId).HasColumnName("AnswerID");

                entity.Property(e => e.Deleted)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DeletedByUserId).HasColumnName("DeletedByUserID");

                entity.Property(e => e.InterviewName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.QuestionId).HasColumnName("QuestionID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Interview)
                    .HasForeignKey<Interview>(d => d.Id)
                    .HasConstraintName("FK__Interview__Id__398D8EEE");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.ToTable("Question");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Deleted)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DeletedByUserId).HasColumnName("DeletedByUserID");

                entity.Property(e => e.Requiired)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Texxt)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Interview)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.InterviewId)
                    .HasConstraintName("FK__Question__Interv__3C69FB99");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User_");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Namee)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
