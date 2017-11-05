using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
//using KSchulzePortfolio.Models;

namespace KSchulzePortfolio.Models
{
    public class EFGitRepoRepository : IGitRepoRepository
    {

        SchulzePortfolioDbContext db;

        public EFGitRepoRepository(SchulzePortfolioDbContext connection = null)
        {
            if (connection == null)
            {
                this.db = new SchulzePortfolioDbContext();
            }
            else
            {
                this.db = connection;
            }
        }

        public IQueryable<GitRepo> GitRepos
        {
            get { return db.GitRepos; }
        }

        public GitRepo Edit(GitRepo gitRepo)
        {
            db.GitRepos.Add(gitRepo);
            db.SaveChanges();
            return gitRepo;
        }

        public void Remove(GitRepo gitRepo)
        {
            db.GitRepos.Remove(gitRepo);
            db.SaveChanges();
        }

        public GitRepo Save(GitRepo gitRepo)
        {
            db.GitRepos.Add(gitRepo);
            db.SaveChanges();
            return gitRepo;
        }
    }
}
