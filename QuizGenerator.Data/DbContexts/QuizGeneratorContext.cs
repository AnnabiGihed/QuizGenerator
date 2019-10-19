using System.IO;
using QuizManager.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Design;


namespace QuizGenerator.Data.DbContexts
{
    public class QuizGeneratorContext : DbContext
    {
        public QuizGeneratorContext(DbContextOptions<QuizGeneratorContext> options)
            :base(options)
        {
        }

        public DbSet<Quiz> Quizs { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuizCategory> QuizCategories { get; set; }
        public DbSet<QuestionCategory> QuestionsCategory { get; set; }


    }

    #region Hidden
    //public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<QuestionContext>
    //{
    //    public QuestionContext CreateDbContext(string[] args)
    //    {
    //        IConfigurationRoot configuration = new ConfigurationBuilder()
    //                  .SetBasePath(Directory.GetCurrentDirectory())
    //                  .AddJsonFile("appsettings.json")
    //                  .Build();

    //        var builder = new DbContextOptionsBuilder<QuestionContext>();

    //        var connectionString = configuration.GetConnectionString("DatabaseConnection");

    //        builder.UseSqlServer(connectionString);

    //        return new QuestionContext(builder.Options);
    //    }
    //}
    #endregion
}
