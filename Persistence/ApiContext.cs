using System;
using Application.DTOs;
using Application.QTO;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class ApiContext : DbContext
    {
        private DbContextOptions<ApiContext> _options;

        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
            _options = options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
	        modelBuilder.Entity<Comment>()
		        .HasIndex(e => new { e.TableId, e.TableType })
		        .IsClustered(false);
	       
	        modelBuilder.Entity<RateScore>()
		        .HasIndex(e => new { e.TableId, e.TableType })
		        .IsClustered(false);

	        modelBuilder.Entity<LikeView>()
		        .HasIndex(e =>new{ e.TableId , e.TableType})
		        .IsClustered(false);
	      
	        modelBuilder.Entity<Learning>()
		        .HasIndex(e => e.ProjectId)
		        .IsClustered(false);

	        modelBuilder.Entity<Exam>()
		        .HasIndex(e => e.ProjectId)
		        .IsClustered(false);

            modelBuilder.Entity<LearningQto>().HasNoKey();
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            UpdateSoftDeleteStatuses();
            return base.SaveChanges();
        }

        private void UpdateSoftDeleteStatuses()
        {
            foreach (var entry in ChangeTracker.Entries())
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.CurrentValues["Deleted"] = false;
                        entry.CurrentValues["CreateDate"] = DateTime.Now;
                        entry.CurrentValues["ModifyDate"] = DateTime.Now;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.CurrentValues["ModifyDate"] = DateTime.Now;
                        entry.CurrentValues["Deleted"] = true;
                        break;
                    case EntityState.Modified:
                        entry.State = EntityState.Modified;
                        entry.CurrentValues["ModifyDate"] = DateTime.Now;
                        break;
                }
        }
	
	
	
	
	//----------------------
	public virtual DbSet<Comment> Comments { get; set; }
	public virtual DbSet<Country> Countries { get; set; }
	public virtual DbSet<Exam> Exams { get; set; }
	public virtual DbSet<ExamQuestion> ExamQuestions { get; set; }
	public virtual DbSet<ExamTaken> ExamTakens { get; set; }
	public virtual DbSet<Language> Languages { get; set; }
	public virtual DbSet<Learning> Learnings { get; set; }
	public virtual DbSet<LikeView> LikeViews { get; set; }
	public virtual DbSet<Option> Options { get; set; }
	public virtual DbSet<Question> Questions { get; set; }
	public virtual DbSet<QuestionType> QuestionTypes { get; set; }
	public virtual DbSet<RateScore> RateScores { get; set; }
	public virtual DbSet<State> States { get; set; }
	public virtual DbSet<Tag> Tags { get; set; }
	public virtual DbSet<UserDto> UserDtos { get; set; }	
//----------------------






    }
}