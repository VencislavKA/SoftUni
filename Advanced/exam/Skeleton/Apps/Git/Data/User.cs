using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Git.Data
{
    public class User
    {
        //•	Has Commits collection – a Commit type
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Repositories = new HashSet<Repository>();
            this.Commits = new HashSet<Commit>();
        }
        public string Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public HashSet<Repository> Repositories { get; set; }
        public HashSet<Commit> Commits { get; set; }
    }
}
