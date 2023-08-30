using Microsoft.EntityFrameworkCore;
using Repositories.Models;
using System;

namespace Repositories
{
    public class Context : DbContext
    {
        public DbSet<Auth> Auths { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Chapter> Chapters { get; set; }

        public DbSet<Direction> Directions { get; set; }

        public DbSet<Question> Question { get; set; }

        public DbSet<Section> Sections { get; set; }

        public DbSet<Source> Sources { get; set; }

        public DbSet<Topic> Topic { get; set; }

        public DbSet<User> Users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=KnowledgeTestingDB;Trusted_Connection=True;");
        }
    }
}