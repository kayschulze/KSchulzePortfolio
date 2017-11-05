using System.Linq;

namespace KSchulzePortfolio.Models
{
    public interface IGitRepoRepository
    {
        IQueryable<GitRepo> GitRepos { get; }
        GitRepo Save(GitRepo gitRepo);
        GitRepo Edit(GitRepo gitRepo);
        void Remove(GitRepo gitRepo);
    }
}
