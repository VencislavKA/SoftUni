using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Git.ViewModels.Repositories
{
    public class RepositoryInputModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool IsPublic { get; set; }
    }
}
