using Microsoft.CodeAnalysis.Operations;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Git.ViewModels.Repositories
{
    public class RepositoryViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CommitsCount { get; set; }
    }
}
