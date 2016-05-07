namespace InternetApp
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using InternetApp.Models.ModelLogick;

    public partial class DataBaseContext : DbContext
    {
        public DataBaseContext(): base("name=DataBaseContext")
        {
        }

        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<TestBlock> TestBlocks { get; set; }
        public virtual DbSet<Test> Tests { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>()
                .HasMany(e => e.Answers)
                .WithRequired(e => e.Question)
                .HasForeignKey(e => e.Question_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TestBlock>()
                .HasMany(e => e.Tests)
                .WithRequired(e => e.TestBlock)
                .HasForeignKey(e => e.TestBlock_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Test>()
                .HasMany(e => e.Questions)
                .WithRequired(e => e.Test)
                .HasForeignKey(e => e.Test_Id)
                .WillCascadeOnDelete(false);
        }
    }
}
