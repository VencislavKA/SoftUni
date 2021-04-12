using Git.Data;
using Git.ViewModels.Commits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Git.Services
{
    public class CommitService : ICommitService
    {
        private readonly ApplicationDbContext db;

        public CommitService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public string Create(string description)
        {
            var commit = new Commit
            {
                Description = description,
                CreaterdOn = DateTime.Now
            };
            this.db.Commits.Add(commit);
            this.db.SaveChanges();
            return commit.Id;
        }
        public Repository GetRepository(string Id)
        {
            return this.db.Repositories.FirstOrDefault(x=> x.Id == Id);
        }
        public IEnumerable<Commit> GetAll()
        {
            return this.db.Commits.Select(x => new Commit
            {
                Description = x.Description,
                CreaterdOn = x.CreaterdOn
            }).ToList();
        }
        public void Delete(Commit commit)
        {
            this.db.Remove(commit);
        }
    }
}
