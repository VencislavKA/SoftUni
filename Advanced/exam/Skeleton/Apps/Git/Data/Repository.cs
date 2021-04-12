using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Git.Data
{
    public class Repository
    {
        
        //•	Has Commits collection – a Commit type
        public Repository()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Commits = new HashSet<Commit>();
        }
        public string Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public bool IsPublic { get; set; }

        public string OwnerId { get; set; }
        public User Owner { get; set; }
        public HashSet<Commit> Commits { get; set; }
    }
}
