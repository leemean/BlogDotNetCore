using BlogDotNetCore.Domain;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogDotNetCore.Data
{
    public class EFCoreDB : DbContext , IBaseDB
    {
        public DbSet<articleInfo> article_infos { get; set; }

        public DbSet<articleConetnt> article_conetnts { get; set; }

        public DbSet<articleComment> article_comments { get; set; }

        public DbSet<articlePicture> article_pictures { get; set; }

        public DbSet<articleType> article_types { get; set; }

        public EFCoreDB(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public IQueryable<TEntity> Table<TEntity>() where TEntity : class
        {
            return Set<TEntity>().AsNoTracking<TEntity>();
        }
    }
}
