using Git.ViewModels.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Services
{
    public interface IRepositoriesService
    {
        string AddRepository(string name, bool isPublic,string userId);

        IEnumerable<RepositoryViewModel> GetAll();
        
    }
}
