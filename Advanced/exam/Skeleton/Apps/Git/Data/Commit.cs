using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Git.Data
{
    public class Commit
    {
        //        •	Has an Id – a string, Primary Key
        //•	Has a Description – a string with min length 5 (required)
        //•	Has a CreatedOn – a datetime(required)
        //•	Has a CreatorId – a string
        //•	Has Creator – a User object
        //•	Has RepositoryId – a string
        //•	Has Repository– a Repository object
        public string Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime CreaterdOn { get; set; }
        public string CreaterId { get; set; }
        public User Creater { get; set; }
        public string RepositoryId { get; set; }
        public Repository Repository { get; set; }
    }
}
