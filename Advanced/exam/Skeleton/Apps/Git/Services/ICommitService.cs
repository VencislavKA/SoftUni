using Git.Data;
using Git.ViewModels.Commits;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Services
{
    public interface ICommitService
    {
        string Create(string description);
        void Delete(Commit commit);
        IEnumerable<Commit> GetAll();

        public Repository GetRepository(string Id);


    }
}
