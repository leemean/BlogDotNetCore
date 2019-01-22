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
        public DbSet<articleInfo> articleInfos { get; set; }

        public DbSet<articleContent> articleConetnts { get; set; }

        public DbSet<articleComment> articleComments { get; set; }

        public DbSet<articlePicture> articlePictures { get; set; }

        public DbSet<articleType> articleTypes { get; set; }

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

        public bool Commit()
        {
            if (SaveChanges() > 0)
                return true;
            else
                return false;
        }
    }
}
