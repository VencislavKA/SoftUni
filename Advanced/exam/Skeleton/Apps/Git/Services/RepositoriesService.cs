using Git.Data;
using Git.ViewModels.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Git.Services
{
    public class RepositoriesService : IRepositoriesService
    {
        private readonly ApplicationDbContext db;

        public RepositoriesService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public string AddRepository(string name,bool isPublic,string userId)
        {
            User user = this.db.Users.FirstOrDefault(x => x.Id == userId);
            var repository = new Repository
            {
                Name = name,
                IsPublic = isPublic,
                CreatedOn = DateTime.Now,
                OwnerId = user.Id,
                Owner = user
            };
            this.db.Repositories.Add(repository);
            this.db.SaveChanges();
            return repository.Id;
        }

        public IEnumerable<RepositoryViewModel> GetAll()
        {
            return this.db.Repositories.Select(x => new RepositoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Owner = x.Owner.Username,
                CreatedOn = x.CreatedOn,
                CommitsCount = x.Commits.Count()
            }).ToList();
        }
    }
}
